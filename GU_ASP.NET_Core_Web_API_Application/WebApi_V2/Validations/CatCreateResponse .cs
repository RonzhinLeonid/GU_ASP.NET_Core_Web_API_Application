using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using WebApi_V2.Repository;

namespace WebApi_V2.Validations
{
    public class CatCreateResponse : IOperation
    {
        public IReadOnlyList<IOperationFailure> Failures { get; }

        public bool Succeed { get; }

        public CatCreateResponse(IReadOnlyList<IOperationFailure> failures, bool succeed)
        {
            Failures = failures;
            Succeed = succeed;
        }
    }
}
