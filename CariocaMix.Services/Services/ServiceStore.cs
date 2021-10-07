using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Store;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceStore : IServiceStore
    {
        private readonly IRepositoryStore _repositoryStore;
        private readonly IMapper _mapper;

        public ServiceStore(IRepositoryStore repositoryStore, IMapper mapper)
        {
            _repositoryStore = repositoryStore;
            _mapper = mapper;
        }

        public Result Add(StoreAddModel request)
        {
            try
            {
                var store = _mapper.Map<Store>(request);

                _repositoryStore.Add(store);
                _repositoryStore.Commit();

                var resultObj = _mapper.Map<StoreDetailsModel>(store);

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
                Store store = _repositoryStore.GetById(id);

                if (store == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.LOJA));
                }

                _repositoryStore.Remove(store);
                _repositoryStore.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDA_COM_SUCESSO, Texts.LOJA));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoStore = _repositoryStore.GetById(id);

            if (repoStore == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.LOJA));

            var storeDetails = _mapper.Map<StoreDetailsModel>(repoStore);

            return new Result(true, storeDetails);
        }

        public List<StoreDetailsModel> List()
        {
            var repoStores = _repositoryStore.List().ToList();
            var storeDetails = _mapper.Map<List<StoreDetailsModel>>(repoStores);
            return storeDetails;
        }

        public Result Update(long id, StoreUpdateModel request)
        {
            try
            {
                var store = _mapper.Map<Store>(request);
                store.Id = id;

                _repositoryStore.Edit(store);
                _repositoryStore.Commit();

                var resultObj = _mapper.Map<StoreDetailsModel>(store);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
