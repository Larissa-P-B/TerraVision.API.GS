using TerraVision.API.Clients;
using TerraVision.API.Exceptions;
using TerraVision.API.Models.DTOs;
using TerraVision.API.Models.Entities;
using TerraVision.API.Repositories.Interfaces;
using TerraVision.API.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace TerraVision.API.Services;

public class ClimateService : IClimateService
{
    private readonly OpenWeatherClient _client;
    private readonly RiskAnalysisService _riskService;
    private readonly IClimateRepository _repository;
    private readonly ILogger<ClimateService> _logger;

    public ClimateService(
        OpenWeatherClient client,
        RiskAnalysisService riskService,
        IClimateRepository repository,
        ILogger<ClimateService> logger)
    {
        _client = client;
        _riskService = riskService;
        _repository = repository;
        _logger = logger;
    }

    public async Task<ClimateResponseDto> GetClimateAsync(string city)
    {
        var weather =
            await _client.GetWeatherAsync(city);

        _logger.LogInformation(
        "Consulta realizada para cidade {City} em {Date}",
        city,
        DateTime.Now);

        var risk =
            _riskService.Analyze(
                weather.Main.Temp,
                weather.Wind.Speed,
                weather.Main.Humidity,
                weather.Main.Pressure);

        _logger.LogInformation(
        "Risco identificado: {Risk} | Severidade: {Severity}",
        risk.Alert,
        risk.Severity);

        var climateReading = new ClimateReading
        {
            Id = Guid.NewGuid(),
            City = city,
            Temperature = weather.Main.Temp,
            Humidity = weather.Main.Humidity,
            WindSpeed = weather.Wind.Speed,
            Pressure = weather.Main.Pressure,
            RiskLevel = risk.Alert,
            Severity = risk.Severity,
            ReadingDate = DateTime.Now
        };

        await _repository.SaveAsync(climateReading);

        _logger.LogInformation(
        "Leitura salva com sucesso. Id: {Id}",
        climateReading.Id);

        _logger.LogInformation(climateReading.GetSummary());

        return new ClimateResponseDto
        {
            City = climateReading.City,
            Temperature = climateReading.Temperature,
            Humidity = climateReading.Humidity,
            WindSpeed = climateReading.WindSpeed,
            Pressure = climateReading.Pressure,
            AlertType = climateReading.RiskLevel,
            Severity = climateReading.Severity,
            DateTime = climateReading.ReadingDate
        };
    }

    public async Task<List<ClimateReading>> GetHistoryAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ClimateReading?> GetByIdAsync(Guid id)
    {
        var result =
        await _repository.GetByIdAsync(id);

        if (result == null)
        {
            throw new ClimateReadingNotFoundException(id);
        }

        return result;
    }

    public async Task<ClimateStatsDto> GetStatsAsync()
    {
        var readings =
            await _repository.GetAllAsync();

        return new ClimateStatsDto
        {
            TotalReadings = readings.Count(),

            NormalReadings =
                readings.Count(r =>
                    r.RiskLevel == "NORMAL"),

            HighRiskReadings =
                readings.Count(r =>
                    r.Severity == "ALTA"),

            CriticalReadings =
                readings.Count(r =>
                    r.Severity == "CRITICA"),

            LastReadingDate =
                readings.Any()
                    ? readings.Max(r => r.ReadingDate)
                    : null
        };
    }
}
