using AuthorizationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using WebApi_V2.Repository;
using FluentValidation;

namespace WebApi_V2.Validations
{
    public class ClinicCreateValidation : FluentValidationService<ClinicRequest>, IClinicCreateValidation
    {
        public ClinicCreateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Наименование клиники не может быть пустым")
                .WithErrorCode("BRL-101.1");
        }
    }
}
