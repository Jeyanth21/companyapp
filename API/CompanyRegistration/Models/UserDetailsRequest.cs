using System.ComponentModel.DataAnnotations;

namespace CompanyRegistration.Models
{
    public class UserDetailsRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
    }
}
