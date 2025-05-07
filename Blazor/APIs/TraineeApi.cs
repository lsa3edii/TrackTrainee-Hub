using SharedLibrary.DTOs;
using SharedLibrary.Models;
using System.Net.Http.Json;

namespace Blazor.APIs
{
    public class TraineeApi
    {
        private readonly HttpClient _http;

        public TraineeApi(HttpClient http)
        {
            _http = http;
        }



        public async Task<List<TraineeDTO>?> GetAllTraineesAsync()
        {
            return await _http.GetFromJsonAsync<List<TraineeDTO>>("api/Trainee/GetAll");
        }
        

        public async Task<TraineeDTO?> GetTraineeAsync(int id)
        {
            return await _http.GetFromJsonAsync<TraineeDTO>($"api/Trainee/GetByID/{id}");
        }


        public async Task<HttpResponseMessage> AddTraineeAsync(Trainee trainee)
        {
            return await _http.PostAsJsonAsync("api/Trainee/Add", trainee);
        }


        public async Task<HttpResponseMessage> EditTraineeAsync(Trainee trainee)
        {
            return await _http.PutAsJsonAsync("api/Trainee/Edit", trainee);
        }


        public async Task<HttpResponseMessage> DeleteTraineeAsync(int id)
        {
            return await _http.DeleteAsync($"api/Trainee/Delete/{id}");
        }

    }
}
