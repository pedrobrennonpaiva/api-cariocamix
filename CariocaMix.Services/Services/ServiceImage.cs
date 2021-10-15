using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Domain.Models.Image;
using CariocaMix.Domain.Models.Returns;
using CariocaMix.Utils.Resources;
using CariocaMix.Utils.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CariocaMix.Service.Services
{
    public class ServiceImage : IServiceImage
    {
        private readonly IRepositoryImage _repositoryImage;
        private readonly IMapper _mapper;

        public ServiceImage(IRepositoryImage repositoryImage, IMapper mapper)
        {
            _repositoryImage = repositoryImage;
            _mapper = mapper;
        }

        public Result Add(IFormFile file)
        {
            try
            {
                if (file.Length <= 0)
                {
                    return new Result(false, string.Format(Message.OBJETO_X0_E_OBRIGATORIO, Texts.IMAGE));
                }
                else if(!ImageValidator.IsImageFormFile(file))
                {
                    return new Result(false, string.Format(Message.X0_INVALIDA, Texts.IMAGE));
                }

                using var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{file.FileName}";

                ImageAddModel request = new(fileName, file.ContentType, fileBytes);

                var item = _mapper.Map<Image>(request);

                _repositoryImage.Add(item);
                _repositoryImage.Commit();

                var resultObj = _mapper.Map<ImageDetailsModel>(item);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "cadastrar!"));
            }
        }

        public Result GetById(long id)
        {
            var repoImage = _repositoryImage.GetById(id);

            if (repoImage == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));

            var itemDetails = _mapper.Map<ImageDetailsModel>(repoImage);

            return new Result(true, itemDetails);
        }

        public Result GetByName(string name)
        {
            var repoImage = _repositoryImage.GetBy(x => x.Name.Equals(name));

            if (repoImage == null)
                return new Result(false, string.Format(Message.X0_NAO_ENCONTRADO, Texts.ITEM));

            var itemDetails = _mapper.Map<ImageDetailsModel>(repoImage);

            return new Result(true, itemDetails);
        }

        public Result Update(long id, ImageUpdateModel request)
        {
            try
            {
                var item = _mapper.Map<Image>(request);
                item.Id = id;

                _repositoryImage.Edit(item);
                _repositoryImage.Commit();

                var resultObj = _mapper.Map<ImageDetailsModel>(item);

                return new Result(true, resultObj);
            }
            catch (Exception ex)
            {
                return new Result(false, string.Format(Message.OCORREU_UM_ERRO_AO_X0, "atualizar!"));
            }
        }
    }
}
