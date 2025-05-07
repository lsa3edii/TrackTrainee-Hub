using Blazor.APIs;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Track
{
    public partial class GetAll
    {
        private List<SharedLibrary.Models.Track>? tracks;

        [Inject] private TrackApi? TrackApi { get; set; }


        protected override async Task OnInitializedAsync()
        {
            tracks = await TrackApi.GetAllTracksAsync();
        }


        private async Task DeleteTrack(int id)
        {
            //bool confirmed = await JS.InvokeAsync<bool>("confirm", $"Are you sure you want to delete this track?");
            var response = await TrackApi.DeleteTrackAsync(id);

            if (response.IsSuccessStatusCode)
                tracks = await TrackApi.GetAllTracksAsync();
        }

    }
}
