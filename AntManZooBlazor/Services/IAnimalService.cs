using AntManZooClassLibrary.Models;

namespace AntManZooBlazor.Services
{
    public interface IAnimalService
    {
        Task<Animal?> Get(int id);
        Task<List<Animal>> GetAll();
        Task<Animal?> Post(Animal animal);
        //Task<bool?> Put(Animal animal);

        //Task<bool> Delete(int id);
    }
}