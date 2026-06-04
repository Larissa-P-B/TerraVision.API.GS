
using TerraVision.API.Clients;
using TerraVision.API.Services.Interfaces;
using TerraVision.API.Services;
using Microsoft.EntityFrameworkCore;
using TerraVision.API.Data;
using TerraVision.API.Repositories;
using TerraVision.API.Repositories.Interfaces;
using TerraVision.API.Middleware;

namespace TerraVision.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IClimateService,
                                      ClimateService>();
            builder.Services.AddScoped<IAlertService,
                           AlertService>();

            builder.Services.AddScoped<DeviceSimulationService>();

            builder.Services.AddScoped<IClimateRepository,
                                        ClimateRepository>();

            builder.Services.AddScoped<RiskAnalysisService>();

            builder.Services.AddHttpClient<OpenWeatherClient>();

            builder.Services.AddDbContext<TerraVisionDbContext>(
            options =>
            {
                options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
                });
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
