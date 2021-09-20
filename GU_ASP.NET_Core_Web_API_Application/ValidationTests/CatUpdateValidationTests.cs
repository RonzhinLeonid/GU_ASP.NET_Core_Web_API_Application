using DataLayer;
using System;
using System.Security.Policy;
using WebApi_V2.DAL;
using WebApi_V2.Validations;
using Xunit;

namespace ValidationTests
{
    
    public class CatUpdateValidationTests
    {
        private static readonly FluentValidationService<CatUpdRequest> validation = new CatUpdateValidation();
        [Fact]
        public void CatUpdRequest_IsCorrect()
        {
            var request = new CatUpdRequest
            {
                Id = 1,
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
        public void CatUpdRequest_NicknameCannotBeEmpty()
        {
            var request = new CatUpdRequest
            {
                Id = 1,
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
        public void CatUpdRequest_ColorCannotBeEmpty()
        {
            var request = new CatUpdRequest
            {
                Id = 1,
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
        public void CatUpdRequest_FeedCannotBeEmpty()
        {
            var request = new CatUpdRequest
            {
                Id = 1,
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
        public void CatUpdRequest_WeightCannotBeEmpty()
        {
            var request = new CatUpdRequest
            {
                Id = 1,
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
        public void CatUpdRequest_ErrorWeight(int weight, string resul)
        {
            var request = new CatUpdRequest
            {
                Id = 1,
                Nickname = "string",
                Weight = weight,
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal(resul, actual.Code);
        }
        [Fact]
        public void CatUpdRequest_IdCannotBeEmpty()
        {
            var request = new CatUpdRequest
            {
                Nickname = "string",
                Weight = 10,
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-100.51", actual.Code);
        }
        [Fact]
        public void CatUpdRequest_IdCannotBeLower_0()
        {
            var request = new CatUpdRequest
            {
                Id = -1,
                Nickname = "string",
                Weight = 10,
                Color = "string",
                HasCertificate = true,
                Feed = "string"
            };
            var actual = validation.ValidateEntity(request)[0];
            Assert.Equal("BRL-100.52", actual.Code);
        }
    }
}