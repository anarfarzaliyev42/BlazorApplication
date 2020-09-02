using EmployeeManagement_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> EditEmployee(Employee employee);
        Task<Employee> AddEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
