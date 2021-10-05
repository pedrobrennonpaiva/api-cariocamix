using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.DeliveryStatus;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceDeliveryStatus : IServiceDeliveryStatus
    {
        private readonly IRepositoryDeliveryStatus _repositoryDeliveryStatus;
        private readonly IMapper _mapper;

        public ServiceDeliveryStatus(IRepositoryDeliveryStatus repositoryDeliveryStatus, IMapper mapper)
        {
            _repositoryDeliveryStatus = repositoryDeliveryStatus;
            _mapper = mapper;
        }

        public Result Add(DeliveryStatusAddModel request)
        {
            try
            {
                var deliveryStatus = _mapper.Map<DeliveryStatus>(request);

                _repositoryDeliveryStatus.Add(request);
                _repositoryDeliveryStatus.Commit();

                var resultObj = _mapper.Map<DeliveryStatusDetailsModel>(deliveryStatus);

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
                DeliveryStatus deliveryStatus = _repositoryDeliveryStatus.GetById(id);

                if (deliveryStatus == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));
                }

                _repositoryDeliveryStatus.Remove(deliveryStatus);
                _repositoryDeliveryStatus.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.STATUS));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoDeliveryStatus = _repositoryDeliveryStatus.GetById(id);

            if (repoDeliveryStatus == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.STATUS));

            var deliveryStatusDetails = _mapper.Map<DeliveryStatusDetailsModel>(repoDeliveryStatus);

            return new Result(true, deliveryStatusDetails);
        }

        public List<DeliveryStatusDetailsModel> List()
        {
            var repoDeliveryStatuss = _repositoryDeliveryStatus.List().ToList();
            var deliveryStatusDetails = _mapper.Map<List<DeliveryStatusDetailsModel>>(repoDeliveryStatuss);
            return deliveryStatusDetails;
        }

        public Result Update(DeliveryStatusUpdateModel request)
        {
            try
            {
                var deliveryStatus = _mapper.Map<DeliveryStatus>(request);

                _repositoryDeliveryStatus.Edit(request);
                _repositoryDeliveryStatus.Commit();

                var resultObj = _mapper.Map<DeliveryStatusDetailsModel>(deliveryStatus);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
