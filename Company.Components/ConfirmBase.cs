using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Components
{
    public class ConfirmBase:ComponentBase
    {
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Confirm Delete";
        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure to delete ?";
        protected bool ShowConfirmation { get; set; }
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value); 
        }
    }
}
