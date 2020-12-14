using ExampleApp.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExampleApp.Context.Context
{
    public class EmployeeContext :  IdentityDbContext<ApplicationUser> 
    {
        private readonly IConfiguration configuration;

        public EmployeeContext(IConfiguration configuration, DbContextOptions<EmployeeContext> options) : base(options)
        {
            this.configuration = configuration;
        }

      
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}
