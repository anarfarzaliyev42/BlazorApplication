using AutoMapper;
using Company.Components;
using EmployeeManagement_Models;
using EmployeeManagement_Web.Models;
using EmployeeManagement_Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Pages
{
    public class EditEmployeeBase:ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        public List<Department> Departments { get; set; } = new List<Department>();
        public string PageHeaderText { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        public ConfirmBase DeleteConfirmation { get; set; }

        protected void DeleteEmployee()
        {
            DeleteConfirmation.Show();

        }
        protected async Task ConfirmDelete(bool isConfirmed)
        {
            if (isConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
        }
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee =await EmployeeService.GetEmployee(int.Parse(Id));

            }
            else
            {
                PageHeaderText = "Add Employee";
                Employee = new Employee()
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"

                };
            }
            Departments = await DepartmentService.GetDepartments();
            Mapper.Map(Employee, EditEmployeeModel);
           
        }
        protected async Task HandleValidSubmit()
        {

            Mapper.Map(EditEmployeeModel, Employee);
            Employee result = null;
            if (Employee.EmployeeId != 0)
            {
                result= await EmployeeService.EditEmployee(Employee);

            }
            else
            {
                result = await EmployeeService.AddEmployee(Employee);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
        //protected async Task DeleteEmployee()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    NavigationManager.NavigateTo("/");
        //}
    }
}
