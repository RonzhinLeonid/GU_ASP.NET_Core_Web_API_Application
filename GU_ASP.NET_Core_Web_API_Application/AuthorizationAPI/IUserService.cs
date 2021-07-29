using AuthorizationAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI
{
    interface IUserService
    {
        TokenResponse Authenticate(string user, string password);
    }
}
