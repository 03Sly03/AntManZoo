using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace AntManZooBlazor.Pages
{
    public partial class Register
    {
        [Inject]
        public IStaffService StaffService { get; set; }

        [CascadingParameter(Name = "staffsList")]
        public List<Staff> StaffsList { get; set; }

        private Staff? StaffToAdd { get; set; } = new Staff();

        private async void SubmitStaff()
        {
            if (StaffToAdd != null)
            {
                await StaffService.Post(StaffToAdd);
                List<Staff> staffs = await StaffService.GetAll();
                StaffToAdd.Id = staffs.Last().Id;
                StaffsList.Add(StaffToAdd);
                NavManager.NavigateTo("/");
            }
        }
    }
}
