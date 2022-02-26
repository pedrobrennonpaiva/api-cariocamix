using CariocaMix.Domain.Models.ReturnMessage;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Service.Extensions
{
    public static class ModelStateExtensions
    {
        public static ReturnMessageResponse GetReturnMessageResponse(this ModelStateDictionary modelState, string message)
        {
            var errors = modelState
                            .Values
                            .Where(x => x.Errors.Count > 0)
                            .SelectMany(y => y.Errors)
                            .Where(w => ObjectSerialize(w.ErrorMessage))
                            .Select(z => ReturnObjectSerialize(z.ErrorMessage))
                            .ToList();

            return new ReturnMessageResponse(false, errors);
        }

        public static ReturnMessageResponse GetDataExtensionsErrorsMessage(this ModelStateDictionary modelState, string message)
        {
            var fieldsWithError = string.Join('|', modelState.Keys);

            var errors = new List<ReturnMessage>()
            {
                new ReturnMessage(9999, $"Campos com formatos inválidos: {fieldsWithError}")
            };

            return new ReturnMessageResponse(false, errors);
        }

        private static ReturnMessage ReturnObjectSerialize(string message)
        {
            try
            {
                return JsonConvert.DeserializeObject<ReturnMessage>(message);
            }
            catch
            {
                return new ReturnMessage(0, message);
            }
        }

        private static bool ObjectSerialize(string message)
        {
            try
            {
                var serializa = JsonConvert.DeserializeObject<ReturnMessage>(message);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
