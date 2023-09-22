using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;


namespace AntManZooBlazor.Pages
{
    public partial class DetailsAnimal
    {
        private string? LoadingMessage { get; set; }
        private Animal? MyAnimal { get; set; }

        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IAnimalService AnimalService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LoadingMessage = "Récupération des données de l'animal";
            MyAnimal = await AnimalService.Get(Id);
            LoadingMessage = "";
        }
    }
}
