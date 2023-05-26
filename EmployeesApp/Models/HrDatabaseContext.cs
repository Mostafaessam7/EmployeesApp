using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Models
{
    public class HrDatabaseContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=. ; initial catalog=EmployeesDatabase ; integrated security=SSPI;");
        }


    }
}
