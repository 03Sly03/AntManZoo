using AntManZooClassLibrary.DTOs;
using AntManZooBlazor.Services;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;

namespace AntManZooBlazor.Pages
{
    public partial class Login
    {
        [Inject]
        public IStaffService StaffService { get; set; }

        private LoginRequestDTO? StaffToAdd { get; set; } = new LoginRequestDTO();

        private void SubmitStaff()
        {
            if (StaffToAdd != null)
            {
                
                var token = StaffService.PostLogin(StaffToAdd);
                Console.WriteLine("le staffData: " + token);
                //NavManager.NavigateTo("/");
            }
        }
    }
}
