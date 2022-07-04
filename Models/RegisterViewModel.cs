using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj3_Khan.Models
{
    public class RegisterViewModel
    {
        public RegisteredUser UserInfo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ClientInfo { get; set; }
    }
}
