using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;

namespace WebApi_V2.Validations
{
    public interface IOperationResult<TResult> : IOperation
    {
        TResult Result { get; }
    }

}
