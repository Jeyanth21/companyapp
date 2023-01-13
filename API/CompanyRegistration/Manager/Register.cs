using CompanyRegistration.Data;
using CompanyRegistration.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace CompanyRegistration.Manager
{
    public class Register : IRegister
    {
        private CompanyDbContext _dbcontext;
        public Register(CompanyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<UserDetails>  Create(UserDetailsRequest request)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request);
            if (!Validator.TryValidateObject(request, context, results, true))
            {
               
                throw new ValidationException();
            }
            UserDetails userDetails = new UserDetails();
            {
                userDetails.Id = request.Id;
                userDetails.UserName = request.UserName;
                userDetails.Email = request.Email;
                userDetails.Password = request.Password;
                _dbcontext.userdetails.Add(userDetails);
                _dbcontext.SaveChanges();      
                return _dbcontext.userdetails.ToList();
            }
        }

        public UserDetails Getlogin(string Email, string Password)

        {
        


            var userdetails = _dbcontext.userdetails.Where(x => x.Email == Email && x.Password==Password).SingleOrDefault();                    
            return userdetails;
        }       
    }
}
