using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Category;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;
        private readonly IMapper _mapper;

        public ServiceCategory(IRepositoryCategory repositoryCategory, IMapper mapper)
        {
            _repositoryCategory = repositoryCategory;
            _mapper = mapper;
        }

        public Result Add(CategoryAddModel request)
        {
            try
            {
                var category = _mapper.Map<Category>(request);

                _repositoryCategory.Add(request);
                _repositoryCategory.Commit();

                var resultObj = _mapper.Map<CategoryDetailsModel>(category);

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
                Category category = _repositoryCategory.GetById(id);

                if (category == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.CATEGORIA));
                }

                _repositoryCategory.Remove(category);
                _repositoryCategory.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDA_COM_SUCESSO, Texts.CATEGORIA));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoCategory = _repositoryCategory.GetById(id);

            if (repoCategory == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.CATEGORIA));

            var categoryDetails = _mapper.Map<CategoryDetailsModel>(repoCategory);

            return new Result(true, categoryDetails);
        }

        public List<CategoryDetailsModel> List()
        {
            var repoCategorys = _repositoryCategory.List().ToList();
            var categoryDetails = _mapper.Map<List<CategoryDetailsModel>>(repoCategorys);
            return categoryDetails;
        }

        public Result Update(long id, CategoryUpdateModel request)
        {
            try
            {
                var category = _mapper.Map<Category>(request);

                _repositoryCategory.Edit(request);
                _repositoryCategory.Commit();

                var resultObj = _mapper.Map<CategoryDetailsModel>(category);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
