using Employees_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Employees_Management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          
        }
            
        public DbSet <Employee> Employees { get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet <Designation> Designations { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<SystemCodeDetial> SystemCodeDetial { get; set; }
        public DbSet<SystemCode>  SystemCodes { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Country> Couons { get; set; }
        public DbSet<Ctiy> Ctiy { get; set; }

    }
}
