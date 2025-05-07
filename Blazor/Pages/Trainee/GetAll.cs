using Blazor.APIs;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Trainee
{
    public partial class GetAll
    {
        private List<SharedLibrary.DTOs.TraineeDTO>? trainees;

        [Inject] private TraineeApi? TraineeApi { get; set; }


        protected override async Task OnInitializedAsync()
        {
            trainees = await TraineeApi.GetAllTraineesAsync();
        }


        private async Task DeleteTrainee(int id)
        {
            var response = await TraineeApi.DeleteTraineeAsync(id);

            if (response.IsSuccessStatusCode)
                trainees = await TraineeApi.GetAllTraineesAsync();
        }

    }
}
