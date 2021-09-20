using DataLayer;
using System;
using System.Security.Policy;
using WebApi_V2.DAL;
using WebApi_V2.Validations;
using Xunit;

namespace ValidationTests
{
    
    public class ClinicUpdateValidationTests
    {
        private static readonly FluentValidationService<ClinicUpdRequest> validation = new ClinicUpdateValidation();

        [Fact]
        public void ClinicUpdRequest_IsCorrect()
        {
            var request = new ClinicUpdRequest
            {
                Id = 1,
                Name = "string",
            };
            var actual = validation.ValidateEntity(request);
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public void ClinicUpdRequest_NameCannotBeEmpty()
        {
            var request = new ClinicUpdRequest
            {
                Id = 1
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-101.1", actual.Code);
        }

        [Fact]
        public void ClinicUpdRequest_IdCannotBeEmpty()
        {
            var request = new ClinicUpdRequest
            {
                Name = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-101.21", actual.Code);
        }

        [Fact]
        public void ClinicUpdRequest_IdCannotBeLower_0()
        {
            var request = new ClinicUpdRequest
            {
                Id = -1,
                Name = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-101.22", actual.Code);
        }
    }
}