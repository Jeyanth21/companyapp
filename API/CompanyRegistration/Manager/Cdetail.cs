using CompanyRegistration.Data;
using CompanyRegistration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CompanyRegistration.Manager
{
    public class Cdetail : ICdetail
    {

        private CompanyDbContext _dbcontext;

        public Cdetail(CompanyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<CompanyDetails> Create(CompanyDetailsRequest request)
        {

            var existingCompany = _dbcontext.Companydetails
                                     .FirstOrDefault(x => x.CompanyName == request.CompanyName);
            if (existingCompany != null)
            {
                throw new Exception("Company name already in use.");
            }
            try
            {
            CompanyDetails companydetail = new CompanyDetails();
            companydetail.UserID = request.UserID;
            companydetail.CompanyName = request.CompanyName;
            companydetail.CEO = request.CEO;
            companydetail.Turnover = request.Turnover;
            companydetail.Website = request.Website;
            companydetail.Stock_Exchange = request.Stock_Exchange;
            _dbcontext.Companydetails.Add(companydetail);
            _dbcontext.SaveChanges();
            var companydetails = _dbcontext.Companydetails.ToList();
            return _dbcontext.Companydetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("errorr ");
            }
        }
    

        public List<CompanyDetails> Update(CompanyDetailsRequest request)
        {
            try
            {
                

                CompanyDetails companydetail = new CompanyDetails();
                var companydetaill = _dbcontext.Companydetails.FirstOrDefault(x => x.UserID == request.UserID);
                if (companydetaill == null)
                {
                    throw new Exception("No company detail was found with the specified ID");
                }
               
                companydetaill.UserID = request.UserID;
                companydetaill.CompanyName = request.CompanyName;
                companydetaill.CEO = request.CEO;
                companydetaill.Turnover = request.Turnover;
                companydetaill.Website = request.Website;
                companydetaill.Stock_Exchange = request.Stock_Exchange;
                _dbcontext.Entry(companydetaill).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                var companydetails = _dbcontext.Companydetails.ToList();
                return _dbcontext.Companydetails.ToList();

                
            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while processing your request");
            }
        }
       





        

    public List<CompanyDetails> Getall()
        {
            string storepro = "exec sp_Company_detailss";
                 var companydetails = _dbcontext.Companydetails.FromSqlRaw(storepro).ToList();           
                 return companydetails;
        }

        public CompanyDetails GetbyId (int UserID)
        {
            var companydetaill = _dbcontext.Companydetails.FirstOrDefault(x => x.UserID == UserID);
            return companydetaill;
        }

       public List<CompanyDetails> DeletebyId(int UserID)
        {
            var companydetaill = _dbcontext.Companydetails.FirstOrDefault(x => x.UserID == UserID);    
            _dbcontext.Entry(companydetaill).State = EntityState.Deleted;
            _dbcontext.SaveChanges();
            var companydetails = _dbcontext.Companydetails.ToList();
            return companydetails;
        }
    }
}
