using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.CategoryProduct;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceCategoryProduct : IServiceCategoryProduct
    {
        private readonly IRepositoryCategoryProduct _repositoryCategoryProduct;
        private readonly IMapper _mapper;

        public ServiceCategoryProduct(IRepositoryCategoryProduct repositoryCategoryProduct, IMapper mapper)
        {
            _repositoryCategoryProduct = repositoryCategoryProduct;
            _mapper = mapper;
        }

        public Result Add(CategoryProductAddModel request)
        {
            try
            {
                var categoryProduct = _mapper.Map<CategoryProduct>(request);

                _repositoryCategoryProduct.Add(categoryProduct);
                _repositoryCategoryProduct.Commit();

                var resultObj = _mapper.Map<CategoryProductDetailsModel>(categoryProduct);

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
                CategoryProduct categoryProduct = _repositoryCategoryProduct.GetById(id);

                if (categoryProduct == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PRODUTO));
                }

                _repositoryCategoryProduct.Remove(categoryProduct);
                _repositoryCategoryProduct.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.PRODUTO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoCategoryProduct = _repositoryCategoryProduct.GetById(id);

            if (repoCategoryProduct == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.PRODUTO));

            var categoryProductDetails = _mapper.Map<CategoryProductDetailsModel>(repoCategoryProduct);

            return new Result(true, categoryProductDetails);
        }

        public List<CategoryProductDetailsModel> List()
        {
            var repoCategoryProducts = _repositoryCategoryProduct.List().ToList();
            var categoryProductDetails = _mapper.Map<List<CategoryProductDetailsModel>>(repoCategoryProducts);
            return categoryProductDetails;
        }

        public Result Update(long id, CategoryProductUpdateModel request)
        {
            try
            {
                var categoryProduct = _mapper.Map<CategoryProduct>(request);
                categoryProduct.Id = id;

                _repositoryCategoryProduct.Edit(categoryProduct);
                _repositoryCategoryProduct.Commit();

                var resultObj = _mapper.Map<CategoryProductDetailsModel>(categoryProduct);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
