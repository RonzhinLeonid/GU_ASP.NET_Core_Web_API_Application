﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using WebApi_V2.Repository;

namespace WebApi_V2.Validations
{
    public class ClinicCreateResponse : IOperation
    {
        public IReadOnlyList<IOperationFailure> Failures { get; }

        public bool Succeed { get; }

        public ClinicCreateResponse(IReadOnlyList<IOperationFailure> failures, bool succeed)
        {
            Failures = failures;
            Succeed = succeed;
        }
    }
}