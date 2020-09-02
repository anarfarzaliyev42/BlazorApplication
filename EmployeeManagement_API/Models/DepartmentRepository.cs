using EmployeeManagement_API.Abstractions;
using EmployeeManagement_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_API.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext db;

        public DepartmentRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<Department> GetDepartment(int id)
        {
            return await db.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await db.Departments.ToListAsync();
        }
    }
}
