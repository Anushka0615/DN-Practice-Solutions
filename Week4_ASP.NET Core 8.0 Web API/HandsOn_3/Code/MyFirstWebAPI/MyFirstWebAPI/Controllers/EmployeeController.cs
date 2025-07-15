using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Filters;
using MyFirstWebAPI.Models;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter]  // 👈 This applies the custom auth filter to all actions in this controller
    public class EmployeeController : ControllerBase
    {
        // Returns hard-coded employee list
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Name = "HR" },
                    Skills = new List<Skill> { new Skill { Name = "Communication" } },
                    DateOfBirth = new DateTime(1990, 5, 15)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department { Name = "Finance" },
                    Skills = new List<Skill> { new Skill { Name = "Accounting" } },
                    DateOfBirth = new DateTime(1985, 7, 20)
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)] // 👈 This tells Swagger the method might return a 500 status
        public ActionResult<List<Employee>> Get()
        {
            // 👇 Simulate an exception to test the CustomExceptionFilter
            throw new Exception("Simulated exception for testing custom exception filter");

            // return Ok(GetStandardEmployeeList()); // This will not be reached due to the exception
        }


        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }
    }
}
