using TerraVision.API.Models.DTOs;
using TerraVision.API.Models.Entities;
using TerraVision.API.Models.Structs;

namespace TerraVision.API.Services
{
    public class DeviceSimulationService
    {
        private readonly Random _random = new();

        public MonitoringSimulationDto RunSimulation()
        {
            var satellites = new List<Satellite>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "GOES-16",
                    OrbitType = "Geoestacionária",
                    CreatedAt = DateTime.Now
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "NOAA-20",
                    OrbitType = "Polar",
                    CreatedAt = DateTime.Now
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Meteosat-11",
                    OrbitType = "Geoestacionária",
                    CreatedAt = DateTime.Now
                }
            };

            var sensors = new List<Sensor>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sensor São Paulo",
                    Region = "Sudeste",
                    CreatedAt = DateTime.Now
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sensor Manaus",
                    Region = "Norte",
                    CreatedAt = DateTime.Now
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sensor Recife",
                    Region = "Nordeste",
                    CreatedAt = DateTime.Now
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sensor Porto Alegre",
                    Region = "Sul",
                    CreatedAt = DateTime.Now
                }
            };

            var coordinates = new List<GeoCoordinate>
            {
                new(-23.5505, -46.6333),
                new(-3.1190, -60.0217),
                new(-8.0476, -34.8770),
                new(-30.0346, -51.2177)
            };

            var alerts = new List<Alert>
            {
                new()
                {
                    AlertType = "VENDAVAL",
                    Severity = "ALTA",
                    Description = "Ventos acima de 90 km/h"
                },

                new()
                {
                    AlertType = "TORNADO",
                    Severity = "CRITICA",
                    Description = "Formação de tornado detectada"
                },

                new()
                {
                    AlertType = "TEMPESTADE SEVERA",
                    Severity = "ALTA",
                    Description = "Tempestade intensa detectada"
                },

                new()
                {
                    AlertType = "ONDA DE CALOR",
                    Severity = "MEDIA",
                    Description = "Temperaturas extremas"
                },

                new()
                {
                    AlertType = "ALAGAMENTO",
                    Severity = "CRITICA",
                    Description = "Risco elevado de enchentes"
                }
            };

            var satellite =
                satellites[_random.Next(satellites.Count)];

            var sensor =
                sensors[_random.Next(sensors.Count)];

            var coordinate =
                coordinates[_random.Next(coordinates.Count)];

            var alert =
                alerts[_random.Next(alerts.Count)];

            return new MonitoringSimulationDto
            {
                SatelliteName = satellite.Name,
                SensorName = sensor.Name,
                Region = sensor.Region,
                Latitude = coordinate.Latitude,
                Longitude = coordinate.Longitude,
                DeviceType = satellite.GetDeviceType(),
                AlertType = alert.AlertType,
                Severity = alert.Severity,
                DetectionTime = DateTime.Now
            };
        }

        public List<DeviceDto> GetDevices()
        {
            List<MonitoringDevice> devices =
            [
                new Satellite
        {
            Id = Guid.NewGuid(),
            Name = "GOES-16",
            OrbitType = "Geoestacionária",
            CreatedAt = DateTime.Now
        },

        new Satellite
        {
            Id = Guid.NewGuid(),
            Name = "NOAA-20",
            OrbitType = "Polar",
            CreatedAt = DateTime.Now
        },

        new Sensor
        {
            Id = Guid.NewGuid(),
            Name = "Sensor São Paulo",
            Region = "Sudeste",
            CreatedAt = DateTime.Now
        },

        new Sensor
        {
            Id = Guid.NewGuid(),
            Name = "Sensor Manaus",
            Region = "Norte",
            CreatedAt = DateTime.Now
        }
            ];

            return devices
                .Select(device => new DeviceDto
                {
                    Id = device.Id,
                    Name = device.Name,
                    DeviceType = device.GetDeviceType(),
                    CreatedAt = device.CreatedAt
                })
                .ToList();
        }
    }
}
