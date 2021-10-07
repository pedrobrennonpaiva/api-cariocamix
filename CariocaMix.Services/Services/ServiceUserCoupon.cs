using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.UserCoupon;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CariocaMix.Service.Services
{
    public class ServiceUserCoupon : IServiceUserCoupon
    {
        private readonly IRepositoryUserCoupon _repositoryUserCoupon;
        private readonly IMapper _mapper;

        public ServiceUserCoupon(IRepositoryUserCoupon repositoryUserCoupon, IMapper mapper)
        {
            _repositoryUserCoupon = repositoryUserCoupon;
            _mapper = mapper;
        }

        public Result Add(UserCouponAddModel request)
        {
            try
            {
                var userCoupon = _mapper.Map<UserCoupon>(request);

                _repositoryUserCoupon.Add(userCoupon);
                _repositoryUserCoupon.Commit();

                var resultObj = _mapper.Map<UserCouponDetailsModel>(userCoupon);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "cadastrar!"));
            }
        }

        public Result Delete(long id)
        {
            try
            {
                UserCoupon userCoupon = _repositoryUserCoupon.GetById(id);

                if (userCoupon == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.CUPOM));
                }

                _repositoryUserCoupon.Remove(userCoupon);
                _repositoryUserCoupon.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.CUPOM));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoUserCoupon = _repositoryUserCoupon.GetById(id);

            if (repoUserCoupon == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.CUPOM));

            var userCouponDetails = _mapper.Map<UserCouponDetailsModel>(repoUserCoupon);

            return new Result(true, userCouponDetails);
        }

        public Result ListByUserId(long userId)
        {
            var repoUserCoupon = _repositoryUserCoupon.ListBy(x => x.UserId == userId);

            if (repoUserCoupon == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.CUPOM));

            var userCouponDetails = _mapper.Map<List<UserCouponDetailsModel>>(repoUserCoupon);

            return new Result(true, userCouponDetails);
        }

        public List<UserCouponDetailsModel> List()
        {
            var repoUserCoupons = _repositoryUserCoupon.List().ToList();
            var userCouponDetails = _mapper.Map<List<UserCouponDetailsModel>>(repoUserCoupons);
            return userCouponDetails;
        }

        public Result Update(long id, UserCouponUpdateModel request)
        {
            try
            {
                var userCoupon = _mapper.Map<UserCoupon>(request);
                userCoupon.Id = id;

                _repositoryUserCoupon.Edit(userCoupon);
                _repositoryUserCoupon.Commit();

                var resultObj = _mapper.Map<UserCouponDetailsModel>(userCoupon);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
