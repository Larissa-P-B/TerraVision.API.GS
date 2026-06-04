using System.Net;
using TerraVision.API.Exceptions;
using TerraVision.API.Models.DTOs;

namespace TerraVision.API.Clients
{
    public class OpenWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenWeatherClient(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<OpenWeatherResponseDto>
            GetWeatherAsync(string city)
        {
            string apiKey =
                _configuration["OpenWeather:ApiKey"]!;

            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            var response =
                await _httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new CityNotFoundException(city);
            }

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<OpenWeatherResponseDto>()
                ?? throw new Exception("Erro ao processar resposta da OpenWeather");
        }
    }
}
