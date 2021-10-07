using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Order;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceOrder : IServiceOrder
    {
        private readonly IRepositoryOrder _repositoryOrder;
        private readonly IMapper _mapper;

        public ServiceOrder(IRepositoryOrder repositoryOrder, IMapper mapper)
        {
            _repositoryOrder = repositoryOrder;
            _mapper = mapper;
        }

        public Result Add(OrderAddModel request)
        {
            try
            {
                var order = _mapper.Map<Order>(request);

                _repositoryOrder.Add(order);
                _repositoryOrder.Commit();

                var resultObj = _mapper.Map<OrderDetailsModel>(order);

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
                Order order = _repositoryOrder.GetById(id);

                if (order == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PEDIDO));
                }

                _repositoryOrder.Remove(order);
                _repositoryOrder.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.PEDIDO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoOrder = _repositoryOrder.GetById(id);

            if (repoOrder == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PEDIDO));

            var orderDetails = _mapper.Map<OrderDetailsModel>(repoOrder);

            return new Result(true, orderDetails);
        }

        public List<OrderDetailsModel> List()
        {
            var repoOrders = _repositoryOrder.List().ToList();
            var orderDetails = _mapper.Map<List<OrderDetailsModel>>(repoOrders);
            return orderDetails;
        }

        public Result Update(long id, OrderUpdateModel request)
        {
            try
            {
                var order = _mapper.Map<Order>(request);
                order.Id = id;

                _repositoryOrder.Edit(order);
                _repositoryOrder.Commit();

                var resultObj = _mapper.Map<OrderDetailsModel>(order);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
