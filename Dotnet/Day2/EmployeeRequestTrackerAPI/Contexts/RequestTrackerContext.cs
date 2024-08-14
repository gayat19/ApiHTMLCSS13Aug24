using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext:DbContext
    {
        public RequestTrackerContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee>   Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { 
                    Id=101,
                    Name="Ramu",
                    DateOfBirth = new DateTime(2000,12,25),
                    Phone = 9876543210,
                    Email = "ramu@gmail.com"
                });
        }
    }
}
