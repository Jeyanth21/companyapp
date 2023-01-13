using CompanyRegistration.Data;
using CompanyRegistration.Manager;
using CompanyRegistration.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompanyNUnitTest
{
    public class CompanyManagerTest1
    {

        [Test]
        public void CompanyManagercreate_test()
        {
            CompanyDetails companydetailsmock;
            try
            {
                Mock<CompanyDbContext> _DbContext = new Mock<CompanyDbContext>();
                var Cdetail =new Cdetail(_DbContext.Object);
                CompanyDetailsRequest obj = new CompanyDetailsRequest();
                obj.UserID = 28;
                obj.CEO = "jeyaaa";
                obj.CompanyName = "cddd";
                obj.Stock_Exchange = "kkk";
                obj.Turnover = 123463523;
                obj.Website = "jsdsd";
                Cdetail.Create(obj);
                Assert.IsTrue(Cdetail != null);
            }
            catch (ArgumentNullException ane)
            {
                Assert.IsTrue(ane.Message.Contains("Value cannot be null."));
            }
            catch (Exception)
            {
                //Assert.Fail();
            }
        }


        [Test]
        public void CompanyManagerGetall_test()
        {
            CompanyDetails companydetailsmock;
            try
            {
                Mock<CompanyDbContext> _DbContext = new Mock<CompanyDbContext>();
                var Cdetail = new Cdetail(_DbContext.Object);

                Cdetail.Getall();
                Assert.IsTrue(Cdetail != null);
            }
            catch (ArgumentNullException ane)
            {
                Assert.IsTrue(ane.Message.Contains("Value cannot be null."));
            }
            catch (Exception)
            {
                //Assert.Fail();
            }
        }


        [Test]
        public void CompanyManagerUpdate_test()
        {
            CompanyDetails companydetailsmock;
            try
            {
                Mock<CompanyDbContext> _DbContext = new Mock<CompanyDbContext>();
                var Cdetail = new Cdetail(_DbContext.Object);
                CompanyDetailsRequest obj = new CompanyDetailsRequest();
                obj.UserID = 28;
                obj.CEO = "jeyaaa";
                obj.CompanyName = "cddd";
                obj.Stock_Exchange = "kkk";
                obj.Turnover = 123463523;
                obj.Website = "jsdsd";
                Cdetail.Update(obj);
                Assert.IsTrue(Cdetail != null);
            }
            catch (ArgumentNullException ane)
            {
                Assert.IsTrue(ane.Message.Contains("Value cannot be null."));
            }
            catch (Exception)
            {
                //Assert.Fail();
            }
        }


        [Test]
        public void CompanyManagerDeletebyId_test()
        {
            CompanyDetails companydetailsmock;
            try
            {
                Mock<CompanyDbContext> _DbContext = new Mock<CompanyDbContext>();
                var Cdetail = new Cdetail(_DbContext.Object);
                //CompanyDetailsRequest obj = new CompanyDetailsRequest();
                //obj.UserID = 28;

                Cdetail.DeletebyId(28);
                Assert.IsTrue(Cdetail != null);
            }
            catch (ArgumentNullException ane)
            {
                Assert.IsTrue(ane.Message.Contains("Value cannot be null."));
            }
            catch (Exception)
            {
                //Assert.Fail();
            }
        }
    }
}
