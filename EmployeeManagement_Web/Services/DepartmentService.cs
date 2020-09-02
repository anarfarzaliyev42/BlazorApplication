using EmployeeManagement_Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient client;

        public DepartmentService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<Department> GetDepartment(int id)
        {
            return await client.GetJsonAsync<Department>($"api/departments/{id}");
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await client.GetJsonAsync<List<Department>>($"api/departments");
        }
    }
}
