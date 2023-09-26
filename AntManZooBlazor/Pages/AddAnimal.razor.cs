using AntManZooBlazor.Services;
using AntManZooBlazor.Shared;
using AntManZooClassLibrary.Models;
using Blazored.Modal.Services;
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

        [CascadingParameter]
        public IModalService Modal { get; set; } = default!;

        public void ShowModal() => Modal.Show<ModalAlertConnection>("AntManZoo ! Grrrr !");

        private async void SubmitAnimal()
        {
            if (AnimalToAdd != null)
            {
                if (await AnimalService.Post(AnimalToAdd))
                {
                    List<Animal> animals = await AnimalService.GetAll();
                    AnimalToAdd.Id = animals.Last().Id;
                    AnimalsList.Add(AnimalToAdd);
                    NavManager.NavigateTo("/");
                }
                else
                {
                    ShowModal();
                }
            }
        }
    }
}
