using Microsoft.EntityFrameworkCore;
using Services.BL;
using Services.Context;
using SharedLibrary.Models;
using Services.Repos;

namespace Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<TrackTraineeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorLab1")));


            builder.Services.AddScoped<IGenericRepo<Track>, TrackBL>();
            builder.Services.AddScoped<IGenericRepo<Trainee>, TraineeBL>();


            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllUsers", policy => policy.AllowAnyOrigin()
                                                          .AllowAnyMethod()
                                                          .AllowAnyHeader());

                opt.AddPolicy("SpecialUser", policy => policy.WithOrigins("http://127.0.0.1:7080")
                                                             .AllowAnyMethod()
                                                             .AllowAnyHeader());
            });



            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            //app.UseCors("SpecialUser");
            app.UseCors("AllUsers");

            app.Run();
        }
    }

}
