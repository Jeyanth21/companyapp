using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRegistration.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }
       

        public DbSet<CompanyDetails> Companydetails{get; set;}

        public DbSet<UserDetails> userdetails{ get; set; }
    }
}
