using EmployeeManagement_Models;
using EmployeeManagement_Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Parameter]
        public string Id { get; set; }

        public Employee Employee { get; set; } = new Employee();
        protected string Coordiantes { get; set; }
        protected string ButtonText { get; set; } = "Hide Actions";
        protected string ToggleCssClass { get; set; } = null;
        
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
        protected void ToggleFooter()
        {
            if(ButtonText=="Hide Actions")
            {
                ButtonText = "Show Actions";
                ToggleCssClass = "hideFooter";
            }
            else
            {
                ButtonText = "Hide Actions";
                ToggleCssClass = null;
            }
        }
        
        //protected void MouseMove(MouseEventArgs e)
        //{
        //    Coordiantes = $"X: {e.ClientX} Y: {e.ClientY}";
        //}
    }
}
