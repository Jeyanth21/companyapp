using System;
using System.Collections.Generic;
using CompanyRegistration.Controllers;
using CompanyRegistration.Manager;
using NUnit.Framework;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CompanyRegistration.Data;
using CompanyRegistration.Models;

namespace TestProject.ControllerTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CompanyDetailsTests
    {
        public Mock<ICdetail> CdetailMock;
        List<CompanyDetails> companydetailsMock;
        [SetUp]
        public void Setup()
        {
            CdetailMock = new Mock<ICdetail>();
            companydetailsMock = new List<CompanyDetails>();
            companydetailsMock.Add(new CompanyDetails() { Id = 99, CompanyName = "bingo", CEO = "april", Turnover = 1223334444, Stock_Exchange = "ABC", Website = "bingo.com" });
        }

        [Test, Category("Company_DetailsController")]
        public void Get_Success()
        {            
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();            
            CompanydetailsManagerMock.Setup(x => x.Getall()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Get();
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }

        [Test, Category("Company_DetailsController")]
        public void Get_Error()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanydetailsManagerMock.Setup(x => x.Getall()).Throws(new Exception()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Get();
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(500, content.StatusCode);
        }

        [Test, Category("Company_DetailsController")]
        public void getbyId_success()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            CompanydetailsManagerMock.Setup(x => x.GetbyId(obj.UserID)).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Get(obj.UserID);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }
        [Test, Category("Company_DetailsController")]
        public void getbyId_error()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            CompanydetailsManagerMock.Setup(x => x.GetbyId(obj.UserID)).Throws(new Exception()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Get(obj.UserID);
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(500, content.StatusCode);
        }
        [Test,Category("Company_DetailsController")]

        public void Create_Success()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            obj.CEO = "jeyaaa";
            obj.CompanyName = "cddd";
            obj.Stock_Exchange = "kkk";
            obj.Turnover = 123463523;
            obj.Website = "jsdsd";
            CompanydetailsManagerMock.Setup(x => x.Create(obj)).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Create(obj);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }
        [Test, Category("Company_DetailsController")]
        public void Create_errors()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            obj.CEO = "jeyaaa";
            obj.CompanyName = "cddd";
            obj.Stock_Exchange = "kkk";
            obj.Turnover = 123463523;
            obj.Website = "jsdsd";
            CompanydetailsManagerMock.Setup(x => x.Create(obj)).Throws(new Exception()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Create(obj);
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(500, content.StatusCode);
        }

        [Test, Category("Company_DetailsController")]
             public void Update_Success()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            obj.CEO = "jeyaaa";
            obj.CompanyName = "cddd";
            obj.Stock_Exchange = "kkk";
            obj.Turnover = 123463523;
            obj.Website = "jsdsd";
            CompanydetailsManagerMock.Setup(x => x.Update(obj)).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Update(obj);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }

        [Test, Category("Company_DetailsController")]
        public void Update_error()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            obj.CEO = "jeyaaa";
            obj.CompanyName = "cddd";
            obj.Stock_Exchange = "kkk";
            obj.Turnover = 123463523;
            obj.Website = "jsdsd";
            CompanydetailsManagerMock.Setup(x => x.Update(obj)).Throws(new Exception()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Update(obj);
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(500, content.StatusCode);
        }


        [Test, Category("Company_DetailsController")]
             public void deletebyId_Success()
        {

            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            CompanydetailsManagerMock.Setup(x => x.DeletebyId(obj.UserID)).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Delete(obj.UserID);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }

        [Test, Category("Company_DetailsController")]
        public void deletebyId_error()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
            CompanyDetailsRequest obj = new CompanyDetailsRequest();
            obj.UserID = 28;
            obj.CEO = "jeyaaa";
            obj.CompanyName = "cddd";
            obj.Stock_Exchange = "kkk";
            obj.Turnover = 123463523;
            obj.Website = "jsdsd";
            CompanydetailsManagerMock.Setup(x => x.DeletebyId(obj.UserID)).Throws(new Exception()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);
            var result = CompanydetailsManager.Delete(obj.UserID);
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(500, content.StatusCode);

        }
    }
}
        
    

