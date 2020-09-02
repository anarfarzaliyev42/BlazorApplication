using EmployeeManagement_Models;
using EmployeeManagement_Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public List<Employee> Employees { get; set; }
        public bool ShowActions { get; set; } = true;
        public int SelectedEmployeeCount { get; set; } = 0;
        public int DeletedEmployeeId { get; set; }
        protected async  override Task OnInitializedAsync()
        {
            Employees =await EmployeeService.GetEmployees();
        }
        protected async Task EmployeeDeleted(int id)
        {
            DeletedEmployeeId = id;
            Employees = (await EmployeeService.GetEmployees());

        }
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeeCount++;
            }
            else
            {
                SelectedEmployeeCount--;
            }
        }
        
    }
}
