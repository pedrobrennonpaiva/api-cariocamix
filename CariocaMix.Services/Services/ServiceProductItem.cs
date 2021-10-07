using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.ProductItem;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceProductItem : IServiceProductItem
    {
        private readonly IRepositoryProductItem _repositoryProductItem;
        private readonly IMapper _mapper;

        public ServiceProductItem(IRepositoryProductItem repositoryProductItem, IMapper mapper)
        {
            _repositoryProductItem = repositoryProductItem;
            _mapper = mapper;
        }

        public Result Add(ProductItemAddModel request)
        {
            try
            {
                var productItem = _mapper.Map<ProductItem>(request);

                _repositoryProductItem.Add(productItem);
                _repositoryProductItem.Commit();

                var resultObj = _mapper.Map<ProductItemDetailsModel>(productItem);

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
                ProductItem productItem = _repositoryProductItem.GetById(id);

                if (productItem == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));
                }

                _repositoryProductItem.Remove(productItem);
                _repositoryProductItem.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.ITEM));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoProductItem = _repositoryProductItem.GetById(id);

            if (repoProductItem == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));

            var productItemDetails = _mapper.Map<ProductItemDetailsModel>(repoProductItem);

            return new Result(true, productItemDetails);
        }

        public List<ProductItemDetailsModel> List()
        {
            var repoProductItems = _repositoryProductItem.List().ToList();
            var productItemDetails = _mapper.Map<List<ProductItemDetailsModel>>(repoProductItems);
            return productItemDetails;
        }

        public Result Update(long id, ProductItemUpdateModel request)
        {
            try
            {
                var productItem = _mapper.Map<ProductItem>(request);
                productItem.Id = id;

                _repositoryProductItem.Edit(productItem);
                _repositoryProductItem.Commit();

                var resultObj = _mapper.Map<ProductItemDetailsModel>(productItem);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
