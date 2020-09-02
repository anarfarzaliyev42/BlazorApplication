using EmployeeManagement_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Departments Table
            
            modelBuilder.Entity<Department>().HasData
                (
                new Department { DepartmentId = 1, Name = "IT" },
                new Department { DepartmentId = 2, Name = "HR" },
                new Department { DepartmentId = 3, Name = "Payroll" },
                new Department { DepartmentId = 4, Name = "Admin" }
                );
            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Blue",
                    Email = "David@gmail.com",
                    DateOfBirth = new DateTime(2000, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/john.png"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sam",
                    LastName = "Brown",
                    Email = "Sam@gmail.com",
                    DateOfBirth = new DateTime(2000, 12, 22),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/sam.jpg"
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Mary",
                    LastName = "Smith",
                    Email = "mary@gmail.com",
                    DateOfBirth = new DateTime(2000, 11, 11),
                    Gender = Gender.Female,
                    DepartmentId = 1,
                    PhotoPath = "images/mary.png"
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Sara",
                    LastName = "Green",
                    Email = "sara@gmail.com",
                    DateOfBirth = new DateTime(2000, 9, 23),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/sara.png"
                });

        }
    }
}
