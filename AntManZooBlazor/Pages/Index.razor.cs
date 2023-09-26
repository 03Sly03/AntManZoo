using AntManZooBlazor.Services;
using AntManZooBlazor.Shared;
using AntManZooClassLibrary.Models;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace AntManZooBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        [CascadingParameter(Name = "animalsList")]
        public List<Animal> AnimalsList { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; } = default!;

        public void ShowModal() => Modal.Show<ModalAlertConnection>("AntManZoo ! Grrrr !");

        public bool CannotDelete { get; set; } = false;

        public void Delete(int id)
        {
            AnimalService.Delete(id);
            CannotDelete = AnimalService.Get(id) != null;
            var animal = AnimalsList.FirstOrDefault(x => x.Id == id);
            if (!CannotDelete)
            {
                if (animal != null)
                {
                    AnimalsList.Remove(animal);
                }
            }
            else
            {
                ShowModal();
            }
        }
    }
}
