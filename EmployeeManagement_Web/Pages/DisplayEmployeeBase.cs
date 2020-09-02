using Company.Components;
using EmployeeManagement_Models;
using EmployeeManagement_Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowActions { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        public ConfirmBase DeleteConfirmation { get; set; }

        protected void DeleteEmployee()
        {
            DeleteConfirmation.Show();
        }
        //protected async Task DeleteEmployee()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        //}
        protected async Task ConfirmDelete(bool isConfirmed)
        {
            if (isConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
           await OnEmployeeSelection.InvokeAsync((bool)e.Value);
            
        }
    }
}
