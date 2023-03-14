using demoEmp.Model;
using demoEmp.Service;
using Microsoft.AspNetCore.Mvc;

namespace demoEmp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            this.employeeService = _employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployee(Guid Id) 
        { 
            var result = employeeService.GetEmployeeById(Id);
            return Ok(result);
        }

        public IActionResult AddNew(Employee emp)
        {
            var response = employeeService.AddEmployee(emp);
            return Ok(response);
        }

        public IActionResult GetAllEmployee()
        {
            var response = employeeService.GetAllEmployee();
            return Ok(response);
        }

        public IActionResult UpdateEmployee(Employee employee)
        {
            var response = employeeService.UpdateEmployee(employee);
            return Ok(response);
        }

        public IActionResult RemoveEmployee(Guid EmpId)
        {
            var response = employeeService.RemoveEmployee(EmpId);
            return Ok(response);
        }
    }
}
