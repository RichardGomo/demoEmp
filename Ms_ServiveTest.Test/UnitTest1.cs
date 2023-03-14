using Bogus;
using Bogus.DataSets;
using demoEmp.Data;
using demoEmp.Model;
using demoEmp.Service;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace Ms_ServiveTest.Test
{

    [TestClass]
    public class UnitTest1
    {
        List<Employee> stub;
        IEmployeeService employeeService;

        [TestInitialize]
        public async Task Init()
        {
            stub = GenerateData(1);
            var data = stub.AsQueryable(); //5. so am going to use the data as querable type
            var mockEmployeeDbContext = new Mock<EmployeeDbContext>(); // 1. Mock of DbContext
            var mockSet = new Mock<DbSet<Employee>>(); // 3. Mock DbSet
            // 4. any query running on the DbSet, should return a Quarable of Employee type
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockEmployeeDbContext.Setup(x => x._Employees).Returns(mockSet.Object); //2. using setup method to setup DbContext (which requires a return of a dbset model)

            mockEmployeeDbContext.Setup(x => x.SaveChanges()).Returns(1);

            // Create an instance of our Repo
            employeeService = new EmployeeService(mockEmployeeDbContext.Object);
            

        }

        [TestMethod]
        [Priority(1)]
        public async Task addNewEmployee()
        {
            var response = await employeeService.AddEmployee(stub.FirstOrDefault());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [Priority(2)]
        public void UpdateAddess_Test()
        {
            var employee = stub.FirstOrDefault();
            var response = employeeService.UpdateEmployee(employee);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [Priority(3)]
        public void RemoveAddress_Test()
        {
            var address = stub.FirstOrDefault().Id;
            var response = employeeService.RemoveEmployee(address);
            Assert.IsNull(response);
        }

        [TestMethod]
        [Priority(4)]
        public void GetAllAddress_Test()
        {
            var response = employeeService.GetAllEmployee();
            Assert.IsNotNull(response);
        }

        //0. Created a sample method using faker with the help of bogus library
        private List<Employee> GenerateData(int count)
        { 
            var faker = new Faker<Employee>()
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Phone, f => f.Person.Phone)
                .RuleFor(c => c.DateOfStart, f => f.Person.DateOfBirth)
                .RuleFor(c => c.Id, new Guid("cfe31585-48fd-41b2-b1f8-e80510619552"));

            return faker.Generate(count);

        }
    }
}