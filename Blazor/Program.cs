using Blazor.APIs;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");


        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5069/") });
        builder.Services.AddScoped<TrackApi>();
        builder.Services.AddScoped<TraineeApi>();


        await builder.Build().RunAsync();
    }
}
