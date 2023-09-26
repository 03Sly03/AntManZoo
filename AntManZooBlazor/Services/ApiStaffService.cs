using AntManZooClassLibrary.DTOs;
using AntManZooClassLibrary.Models;
using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AntManZooBlazor.Services
{
    public class ApiStaffService : IStaffService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRouteAuth;
        private readonly string _baseApiRoute;
        private ILocalStorageService _localStorage; 

        public ApiStaffService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _baseApiRouteAuth = configuration["AnimalAPIUrlHttp"] + "/api/authentication";
            _baseApiRoute = configuration["AnimalAPIUrlHttp"] + "/api/staff";
            _localStorage = localStorageService;
        }

        public async Task<bool> PostLogin(LoginRequestDTO staffDTO)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRouteAuth + "/login", staffDTO);
            var token = await result.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync("le token : " + token.ToString());
            await _localStorage.SetItemAsync("token", token);
            return result.IsSuccessStatusCode;
        }

        public async Task<Staff?> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<Staff>(_baseApiRoute + $"/{id}");
        }

        public async Task<List<Staff>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Staff>>(_baseApiRoute + $"/");
            return result!;
        }

        public async Task<bool> Post(Staff staff)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRouteAuth + "/Register", staff);
            return result.IsSuccessStatusCode;
        }

        //public async Task<bool> Put(Staff staff)
        //{
        //    var result = await _httpClient.PutAsJsonAsync(_baseApiRoute + $"/{staff.Id}", staff);
        //    return result.IsSuccessStatusCode;
        //}

        //public Task<bool> Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
