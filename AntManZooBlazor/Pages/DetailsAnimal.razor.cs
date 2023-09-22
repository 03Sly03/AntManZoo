using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;


namespace AntManZooBlazor.Pages
{
    public partial class DetailsAnimal
    {
        private Animal? MyAnimal { get; set; }

        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IAnimalService AnimalService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MyAnimal = await AnimalService.Get(Id);
        }
    }
}
