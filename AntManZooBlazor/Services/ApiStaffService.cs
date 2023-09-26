using AntManZooClassLibrary.DTOs;
using AntManZooClassLibrary.Models;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace AntManZooBlazor.Services
{
    public class ApiStaffService : IStaffService
    {
        private IJSRuntime _jsRuntime;
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRouteAuth;
        private readonly string _baseApiRoute;

        public ApiStaffService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseApiRouteAuth = configuration["AnimalAPIUrlHttp"] + "/api/authentication";
            _baseApiRoute = configuration["AnimalAPIUrlHttp"] + "/api/staff";
        }

        public async Task<bool> PostLogin(LoginRequestDTO staffDTO)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRouteAuth + "/login", staffDTO);
            var token = await result.Content.ReadAsStringAsync();
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "userJwtToken", token);
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

        //public async Task<T> GetItem<T>(string key)
        //{
        //    var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

        //    if (json == null)
        //        return default!;

        //    return JsonSerializer.Deserialize<T>(json)!;
        //}
        //public async Task SetItem<T>(string key, T value)
        //{
        //    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        //}

        //public async Task RemoveItem(string key)
        //{
        //    await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        //}
    }
}
