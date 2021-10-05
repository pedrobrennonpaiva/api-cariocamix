using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.OrderProductItem;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceOrderProductItem : IServiceOrderProductItem
    {
        private readonly IRepositoryOrderProductItem _repositoryOrderProductItem;
        private readonly IMapper _mapper;

        public ServiceOrderProductItem(IRepositoryOrderProductItem repositoryOrderProductItem, IMapper mapper)
        {
            _repositoryOrderProductItem = repositoryOrderProductItem;
            _mapper = mapper;
        }

        public Result Add(OrderProductItemAddModel request)
        {
            try
            {
                var orderProductItem = _mapper.Map<OrderProductItem>(request);

                _repositoryOrderProductItem.Add(request);
                _repositoryOrderProductItem.Commit();

                var resultObj = _mapper.Map<OrderProductItemDetailsModel>(orderProductItem);

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
                OrderProductItem orderProductItem = _repositoryOrderProductItem.GetById(id);

                if (orderProductItem == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));
                }

                _repositoryOrderProductItem.Remove(orderProductItem);
                _repositoryOrderProductItem.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.ITEM));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoOrderProductItem = _repositoryOrderProductItem.GetById(id);

            if (repoOrderProductItem == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));

            var orderProductItemDetails = _mapper.Map<OrderProductItemDetailsModel>(repoOrderProductItem);

            return new Result(true, orderProductItemDetails);
        }

        public List<OrderProductItemDetailsModel> List()
        {
            var repoOrderProductItems = _repositoryOrderProductItem.List().ToList();
            var orderProductItemDetails = _mapper.Map<List<OrderProductItemDetailsModel>>(repoOrderProductItems);
            return orderProductItemDetails;
        }

        public Result Update(long id, OrderProductItemUpdateModel request)
        {
            try
            {
                var orderProductItem = _mapper.Map<OrderProductItem>(request);

                _repositoryOrderProductItem.Edit(request);
                _repositoryOrderProductItem.Commit();

                var resultObj = _mapper.Map<OrderProductItemDetailsModel>(orderProductItem);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
