using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Helpers;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Token;
using CariocaMix.Domain.Models.Admin;
using CariocaMix.Utils.Resources;
using CariocaMix.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using CariocaMix.Domain.Models.User;

namespace CariocaMix.Service.Services
{
    public class ServiceAdmin : IServiceAdmin
    {
        private readonly IRepositoryAdmin _repositoryAdmin;
        private readonly IMapper _mapper;

        public ServiceAdmin(IRepositoryAdmin repositoryAdmin, IMapper mapper)
        {
            _repositoryAdmin = repositoryAdmin;
            _mapper = mapper;
        }

        public Result GetById(long id)
        {
            var repoAdmin = _repositoryAdmin.GetById(id);

            if (repoAdmin == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            var adminDetails = _mapper.Map<AdminDetailsModel>(repoAdmin.WithoutPassword());

            return new Result(true, adminDetails);
        }

        public Result ListByName(string name)
        {
            var repoUser = _repositoryAdmin.ListBy(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();

            if (repoUser == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            var userDetails = _mapper.Map<List<UserDetailsModel>>(repoUser.WithoutPasswords());

            return new Result(true, userDetails);
        }

        public Result ListBySearch(string search)
        {
            var repoUser = _repositoryAdmin.ListBy(x =>
                x.Name.ToUpper().Contains(search.ToUpper()) ||
                x.Username.ToUpper().Contains(search.ToUpper()) ||
                x.Email.ToUpper().Contains(search.ToUpper())
            ).ToList();

            if (repoUser == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            var userDetails = _mapper.Map<List<UserDetailsModel>>(repoUser.WithoutPasswords());

            return new Result(true, userDetails);
        }

        public List<AdminDetailsModel> List()
        {
            var repoAdmins = _repositoryAdmin.List().ToList();
            var adminDetails = _mapper.Map<List<AdminDetailsModel>>(repoAdmins.WithoutPasswords());
            return adminDetails;
        }

        public Result Authenticate(AuthenticateModel model)
        {
            string passwordHashed = Utils.Security.HashPassword.GetHash(model.Password);

            Admin admin = null;

            model.Username = model.Username.Trim();

            try
            {
                if (model.Username.Contains("@"))
                {
                    admin = _repositoryAdmin.GetBy(x => x.Email != null && x.Email.ToLower().Equals(model.Username.ToLower()) && x.Password == passwordHashed);
                }
                else
                {
                    admin = _repositoryAdmin.GetBy(x => x.Username == model.Username && x.Password == passwordHashed);
                }
            }
            catch
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "buscar o usuário!"));
            }

            if (admin == null)
            {
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));
            }

            var adminAuth = AuthenticationToken.GenerateTokenAdmin(admin);

            if (adminAuth == null)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "gerar o token!"));
            }

            return new Result(true, adminAuth);
        }

        public Result ChangePassword(ChangePasswordModel model)
        {
            try
            {
                Admin admin = _repositoryAdmin.GetBy(x => x.Id == model.Id);

                if (admin == null)
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

                if(string.IsNullOrEmpty(model.NewPassword))
                    return new Result(false, string.Format(Message.X0_DEVE_SER_PREENCHIDA, Texts.SENHA), admin);

                string validatePassword = StringValidator.ValidatePasswordEightCharacters(model.NewPassword);

                if (!string.IsNullOrEmpty(validatePassword))
                {
                    return new Result(false, validatePassword, admin);
                }

                string hashNewPassword = Utils.Security.HashPassword.GetHash(model.NewPassword);

                if (admin.Password.Equals(hashNewPassword))
                {
                    return new Result(false, string.Format(Message.AS_X0_NAO_PODEM_SER_IGUAIS, Texts.SENHA.ToLower() + "s"), admin);
                }

                admin.Password = Utils.Security.HashPassword.GetHash(model.NewPassword);

                _repositoryAdmin.Edit(admin);
                _repositoryAdmin.Commit();

                return new Result(true, admin);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar a senha!"));
            }

        }

        public Result Add(AdminAddModel request)
        {
            try
            {
                string pass = string.Empty;

                if (!string.IsNullOrEmpty(request.Password))
                {
                    string validatePassword = StringValidator.ValidatePasswordEightCharacters(request.Password);

                    if (!string.IsNullOrEmpty(validatePassword))
                    {
                        return new Result(false, validatePassword);
                    }

                    pass = request.Password;
                    request.Password = Utils.Security.HashPassword.GetHash(request.Password);
                }

                if (string.IsNullOrEmpty(request.Email))
                {
                    return new Result(false, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.EMAIL));
                }

                request.Name = request.Name.Trim();
                request.Email = request.Email.Trim().ToLower();
                request.Username = !string.IsNullOrEmpty(request.Username) ? request.Username.Trim().ToLower() : request.Username;
               
                var admin = _mapper.Map<Admin>(request);
                admin.RegisterDate = DateTime.Now;

                _repositoryAdmin.Add(admin);
                _repositoryAdmin.Commit();

                var resultObj = _mapper.Map<AdminDetailsModel>(admin);
                resultObj.Password = null;

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "cadastrar!"));
            }
        }

        public Result Update(long id, AdminUpdateModel request)
        {
            if (request == null)
            {
                return new Result(false, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.USUARIO));
            }

            Admin admin = _repositoryAdmin.GetById(id);

            if (admin == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            if (string.IsNullOrEmpty(request.Email))
                return new Result(false, string.Format(Message.X0_DEVE_SER_PREENCHIDA, Texts.EMAIL));

            try
            {
                request.Name = request.Name.Trim();
                request.Email = request.Email.Trim().ToLower();
                request.Username = !string.IsNullOrEmpty(request.Username) ? request.Username.Trim().ToLower() : request.Username;
                request.Password = admin.Password;

                var adminUpdate = _mapper.Map<Admin>(request);
                adminUpdate.Id = id;

                _repositoryAdmin.Edit(adminUpdate);
                _repositoryAdmin.Commit();

                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }

        public Result Delete(long id)
        {
            try
            {
                Admin admin = _repositoryAdmin.GetById(id);

                if (admin == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));
                }

                _repositoryAdmin.Remove(admin);
                _repositoryAdmin.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.USUARIO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }
    }
}
