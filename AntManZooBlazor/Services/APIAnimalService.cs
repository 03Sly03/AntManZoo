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

        public Task<Animal?> Post(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
