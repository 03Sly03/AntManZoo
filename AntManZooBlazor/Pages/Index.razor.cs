using AntManZooBlazor.Services;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace AntManZooBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        [CascadingParameter(Name = "animalsList")]
        public List<Animal> AnimalsList { get; set; }

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
