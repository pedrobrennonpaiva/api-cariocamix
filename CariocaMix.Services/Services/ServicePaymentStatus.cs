using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.PaymentStatus;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServicePaymentStatus : IServicePaymentStatus
    {
        private readonly IRepositoryPaymentStatus _repositoryPaymentStatus;
        private readonly IMapper _mapper;

        public ServicePaymentStatus(IRepositoryPaymentStatus repositoryPaymentStatus, IMapper mapper)
        {
            _repositoryPaymentStatus = repositoryPaymentStatus;
            _mapper = mapper;
        }

        public Result Add(PaymentStatusAddModel request)
        {
            try
            {
                var paymentStatus = _mapper.Map<PaymentStatus>(request);

                _repositoryPaymentStatus.Add(request);
                _repositoryPaymentStatus.Commit();

                var resultObj = _mapper.Map<PaymentStatusDetailsModel>(paymentStatus);

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
                PaymentStatus paymentStatus = _repositoryPaymentStatus.GetById(id);

                if (paymentStatus == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));
                }

                _repositoryPaymentStatus.Remove(paymentStatus);
                _repositoryPaymentStatus.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.STATUS));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoPaymentStatus = _repositoryPaymentStatus.GetById(id);

            if (repoPaymentStatus == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));

            var paymentStatusDetails = _mapper.Map<PaymentStatusDetailsModel>(repoPaymentStatus);

            return new Result(true, paymentStatusDetails);
        }

        public List<PaymentStatusDetailsModel> List()
        {
            var repoPaymentStatuss = _repositoryPaymentStatus.List().ToList();
            var paymentStatusDetails = _mapper.Map<List<PaymentStatusDetailsModel>>(repoPaymentStatuss);
            return paymentStatusDetails;
        }

        public Result Update(PaymentStatusUpdateModel request)
        {
            try
            {
                var paymentStatus = _mapper.Map<PaymentStatus>(request);

                _repositoryPaymentStatus.Edit(request);
                _repositoryPaymentStatus.Commit();

                var resultObj = _mapper.Map<PaymentStatusDetailsModel>(paymentStatus);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
