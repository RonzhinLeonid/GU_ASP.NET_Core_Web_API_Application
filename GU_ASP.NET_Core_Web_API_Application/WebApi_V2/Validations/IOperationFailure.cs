using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Validations
{
    public interface IOperationFailure
    {
        string PropertyName { get; }
        string Description { get; }
        string Code { get; }
    }
}
