using DataLayer;
using System;
using System.Security.Policy;
using WebApi_V2.DAL;
using WebApi_V2.Validations;
using Xunit;

namespace ValidationTests
{
    
    public class CatCreateValidationTests
    {
        private static readonly FluentValidationService<CatRequest> validation = new CatCreateValidation();
        [Fact]
        public void CatRequest_IsCorrect()
        {
            var request = new CatRequest
            {
                Nickname = "string",
                Weight = 10,
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request);
            Assert.Equal(0, actual.Count);
        }
        [Fact]
        public void CatRequest_NicknameCannotBeEmpty()
        {
            var request = new CatRequest
            {
                Nickname = "",
                Weight = 10,
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-100.1", actual.Code);
        }
        [Fact]
        public void CatRequest_ColorCannotBeEmpty()
        {
            var request = new CatRequest
            {
                Nickname = "string",
                Weight = 10,
                Color = "",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-100.2", actual.Code);
        }
        [Fact]
        public void CatRequest_FeedCannotBeEmpty()
        {
            var request = new CatRequest
            {
                Nickname = "string",
                Weight = 10,
                Color = "string",
                HasCertificate = true,
                Feed = ""
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-100.3", actual.Code);
        }
        [Fact]
        public void CatRequest_WeightCannotBeEmpty()
        {
            var request = new CatRequest
            {
                Nickname = "string",
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-100.41", actual.Code);
        }

        [Theory]
        [InlineData(-1, "BRL-100.42")]
        [InlineData(70, "BRL-100.43")]
        public void CatRequest_ErrorWeight(int weight, string resul)
        {
            var request = new CatRequest
            {
                Nickname = "string",
                Weight = weight,
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal(resul, actual.Code);
        }
    }
}