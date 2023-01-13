using System.Collections.Generic;
using CompanyRegistration.Data;
using CompanyRegistration.Models;

namespace CompanyRegistration.Manager
{
   public interface IRegister
    {
      List<UserDetails> Create(UserDetailsRequest request);
        UserDetails Getlogin(string Email, string Password);
    }
}
