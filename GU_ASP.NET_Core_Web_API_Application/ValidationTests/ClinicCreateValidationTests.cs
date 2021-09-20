using DataLayer;
using System;
using System.Security.Policy;
using WebApi_V2.DAL;
using WebApi_V2.Validations;
using Xunit;

namespace ValidationTests
{
    
    public class ClinicCreateValidationTests
    {
        private static readonly FluentValidationService<ClinicRequest> validation = new ClinicCreateValidation();

        [Fact]
        public void ClinicRequest_IsCorrect()
        {
            var request = new ClinicRequest
            {
                Name = "string",
            };
            var actual = validation.ValidateEntity(request);
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public void ClinicRequest_NameCannotBeEmpty()
        {
            var request = new ClinicRequest
            {

            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-101.1", actual.Code);
        }
    }
}