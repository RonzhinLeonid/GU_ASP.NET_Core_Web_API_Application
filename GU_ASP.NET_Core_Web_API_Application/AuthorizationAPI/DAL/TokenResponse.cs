using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.DAL
{
    public sealed class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
