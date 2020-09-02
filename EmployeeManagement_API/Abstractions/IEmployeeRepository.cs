using EmployeeManagement_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_API.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> Search(string name,Gender? gender);
        Task<Employee> GetEmployee(int id);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmplyee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
