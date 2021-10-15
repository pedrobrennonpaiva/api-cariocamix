using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.DeliveryRemoveArea;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceDeliveryRemoveArea : IServiceDeliveryRemoveArea
    {
        private readonly IRepositoryDeliveryRemoveArea _repositoryDeliveryRemoveArea;
        private readonly IMapper _mapper;

        public ServiceDeliveryRemoveArea(IRepositoryDeliveryRemoveArea repositoryDeliveryRemoveArea, IMapper mapper)
        {
            _repositoryDeliveryRemoveArea = repositoryDeliveryRemoveArea;
            _mapper = mapper;
        }

        public Result Add(DeliveryRemoveAreaAddModel request)
        {
            try
            {
                var deliveryRemoveArea = _mapper.Map<DeliveryRemoveArea>(request);

                _repositoryDeliveryRemoveArea.Add(deliveryRemoveArea);
                _repositoryDeliveryRemoveArea.Commit();

                var resultObj = _mapper.Map<DeliveryRemoveAreaDetailsModel>(deliveryRemoveArea);

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
                DeliveryRemoveArea deliveryRemoveArea = _repositoryDeliveryRemoveArea.GetById(id);

                if (deliveryRemoveArea == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.TAXA));
                }

                _repositoryDeliveryRemoveArea.Remove(deliveryRemoveArea);
                _repositoryDeliveryRemoveArea.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDA_COM_SUCESSO, Texts.TAXA));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoDeliveryRemoveArea = _repositoryDeliveryRemoveArea.GetById(id);

            if (repoDeliveryRemoveArea == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.TAXA));

            var deliveryRemoveAreaDetails = _mapper.Map<DeliveryRemoveAreaDetailsModel>(repoDeliveryRemoveArea);

            return new Result(true, deliveryRemoveAreaDetails);
        }

        public List<DeliveryRemoveAreaDetailsModel> List()
        {
            var repoDeliveryRemoveAreas = _repositoryDeliveryRemoveArea.List().ToList();
            var deliveryRemoveAreaDetails = _mapper.Map<List<DeliveryRemoveAreaDetailsModel>>(repoDeliveryRemoveAreas);
            return deliveryRemoveAreaDetails;
        }

        public Result Update(long id, DeliveryRemoveAreaUpdateModel request)
        {
            try
            {
                var deliveryRemoveArea = _mapper.Map<DeliveryRemoveArea>(request);
                deliveryRemoveArea.Id = id;

                _repositoryDeliveryRemoveArea.Edit(deliveryRemoveArea);
                _repositoryDeliveryRemoveArea.Commit();

                var resultObj = _mapper.Map<DeliveryRemoveAreaDetailsModel>(deliveryRemoveArea);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
