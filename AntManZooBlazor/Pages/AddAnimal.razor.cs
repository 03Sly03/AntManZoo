using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace AntManZooBlazor.Pages
{
    public partial class AddAnimal
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        [CascadingParameter(Name = "animalsList")]
        public List<Animal> AnimalsList { get; set; }

        private Animal? AnimalToAdd { get; set; } = new Animal();

        private async void SubmitAnimal()
        {
            if (AnimalToAdd != null)
            {
                await AnimalService.Post(AnimalToAdd);
                List<Animal> animals = await AnimalService.GetAll();
                AnimalToAdd.Id = animals.Last().Id;
                AnimalsList.Add(AnimalToAdd);
                NavManager.NavigateTo("/");
            }
        }
    }
}
