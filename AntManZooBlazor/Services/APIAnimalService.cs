using AntManZooClassLibrary.Models;
using System.Net.Http.Json;

namespace AntManZooBlazor.Services
{
    public class APIAnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute;

        public APIAnimalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseApiRoute = configuration["AnimalAPIUrlHttp"] + "/api/animal";
        }

        public async Task<Animal?> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<Animal>(_baseApiRoute + $"/{id}");
        }

        public async Task<List<Animal>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Animal>>(_baseApiRoute);
            return result!;
        }

        public async Task<bool> Post(Animal animal)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRoute, animal);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Put(Animal animal)
        {
            var result = await _httpClient.PutAsJsonAsync(_baseApiRoute + $"/{animal.Id}", animal);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync(_baseApiRoute + $"/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
