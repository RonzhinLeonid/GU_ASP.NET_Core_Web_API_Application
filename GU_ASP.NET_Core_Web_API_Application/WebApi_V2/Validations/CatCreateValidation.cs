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
    public class CatCreateValidation : FluentValidationService<CatRequest>, ICatCreateValidation
    {
        public CatCreateValidation()
        {
            RuleFor(x => x.Nickname)
                .NotEmpty()
                .WithMessage("Кличка не должна быть пустой")
                .WithErrorCode("BRL-100.1");

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("Окрас не долден быть пустым")
                .WithErrorCode("BRL-100.2");

            RuleFor(x => x.Feed)
                .NotEmpty()
                .WithMessage("Корм не должен быть пустым")
                .WithErrorCode("BRL-100.3");

            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Вес не должен быть пустым").WithErrorCode("BRL-100.41")
                .GreaterThan(0).WithMessage("Вес не может быть меньше 0").WithErrorCode("BRL-100.42")
                .LessThan(30).WithMessage("Таких упитанных котиков не бывает").WithErrorCode("BRL-100.43");
        }
    }
}
