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
using CariocaMix.Domain.Models.CategoryProduct;
using CariocaMix.Domain.Models.ProductItem;

namespace CariocaMix.Service.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryItem _repositoryItem;
        private readonly IRepositoryProduct _repositoryProduct;
        private readonly IRepositoryCategory _repositoryCategory;
        private readonly IRepositoryProductItem _repositoryProductItem;
        private readonly IRepositoryCategoryProduct _repositoryCategoryProduct;

        public ServiceProduct(IRepositoryProduct repositoryProduct, IRepositoryProductItem repositoryProductItem,
            IRepositoryCategory repositoryCategory, IRepositoryCategoryProduct repositoryCategoryProduct, 
            IRepositoryItem repositoryItem, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryItem = repositoryItem;
            _repositoryProduct = repositoryProduct;
            _repositoryCategory = repositoryCategory;
            _repositoryProductItem = repositoryProductItem;
            _repositoryCategoryProduct = repositoryCategoryProduct;
        }

        public Result Add(ProductAddModel request)
        {
            try
            {
                var product = _mapper.Map<Product>(request);

                _repositoryProduct.BeginTransation();

                _repositoryProduct.Add(product);
                _repositoryProduct.Commit();

                if (request.CategoryProducts != null)
                {
                    foreach (var categoryProduct in request.CategoryProducts ?? Enumerable.Empty<CategoryProduct>())
                    {
                        if(_repositoryCategory.GetById(categoryProduct.CategoryId) == null)
                        {
                            _repositoryProduct.TransationRollback();
                            return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.CATEGORIA));
                        }
                        categoryProduct.ProductId = product.Id;

                        _repositoryCategoryProduct.Add(categoryProduct);
                        _repositoryCategoryProduct.Commit();
                    }
                }

                if(request.ProductItems != null)
                {
                    foreach (var productItem in request.ProductItems ?? Enumerable.Empty<ProductItem>())
                    {
                        if(_repositoryItem.GetById(productItem.ItemId) == null)
                        {
                            _repositoryProduct.TransationRollback();
                            return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));
                        }
                        productItem.ProductId = product.Id;

                        _repositoryProductItem.Add(productItem);
                        _repositoryProductItem.Commit();
                    }
                }

                _repositoryProduct.TransationCommit();

                var resultObj = _mapper.Map<ProductDetailsModel>(product);
                resultObj.ProductItems = _mapper.Map<List<ProductItemDetailsModel>>(request.ProductItems);
                resultObj.CategoryProducts = _mapper.Map<List<CategoryProductDetailsModel>>(request.CategoryProducts);

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

        public Result Update(long id, ProductUpdateModel request)
        {
            try
            {
                var product = _mapper.Map<Product>(request);
                product.Id = id;

                _repositoryProduct.Edit(product);
                _repositoryProduct.Commit();

                var categoryProductsExist = _repositoryCategoryProduct.ListBy(x => x.ProductId == id).ToList();
                if (categoryProductsExist.Count > 0 || request.CategoryProducts != null)
                {
                    request.CategoryProducts = request.CategoryProducts.FindAll(x => 
                        !categoryProductsExist.Exists(y => y.CategoryId == x.CategoryId));

                    categoryProductsExist = categoryProductsExist.FindAll(x => 
                        request.CategoryProducts.Exists(y => y.CategoryId == x.CategoryId));

                    foreach (var categoryProduct in request.CategoryProducts ?? Enumerable.Empty<CategoryProduct>())
                    {
                        if (_repositoryCategory.GetById(categoryProduct.CategoryId) == null)
                        {
                            return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.CATEGORIA));
                        }
                        categoryProduct.ProductId = product.Id;

                        _repositoryCategoryProduct.Add(categoryProduct);
                        _repositoryCategoryProduct.Commit();
                    }

                    foreach(var categoryProduct in categoryProductsExist ?? Enumerable.Empty<CategoryProduct>())
                    {
                        _repositoryCategoryProduct.Remove(categoryProduct);
                        _repositoryCategoryProduct.Commit();
                    }
                }

                var productItemsExist = _repositoryProductItem.ListBy(x => x.ProductId == id).ToList();
                if (productItemsExist.Count > 0 || request.ProductItems != null)
                {
                    request.ProductItems = request.ProductItems.FindAll(x =>
                        !productItemsExist.Exists(y => y.ItemId == x.ItemId && y.IsDefault == x.IsDefault));

                    productItemsExist = productItemsExist.FindAll(x =>
                        request.ProductItems.Exists(y => y.ItemId == x.ItemId && y.IsDefault == x.IsDefault));

                    foreach (var productItem in request.ProductItems ?? Enumerable.Empty<ProductItem>())
                    {
                        if (_repositoryItem.GetById(productItem.ItemId) == null)
                        {
                            return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));
                        }
                        productItem.ProductId = product.Id;

                        _repositoryProductItem.Add(productItem);
                        _repositoryProductItem.Commit();
                    }

                    foreach (var productItem in productItemsExist ?? Enumerable.Empty<ProductItem>())
                    {
                        _repositoryProductItem.Remove(productItem);
                        _repositoryProductItem.Commit();
                    }
                }

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
