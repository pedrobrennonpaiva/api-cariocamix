using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.AddressStore;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceAddressStore : IServiceAddressStore
    {
        private readonly IRepositoryAddressStore _repositoryAddressStore;
        private readonly IMapper _mapper;

        public ServiceAddressStore(IRepositoryAddressStore repositoryAddressStore, IMapper mapper)
        {
            _repositoryAddressStore = repositoryAddressStore;
            _mapper = mapper;
        }

        public Result Add(AddressStoreAddModel request)
        {
            try
            {
                var addressStore = _mapper.Map<AddressStore>(request);

                _repositoryAddressStore.Add(addressStore);
                _repositoryAddressStore.Commit();

                var resultObj = _mapper.Map<AddressStoreDetailsModel>(addressStore);

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
                AddressStore addressStore = _repositoryAddressStore.GetById(id);

                if (addressStore == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ENDERECO));
                }

                _repositoryAddressStore.Remove(addressStore);
                _repositoryAddressStore.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.ENDERECO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoAddressStore = _repositoryAddressStore.GetById(id);

            if (repoAddressStore == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ENDERECO));

            var addressStoreDetails = _mapper.Map<AddressStoreDetailsModel>(repoAddressStore);

            return new Result(true, addressStoreDetails);
        }

        public List<AddressStoreDetailsModel> List()
        {
            var repoAddressStores = _repositoryAddressStore.List().ToList();
            var addressStoreDetails = _mapper.Map<List<AddressStoreDetailsModel>>(repoAddressStores);
            return addressStoreDetails;
        }

        public Result Update(long id, AddressStoreUpdateModel request)
        {
            try
            {
                var addressStore = _mapper.Map<AddressStore>(request);
                addressStore.Id = id;

                _repositoryAddressStore.Edit(addressStore);
                _repositoryAddressStore.Commit();

                var resultObj = _mapper.Map<AddressStoreDetailsModel>(addressStore);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
