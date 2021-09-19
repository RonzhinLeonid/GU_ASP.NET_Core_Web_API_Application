using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Validations
{
    public class CatUpdateResponse : IOperation
    {
        public IReadOnlyList<IOperationFailure> Failures { get; }

        public bool Succeed { get; }

        public CatUpdateResponse(IReadOnlyList<IOperationFailure> failures, bool succeed)
        {
            Failures = failures;
            Succeed = succeed;
        }
    }
}
