using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Address;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceAddress : IServiceAddress
    {
        private readonly IRepositoryAddress _repositoryAddress;
        private readonly IMapper _mapper;

        public ServiceAddress(IRepositoryAddress repositoryAddress, IMapper mapper)
        {
            _repositoryAddress = repositoryAddress;
            _mapper = mapper;
        }

        public Result Add(AddressAddModel request)
        {
            try
            {
                var address = _mapper.Map<Address>(request);

                _repositoryAddress.Add(request);
                _repositoryAddress.Commit();

                var resultObj = _mapper.Map<AddressDetailsModel>(address);

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
                Address address = _repositoryAddress.GetById(id);

                if (address == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ENDERECO));
                }

                _repositoryAddress.Remove(address);
                _repositoryAddress.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.ENDERECO));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoAddress = _repositoryAddress.GetById(id);

            if (repoAddress == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ENDERECO));

            var addressDetails = _mapper.Map<AddressDetailsModel>(repoAddress);

            return new Result(true, addressDetails);
        }

        public List<AddressDetailsModel> List()
        {
            var repoAddresss = _repositoryAddress.List().ToList();
            var addressDetails = _mapper.Map<List<AddressDetailsModel>>(repoAddresss);
            return addressDetails;
        }

        public Result Update(long id, AddressUpdateModel request)
        {
            try
            {
                var address = _mapper.Map<Address>(request);

                _repositoryAddress.Edit(request);
                _repositoryAddress.Commit();

                var resultObj = _mapper.Map<AddressDetailsModel>(address);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
