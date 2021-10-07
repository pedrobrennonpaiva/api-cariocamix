using System;
using System.ComponentModel.DataAnnotations;

namespace CariocaMix.Domain.Entities.Base
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            RegisterDate = DateTime.Now;
        }

        public long Id { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
