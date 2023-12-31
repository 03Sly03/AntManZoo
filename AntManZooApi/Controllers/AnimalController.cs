﻿using AntManZooApi.Repositories;
using AntManZooClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AntManZooApi.Controllers
{
    [Route("api/animal")]
    [ApiController]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Recuperation(int id)
        {
            var animal = await _animalRepository.GetById(id);
            if (animal == null)
            {
                return NotFound("Animal non trouvé");
            }
            return Ok(animal);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAnimal([FromBody] Animal animal)
        {
            var animalId = await _animalRepository.Add(animal);

            if (animalId > 1)
                return CreatedAtAction(nameof(Menu), new { id = animal.Id, Message = "Animal ajouté !" });

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] Animal animal)
        {
            var pizz = await _animalRepository.GetById(id);
            if (pizz == null)
                return BadRequest("Animal non trouvé");

            animal.Id = id;
            if (await _animalRepository.Update(animal))
                return Ok("Animal mis à jour !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveAnimal(int id)
        {
            var animal = await _animalRepository.GetById(id);
            if (animal == null)
                return BadRequest("Animal non trouvé");

            if (await _animalRepository.Delete(id))
                return Ok("Animal supprimé");

            return BadRequest("Something went wrong...");
        }
    }
}

