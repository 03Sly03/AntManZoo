using AntManZooClassLibrary.Datas;
using AntManZooClassLibrary.Models;

namespace AntManZooBlazor.Services
{
    public class FakeDBAnimalService : IAnimalService
    {
        private List<Animal> _animals = InitialAnimal.animals;
        private int _lastId = 100;

        //public Animal? Get(int id)
        //{
        //    return _animals.FirstOrDefault(animal => animal.Id == id);
        //}
        public async Task<Animal?> Get(int id)
        {
            return _animals.FirstOrDefault(animal => animal.Id == id);
        }

        public async Task<List<Animal>> GetAll()
        {
            return _animals;
        }

        public async Task<Animal?> Post(Animal animal)
        {
            animal.Id = ++_lastId;
            _animals.Add(animal);
            return animal;
        }
    }
}
