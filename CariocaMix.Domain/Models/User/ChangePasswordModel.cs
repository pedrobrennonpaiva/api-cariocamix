using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariocaMix.Domain.Models.User
{
    public class ChangePasswordModel
    {
        public long Id { get; set; }

        public string NewPassword { get; set; }
    }
}
