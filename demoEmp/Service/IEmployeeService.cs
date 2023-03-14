using demoEmp.Model;

namespace demoEmp.Service
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployee(Employee record);
        Task<bool> UpdateEmployee(Employee record);
        Task<List<Employee>> GetAllEmployee();
        Employee RemoveEmployee(Guid Id);
        Employee GetEmployeeById(Guid Id);

    }
}
