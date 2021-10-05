using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Product;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IRepositoryProduct _repositoryProduct;
        private readonly IMapper _mapper;

        public ServiceProduct(IRepositoryProduct repositoryProduct, IMapper mapper)
        {
            _repositoryProduct = repositoryProduct;
            _mapper = mapper;
        }

        public Result Add(ProductAddModel request)
        {
            try
            {
                var product = _mapper.Map<Product>(request);

                _repositoryProduct.Add(request);
                _repositoryProduct.Commit();

                var resultObj = _mapper.Map<ProductDetailsModel>(product);

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
                Product product = _repositoryProduct.GetById(id);

                if (product == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PRODUTO));
                }

                _repositoryProduct.Remove(product);
                _repositoryProduct.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.PRODUTO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoProduct = _repositoryProduct.GetById(id);

            if (repoProduct == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PRODUTO));

            var productDetails = _mapper.Map<ProductDetailsModel>(repoProduct);

            return new Result(true, productDetails);
        }

        public List<ProductDetailsModel> List()
        {
            var repoProducts = _repositoryProduct.List().ToList();
            var productDetails = _mapper.Map<List<ProductDetailsModel>>(repoProducts);
            return productDetails;
        }

        public Result Update(ProductUpdateModel request)
        {
            try
            {
                var product = _mapper.Map<Product>(request);

                _repositoryProduct.Edit(request);
                _repositoryProduct.Commit();

                var resultObj = _mapper.Map<ProductDetailsModel>(product);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
