using SharedLibrary.Models;
using System.Net.Http.Json;

namespace Blazor.APIs
{
    public class TrackApi
    {
        private readonly HttpClient _http;

        public TrackApi(HttpClient http)
        {
            _http = http;
        }



        public async Task<List<Track>?> GetAllTracksAsync()
        {
            return await _http.GetFromJsonAsync<List<Track>>("api/Track/GetAll");
        }
        

        public async Task<Track?> GetTrackAsync(int id)
        {
            return await _http.GetFromJsonAsync<Track>($"api/Track/GetByID/{id}");
        }


        public async Task<HttpResponseMessage> AddTrackAsync(Track track)
        {
            return await _http.PostAsJsonAsync("api/Track/Add", track);
        }


        public async Task<HttpResponseMessage> EditTrackAsync(Track track)
        {
            return await _http.PutAsJsonAsync("api/Track/Edit", track);
        }


        public async Task<HttpResponseMessage> DeleteTrackAsync(int id)
        {
            return await _http.DeleteAsync($"api/Track/Delete/{id}");
        }

    }
}
