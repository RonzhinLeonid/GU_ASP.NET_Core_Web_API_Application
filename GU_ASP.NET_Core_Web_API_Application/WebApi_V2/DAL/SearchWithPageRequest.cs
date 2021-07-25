using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.DAL
{
    public class SearchWithPageRequest
    {
        public string Nickname { get; init; }
        public int Page { get; init; }
        public int Size { get; init; }
    }
}
