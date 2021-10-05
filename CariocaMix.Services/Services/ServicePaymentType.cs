using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.PaymentType;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServicePaymentType : IServicePaymentType
    {
        private readonly IRepositoryPaymentType _repositoryPaymentType;
        private readonly IMapper _mapper;

        public ServicePaymentType(IRepositoryPaymentType repositoryPaymentType, IMapper mapper)
        {
            _repositoryPaymentType = repositoryPaymentType;
            _mapper = mapper;
        }

        public Result Add(PaymentTypeAddModel request)
        {
            try
            {
                var paymentType = _mapper.Map<PaymentType>(request);

                _repositoryPaymentType.Add(request);
                _repositoryPaymentType.Commit();

                var resultObj = _mapper.Map<PaymentTypeDetailsModel>(paymentType);

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
                PaymentType paymentType = _repositoryPaymentType.GetById(id);

                if (paymentType == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PAGAMENTO));
                }

                _repositoryPaymentType.Remove(paymentType);
                _repositoryPaymentType.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.PAGAMENTO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoPaymentType = _repositoryPaymentType.GetById(id);

            if (repoPaymentType == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PAGAMENTO));

            var paymentTypeDetails = _mapper.Map<PaymentTypeDetailsModel>(repoPaymentType);

            return new Result(true, paymentTypeDetails);
        }

        public List<PaymentTypeDetailsModel> List()
        {
            var repoPaymentTypes = _repositoryPaymentType.List().ToList();
            var paymentTypeDetails = _mapper.Map<List<PaymentTypeDetailsModel>>(repoPaymentTypes);
            return paymentTypeDetails;
        }

        public Result Update(long id, PaymentTypeUpdateModel request)
        {
            try
            {
                var paymentType = _mapper.Map<PaymentType>(request);

                _repositoryPaymentType.Edit(request);
                _repositoryPaymentType.Commit();

                var resultObj = _mapper.Map<PaymentTypeDetailsModel>(paymentType);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
