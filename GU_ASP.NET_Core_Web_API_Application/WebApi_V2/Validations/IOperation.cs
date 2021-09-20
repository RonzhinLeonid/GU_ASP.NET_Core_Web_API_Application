using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.Repository;

namespace WebApi_V2.Validations
{
    public interface IOperation
    {
        IReadOnlyList<IOperationFailure> Failures { get; }

        bool Succeed { get; }
    }
}
