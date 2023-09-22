using AntManZooApi.Repositories;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace AntManZooApi.Controllers
{
    public class AnimalController : ControllerBase
    {
        private readonly IRepository<Animal> _animalRepository;

        public AnimalController(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _animalRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal([FromBody] Animal animal)
        {
            var animalId = await _animalRepository.Add(animal);

            if (animalId > 1)
                return CreatedAtAction(nameof(Menu), "Animal added");

            return BadRequest("Something went wrong");
        }
    }
}
