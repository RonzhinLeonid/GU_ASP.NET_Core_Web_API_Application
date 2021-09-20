using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Validations
{
    public class ClinicUpdateResponse : IOperation
    {
        public IReadOnlyList<IOperationFailure> Failures { get; }

        public bool Succeed { get; }

        public ClinicUpdateResponse(IReadOnlyList<IOperationFailure> failures, bool succeed)
        {
            Failures = failures;
            Succeed = succeed;
        }
    }
}
