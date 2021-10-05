using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.OrderProduct;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceOrderProduct : IServiceOrderProduct
    {
        private readonly IRepositoryOrderProduct _repositoryOrderProduct;
        private readonly IMapper _mapper;

        public ServiceOrderProduct(IRepositoryOrderProduct repositoryOrderProduct, IMapper mapper)
        {
            _repositoryOrderProduct = repositoryOrderProduct;
            _mapper = mapper;
        }

        public Result Add(OrderProductAddModel request)
        {
            try
            {
                var orderProduct = _mapper.Map<OrderProduct>(request);

                _repositoryOrderProduct.Add(request);
                _repositoryOrderProduct.Commit();

                var resultObj = _mapper.Map<OrderProductDetailsModel>(orderProduct);

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
                OrderProduct orderProduct = _repositoryOrderProduct.GetById(id);

                if (orderProduct == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PRODUTO));
                }

                _repositoryOrderProduct.Remove(orderProduct);
                _repositoryOrderProduct.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.PRODUTO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoOrderProduct = _repositoryOrderProduct.GetById(id);

            if (repoOrderProduct == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PRODUTO));

            var orderProductDetails = _mapper.Map<OrderProductDetailsModel>(repoOrderProduct);

            return new Result(true, orderProductDetails);
        }

        public List<OrderProductDetailsModel> List()
        {
            var repoOrderProducts = _repositoryOrderProduct.List().ToList();
            var orderProductDetails = _mapper.Map<List<OrderProductDetailsModel>>(repoOrderProducts);
            return orderProductDetails;
        }

        public Result Update(long id, OrderProductUpdateModel request)
        {
            try
            {
                var orderProduct = _mapper.Map<OrderProduct>(request);

                _repositoryOrderProduct.Edit(request);
                _repositoryOrderProduct.Commit();

                var resultObj = _mapper.Map<OrderProductDetailsModel>(orderProduct);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
