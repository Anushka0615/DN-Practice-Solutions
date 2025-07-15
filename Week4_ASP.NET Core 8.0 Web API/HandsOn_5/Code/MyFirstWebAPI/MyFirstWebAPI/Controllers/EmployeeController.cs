using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Filters;
using MyFirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,POC")] // 👈 Only Admin or POC can access
    public class EmployeeController : ControllerBase
    {
        // Static in-memory employee list
        private static List<Employee> employeeList = new List<Employee>
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

        // GET: api/employee
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            // Uncomment next line to test exception filter
            // throw new Exception("Simulated exception for testing");

            return Ok(employeeList);
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employee.Id = employeeList.Max(e => e.Id) + 1;
            employeeList.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT: api/employee/1
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = employeeList.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update fields
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.Permanent = updatedEmployee.Permanent;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Skills = updatedEmployee.Skills;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(existingEmployee);
        }
    }
}
