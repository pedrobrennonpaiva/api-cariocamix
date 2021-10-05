using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Item;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceItem : IServiceItem
    {
        private readonly IRepositoryItem _repositoryItem;
        private readonly IMapper _mapper;

        public ServiceItem(IRepositoryItem repositoryItem, IMapper mapper)
        {
            _repositoryItem = repositoryItem;
            _mapper = mapper;
        }

        public Result Add(ItemAddModel request)
        {
            try
            {
                var item = _mapper.Map<Item>(request);

                _repositoryItem.Add(request);
                _repositoryItem.Commit();

                var resultObj = _mapper.Map<ItemDetailsModel>(item);

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
                Item item = _repositoryItem.GetById(id);

                if (item == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));
                }

                _repositoryItem.Remove(item);
                _repositoryItem.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDO_COM_SUCESSO, Texts.ITEM));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoItem = _repositoryItem.GetById(id);

            if (repoItem == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));

            var itemDetails = _mapper.Map<ItemDetailsModel>(repoItem);

            return new Result(true, itemDetails);
        }

        public List<ItemDetailsModel> List()
        {
            var repoItems = _repositoryItem.List().ToList();
            var itemDetails = _mapper.Map<List<ItemDetailsModel>>(repoItems);
            return itemDetails;
        }

        public Result Update(ItemUpdateModel request)
        {
            try
            {
                var item = _mapper.Map<Item>(request);

                _repositoryItem.Edit(request);
                _repositoryItem.Commit();

                var resultObj = _mapper.Map<ItemDetailsModel>(item);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
