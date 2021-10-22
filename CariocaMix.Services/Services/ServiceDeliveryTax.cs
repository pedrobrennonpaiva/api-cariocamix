using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.DeliveryTax;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceDeliveryTax : IServiceDeliveryTax
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryStore _repositoryStore;
        private readonly IRepositoryDeliveryTax _repositoryDeliveryTax;

        public ServiceDeliveryTax(IMapper mapper, IRepositoryDeliveryTax repositoryDeliveryTax,
            IRepositoryStore repositoryStore)
        {
            _mapper = mapper;
            _repositoryStore = repositoryStore;
            _repositoryDeliveryTax = repositoryDeliveryTax;
        }

        public Result Add(DeliveryTaxAddModel request)
        {
            try
            {
                if(_repositoryStore.GetById(request.StoreId) == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.LOJA));
                }

                if (_repositoryDeliveryTax.ListBy(x => x.StoreId == request.StoreId && x.Radius == request.Radius).Any())
                {
                    return new Result(false, string.Format(Message.JA_EXISTE_X0, "uma taxa com este raio"));
                }

                var deliveryTax = _mapper.Map<DeliveryTax>(request);

                _repositoryDeliveryTax.Add(deliveryTax);
                _repositoryDeliveryTax.Commit();

                var resultObj = _mapper.Map<DeliveryTaxDetailsModel>(deliveryTax);

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
                DeliveryTax deliveryTax = _repositoryDeliveryTax.GetById(id);

                if (deliveryTax == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.TAXA));
                }

                _repositoryDeliveryTax.Remove(deliveryTax);
                _repositoryDeliveryTax.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDA_COM_SUCESSO, Texts.TAXA));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoDeliveryTax = _repositoryDeliveryTax.GetById(id);

            if (repoDeliveryTax == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.TAXA));

            var deliveryTaxDetails = _mapper.Map<DeliveryTaxDetailsModel>(repoDeliveryTax);

            return new Result(true, deliveryTaxDetails);
        }

        public List<DeliveryTaxDetailsModel> List()
        {
            var repoDeliveryTaxs = _repositoryDeliveryTax.List().ToList();
            var deliveryTaxDetails = _mapper.Map<List<DeliveryTaxDetailsModel>>(repoDeliveryTaxs);
            return deliveryTaxDetails;
        }

        public Result Update(long id, DeliveryTaxUpdateModel request)
        {
            try
            {
                if (_repositoryStore.GetById(request.StoreId) == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.LOJA));
                }

                var deliveryTax = _mapper.Map<DeliveryTax>(request);

                if(id == 0)
                {
                    var delTax = _repositoryDeliveryTax.GetBy(x => x.StoreId == deliveryTax.StoreId && x.Radius == deliveryTax.Radius);

                    if (delTax == null)
                    {
                        var addModel = _mapper.Map<DeliveryTaxAddModel>(deliveryTax);
                        return Add(addModel);
                    }

                    deliveryTax.Id = delTax.Id;
                }
                else
                {
                    deliveryTax.Id = id;
                }

                _repositoryDeliveryTax.Edit(deliveryTax);
                _repositoryDeliveryTax.Commit();

                var resultObj = _mapper.Map<DeliveryTaxDetailsModel>(deliveryTax);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
