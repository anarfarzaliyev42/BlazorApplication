using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement_API.Abstractions;
using EmployeeManagement_API.Models;
using EmployeeManagement_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository repository;

        public DepartmentsController(IDepartmentRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await repository.GetDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Retrieving data from database error");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartments(int id)
        {
            try
            {
                var department = await repository.GetDepartment(id);
                if (department == null)
                {
                    return NotFound("Employee not found");
                }
                return Ok(department);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Retrieving data from database error");
            }
        }
    }
}