using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.StoreDayHour;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Services
{
    public class ServiceStoreDayHour : IServiceStoreDayHour
    {
        private readonly IRepositoryStoreDayHour _repositoryStoreDayHour;
        private readonly IMapper _mapper;

        public ServiceStoreDayHour(IRepositoryStoreDayHour repositoryStoreDayHour, IMapper mapper)
        {
            _repositoryStoreDayHour = repositoryStoreDayHour;
            _mapper = mapper;
        }

        public Result Add(StoreDayHourAddModel request)
        {
            try
            {
                var storeDayHour = _mapper.Map<StoreDayHour>(request);

                _repositoryStoreDayHour.Add(storeDayHour);
                _repositoryStoreDayHour.Commit();

                var resultObj = _mapper.Map<StoreDayHourDetailsModel>(storeDayHour);

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
                StoreDayHour storeDayHour = _repositoryStoreDayHour.GetById(id);

                if (storeDayHour == null)
                {
                    return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.LOJA));
                }

                _repositoryStoreDayHour.Remove(storeDayHour);
                _repositoryStoreDayHour.Commit();

                return new Result(true, string.Format(Message.X0_EXCLUIDA_COM_SUCESSO, Texts.LOJA));
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "excluir!"));
            }
        }

        public Result GetById(long id)
        {
            var repoStoreDayHour = _repositoryStoreDayHour.GetById(id);

            if (repoStoreDayHour == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADA, Texts.LOJA));

            var storeDayHourDetails = _mapper.Map<StoreDayHourDetailsModel>(repoStoreDayHour);

            return new Result(true, storeDayHourDetails);
        }

        public List<StoreDayHourDetailsModel> List()
        {
            var repoStoreDayHours = _repositoryStoreDayHour.List().ToList();
            var storeDayHourDetails = _mapper.Map<List<StoreDayHourDetailsModel>>(repoStoreDayHours);
            return storeDayHourDetails;
        }

        public Result Update(long id, StoreDayHourUpdateModel request)
        {
            try
            {
                var storeDayHour = _mapper.Map<StoreDayHour>(request);
                storeDayHour.Id = id;

                _repositoryStoreDayHour.Edit(storeDayHour);
                _repositoryStoreDayHour.Commit();

                var resultObj = _mapper.Map<StoreDayHourDetailsModel>(storeDayHour);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
