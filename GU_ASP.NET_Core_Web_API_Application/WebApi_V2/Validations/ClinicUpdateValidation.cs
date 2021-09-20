using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using FluentValidation;


namespace WebApi_V2.Validations
{
    public class ClinicUpdateValidation : FluentValidationService<ClinicUpdRequest>, IClinicUpdateValidation
    {
        public ClinicUpdateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Наименование клиники не может быть пустым")
                .WithErrorCode("BRL-101.1");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id не должен быть пустой")
                .WithErrorCode("BRL-101.21")
                .GreaterThan(0)
                .WithMessage("Id не может быть меньше 0")
                .WithErrorCode("BRL-101.22");
        }
    }
}
