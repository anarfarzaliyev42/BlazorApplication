using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement_API.Abstractions;
using EmployeeManagement_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<List<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var employees = await repository.Search(name, gender);
                if (employees.Any())
                {
                    return employees;
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Retrieving data from database error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await repository.GetEmployees());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Retrieving data from database error");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employee = await repository.GetEmployee(id);
                if (employee == null)
                {
                     return NotFound(); 
                }
                return employee;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Retrieving data from database error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var employeeByEmail = await repository.GetEmployeeByEmail(employee.Email);
                if (employeeByEmail != null)
                {
                    ModelState.AddModelError("Email", "This email is in use");
                    return BadRequest(ModelState);
                }
                var newEmployee= await repository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.EmployeeId }, employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Retrieving data from database error");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id!=employee.EmployeeId)
                {
                    return BadRequest("Invalid employee");
                }
                var employee_ =await repository.GetEmployee(id);
                if (employee == null)
                {
                    return NotFound("Employee not found");
                }
                return await repository.UpdateEmplyee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error during update data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employee_ = await repository.GetEmployee(id);
                if (employee_ == null)
                {
                    return NotFound($"Employee not found with specified id:{id}");
                }
                return await repository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error during update data");
            }
        }
    }

}