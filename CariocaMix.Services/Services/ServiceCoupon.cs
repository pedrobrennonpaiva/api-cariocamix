using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Coupon;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceCoupon : IServiceCoupon
    {
        private readonly IRepositoryCoupon _repositoryCoupon;
        private readonly IMapper _mapper;

        public ServiceCoupon(IRepositoryCoupon repositoryCoupon, IMapper mapper)
        {
            _repositoryCoupon = repositoryCoupon;
            _mapper = mapper;
        }

        public Result Add(CouponAddModel request)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(request);

                _repositoryCoupon.Add(coupon);
                _repositoryCoupon.Commit();

                var resultObj = _mapper.Map<CouponDetailsModel>(coupon);

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
                Coupon coupon = _repositoryCoupon.GetById(id);

                if (coupon == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));
                }

                _repositoryCoupon.Remove(coupon);
                _repositoryCoupon.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.STATUS));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoCoupon = _repositoryCoupon.GetById(id);

            if (repoCoupon == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));

            var couponDetails = _mapper.Map<CouponDetailsModel>(repoCoupon);

            return new Result(true, couponDetails);
        }

        public Result GetByCode(string code)
        {
            var repoCoupon = _repositoryCoupon.GetBy(x => x.Code.Equals(code));

            if (repoCoupon == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));

            var couponDetails = _mapper.Map<CouponDetailsModel>(repoCoupon);

            return new Result(true, couponDetails);
        }

        public List<CouponDetailsModel> List()
        {
            var repoCoupons = _repositoryCoupon.List().ToList();
            var couponDetails = _mapper.Map<List<CouponDetailsModel>>(repoCoupons);
            return couponDetails;
        }

        public Result Update(long id, CouponUpdateModel request)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(request);
                coupon.Id = id;

                _repositoryCoupon.Edit(coupon);
                _repositoryCoupon.Commit();

                var resultObj = _mapper.Map<CouponDetailsModel>(coupon);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
