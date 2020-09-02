using EmployeeManagement_API.Abstractions;
using EmployeeManagement_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_API.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result=await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await db.Employees
                .Include(e=>e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await db.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<List<Employee>> Search(string name, Gender? gender)
        {
            List<Employee> employees =await db.Employees.ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                employees = employees.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name)).ToList();
            }
            if (gender != null)
            {
                employees = employees.Where(e => e.Gender == gender).ToList();
            }
            return employees;
        }

        public async Task<Employee> UpdateEmplyee(Employee employee)
        {
            var employee_ = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (employee_ != null)
            {
                employee_.FirstName = employee.FirstName;
                employee_.LastName = employee.LastName;
                employee_.Email = employee.Email;
                employee_.DateOfBirth = employee.DateOfBirth;
                employee_.Gender = employee.Gender;
                employee_.DepartmentId = employee.DepartmentId;
                employee_.PhotoPath = employee.PhotoPath;
                await db.SaveChangesAsync();
                return employee_;
            }
            return null;
        }
    }
}
