using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
