using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Helpers;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.ReturnMessage;
using CariocaMix.Domain.Models.Token;
using CariocaMix.Domain.Models.User;
using CariocaMix.Utils.Email;
using CariocaMix.Utils.Resources;
using CariocaMix.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IMapper _mapper;
        private readonly ISendEmail _sendEmail;

        public ServiceUser(IRepositoryUser repositoryUser, IMapper mapper, ISendEmail sendEmail)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
            _sendEmail = sendEmail;
        }

        public ReturnMessageResponse GetById(long id)
        {
            var repoUser = _repositoryUser.GetById(id);

            if (repoUser == null)
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            var userDetails = _mapper.Map<UserDetailsModel>(repoUser.WithoutPassword());

            return new ReturnMessageResponse(true, userDetails);
        }

        public ReturnMessageResponse ListByName(string name)
        {
            var repoUser = _repositoryUser.ListBy(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();

            if (repoUser == null)
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            var userDetails = _mapper.Map<List<UserDetailsModel>>(repoUser.WithoutPasswords());

            return new ReturnMessageResponse(true, userDetails);
        }

        public ReturnMessageResponse ListBySearch(string search)
        {
            var repoUser = _repositoryUser.ListBy(x => 
                x.Name.ToUpper().Contains(search.ToUpper()) ||
                x.Username.ToUpper().Contains(search.ToUpper()) ||
                x.Email.ToUpper().Contains(search.ToUpper())
            ).ToList();

            if (repoUser == null)
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            var userDetails = _mapper.Map<List<UserDetailsModel>>(repoUser.WithoutPasswords());

            return new ReturnMessageResponse(true, userDetails);
        }

        public List<UserDetailsModel> List()
        {
            var repoUsers = _repositoryUser.List().ToList();
            var userDetails = _mapper.Map<List<UserDetailsModel>>(repoUsers.WithoutPasswords());
            return userDetails;
        }

        public ReturnMessageResponse Authenticate(AuthenticateModel model)
        {
            string passwordHashed = Utils.Security.HashPassword.GetHash(model.Password);

            User user = null;

            model.Username = model.Username.Trim();

            try
            {
                if (model.Username.Contains("@"))
                {
                    user = _repositoryUser.GetBy(x => x.Email != null && x.Email.ToLower().Equals(model.Username.ToLower()) && x.Password == passwordHashed);
                }
                else
                {
                    user = _repositoryUser.GetBy(x => x.Username == model.Username && x.Password == passwordHashed);
                }
            }
            catch
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "buscar o usuário!"));
            }

            if (user == null)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));
            }

            var userAuth = AuthenticationToken.GenerateToken(user);

            if (userAuth == null)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "gerar o token!"));
            }

            return new ReturnMessageResponse(true, userAuth);
        }

        public ReturnMessageResponse ChangePassword(ChangePasswordModel model)
        {
            try
            {
                User user = _repositoryUser.GetBy(x => x.Id == model.Id);

                if (user == null)
                    return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

                if(string.IsNullOrEmpty(model.NewPassword))
                    return new ReturnMessageResponse(false, 0, string.Format(Message.X0_DEVE_SER_PREENCHIDA, Texts.SENHA));

                string validatePassword = StringValidator.ValidatePasswordEightCharacters(model.NewPassword);

                if (!string.IsNullOrEmpty(validatePassword))
                {
                    return new ReturnMessageResponse(false, 0, validatePassword);
                }

                string hashNewPassword = Utils.Security.HashPassword.GetHash(model.NewPassword);

                if (user.Password.Equals(hashNewPassword))
                {
                    return new ReturnMessageResponse(false, 0, string.Format(Message.AS_X0_NAO_PODEM_SER_IGUAIS, Texts.SENHA.ToLower() + "s"));
                }

                user.Password = Utils.Security.HashPassword.GetHash(model.NewPassword);

                _repositoryUser.Edit(user);
                _repositoryUser.Commit();

                _sendEmail.SendOneEmail("Teste", "Testando e-mail", user.Email);

                return new ReturnMessageResponse(true);
            }
            catch (Exception ex)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar a senha!"));
            }

        }

        public ReturnMessageResponse Add(UserAddModel request)
        {
            try
            {
                CleanData(request);

                var userExist = _repositoryUser.Exist(x => 
                    x.Cpf.Equals(request.Cpf) || 
                    x.Email.Equals(request.Email) || 
                    (!string.IsNullOrEmpty(x.Username) && x.Username.Equals(request.Username)));

                if(userExist)
                {
                    return new ReturnMessageResponse(false, 0, string.Format(Message.JA_EXISTE_X0, "um usuário com este e-mail/CPF/username"));
                }

                request.Password = Utils.Security.HashPassword.GetHash(request.Password);

                var user = _mapper.Map<User>(request);
                user.RegisterDate = DateTime.Now;

                _repositoryUser.Add(user);
                _repositoryUser.Commit();

                var resultObj = _mapper.Map<UserDetailsModel>(user);

                return new ReturnMessageResponse(true, resultObj);
            }
            catch (Exception ex)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "cadastrar!"));
            }
        }

        public ReturnMessageResponse Update(long id, UserUpdateModel request)
        {
            if (request == null)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.USUARIO));
            }

            User user = _repositoryUser.GetById(id);

            if (user == null)
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));

            if (string.IsNullOrEmpty(request.Email))
                return new ReturnMessageResponse(false, 0, string.Format(Message.X0_DEVE_SER_PREENCHIDA, Texts.EMAIL));

            try
            {
                request.Name = request.Name.Trim();
                request.Email = request.Email.Trim().ToLower();
                request.Username = !string.IsNullOrEmpty(request.Username) ? request.Username.Trim().ToLower() : request.Username;
                request.Password = user.Password;

                var userUpdate = _mapper.Map<User>(request);
                userUpdate.Id = id;

                _repositoryUser.Edit(userUpdate);
                _repositoryUser.Commit();

                return new ReturnMessageResponse(true);
            }
            catch (Exception ex)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }

        public ReturnMessageResponse Delete(long id)
        {
            try
            {
                User user = _repositoryUser.GetById(id);

                if (user == null)
                {
                    return new ReturnMessageResponse(false, 0, string.Format(Message.X0_NAO_ENCONTRADO, Texts.USUARIO));
                }

                _repositoryUser.Remove(user);
                _repositoryUser.Commit();

                return new ReturnMessageResponse(true);
            }
            catch (Exception ex)
            {
                return new ReturnMessageResponse(false, 0, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        private void CleanData(UserAddModel request)
        {
            request.Name = request.Name.Trim();
            request.Email = request.Email.Trim().ToLower();
            request.Username = !string.IsNullOrEmpty(request.Username) ? request.Username.Trim().ToLower() : request.Username;
            request.Cpf = request.Cpf.Trim().Replace(".","").Replace("-","");
        }
    }
}
