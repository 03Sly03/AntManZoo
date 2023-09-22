using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace AntManZooBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }
        private string? LoadingMessage { get; set; }
        [Parameter]
        public List<Animal> AnimalsList { get; set; } = new List<Animal>();

        protected override async Task OnInitializedAsync()
        {
            LoadingMessage = "Récupération des données des animaux";
            AnimalsList = await AnimalService.GetAll();
            LoadingMessage = "";
        }
        
        public void Delete(int id)
        {
            AnimalService.Delete(id);
            var animal = AnimalsList.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                AnimalsList.Remove(animal);
            }
        }
    }
}
