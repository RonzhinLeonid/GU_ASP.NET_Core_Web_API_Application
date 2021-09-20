using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.Repository;

namespace WebApi_V2.Validations
{
    public sealed class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }
}
