using demoEmp.Data;
using demoEmp.Model;
using Microsoft.EntityFrameworkCore;

namespace demoEmp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;
        public EmployeeService(EmployeeDbContext context)
        {
            this._context = context;
        }

        public Task<bool> AddEmployee(Employee record)
        {
            _context._Employees.Add(record);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public Task<List<Employee>> GetAllEmployee()
        {
            var result = _context._Employees.ToList();
            return Task.FromResult(result);
        }

        public Employee GetEmployeeById(Guid Id)
        {
            var emp = _context._Employees.Find(Id);
            return emp;
        }

        public Employee RemoveEmployee(Guid Id)
        {
            var emp = _context._Employees.Find(Id);
            _context._Employees.Remove(emp);
            return emp;
        }

        public Task<bool> UpdateEmployee(Employee record)
        {
            var emp = _context._Employees.Update(record);
            return Task.FromResult(true);
        }

      
    }
}
