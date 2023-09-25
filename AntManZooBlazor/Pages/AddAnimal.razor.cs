using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace AntManZooBlazor.Pages
{
    public partial class AddAnimal
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        [CascadingParameter(Name = "animalsList")]
        public List<Animal> AnimalsList { get; set; }

        private Animal? AnimalToAdd { get; set; } = new Animal();

        private void SubmitAnimal()
        {
            if (AnimalToAdd != null)
            {
                AnimalService.Post(AnimalToAdd);
                AnimalsList.Add(AnimalToAdd);
                NavManager.NavigateTo("/");
            }
        }
    }
}
