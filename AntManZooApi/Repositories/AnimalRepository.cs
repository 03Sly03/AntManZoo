using AntManZooApi.Datas;
using AntManZooClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace AntManZooApi.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private ApplicationDbContext _dbContext { get; }
        public AnimalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Animal animal)
        {
            var addedObj = await _dbContext.Animals.AddAsync(animal);

            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }
        public async Task<Animal> GetById(int id)
        {
            return await _dbContext.Animals.FindAsync(id);
        }

        public async Task<Animal?> Get(Expression<Func<Animal, bool>> predicate)
        {
            return await _dbContext.Animals.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Animal>> GetAll(Expression<Func<Animal, bool>> predicate)
        {
            return await _dbContext.Animals.Where(predicate).ToListAsync();
        }

        public async Task<List<Animal>> GetAll()
        {
            return await _dbContext.Animals.ToListAsync();
        }

        public async Task<bool> Update(Animal animal)
        {
            var animalFromDb = await GetById(animal.Id);

            if (animalFromDb == null)
                return false;

            if (animalFromDb.Name != animal.Name)
                animalFromDb.Name = animal.Name;
            if (animalFromDb.Age != animal.Age)
                animalFromDb.Age = animal.Age;
            if (animalFromDb.Description != animal.Description)
                animalFromDb.Description = animal.Description;
            if (animalFromDb.Species != animal.Species)
                animalFromDb.Species = animal.Species;

            return await _dbContext.SaveChangesAsync() > 0;

        }
        public async Task<bool> Delete(int id)
        {
            var animal = await GetById(id);

            if (animal == null)
                return false;

            _dbContext.Animals.Remove(animal);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
