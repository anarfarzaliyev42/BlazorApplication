using EmployeeManagement_Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient client;

        public EmployeeService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await client.PostJsonAsync<Employee>($"api/employees", employee);
        }

        public async Task DeleteEmployee(int id)
        {
             await client.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> EditEmployee(Employee employee)
        {
            return await client.PutJsonAsync<Employee>($"api/employees/{employee.EmployeeId}",employee);
        }

        public async Task<Employee> GetEmployee(int id)
         {
            return await client.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<List<Employee>> GetEmployees()
        {

            return await client.GetJsonAsync<List<Employee>>("api/employees");
        }
    }
}
