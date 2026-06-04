namespace TerraVision.API.Models.DTOs
{
    public class MonitoringSimulationDto
    {
        public string SatelliteName { get; set; }

        public string SensorName { get; set; }

        public string Region { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string DeviceType { get; set; }

        public string AlertType { get; set; }

        public string Severity { get; set; }

        public DateTime DetectionTime { get; set; }
    }
}
