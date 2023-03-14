using demoEmp.Model;
using Microsoft.EntityFrameworkCore;

namespace demoEmp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {

        }

        public virtual DbSet<Employee> _Employees { get; set; }
    }
}
