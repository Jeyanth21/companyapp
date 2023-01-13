using CompanyRegistration.Data;
using CompanyRegistration.Models;
using System.Collections.Generic;

namespace CompanyRegistration.Manager
{
    public interface ICdetail
    {
        List<CompanyDetails> Create(CompanyDetailsRequest request);
        List<CompanyDetails> Update(CompanyDetailsRequest request);
        CompanyDetails GetbyId(int UserID);
        List<CompanyDetails> Getall();
        List<CompanyDetails> DeletebyId(int UserID);        
    }
}
