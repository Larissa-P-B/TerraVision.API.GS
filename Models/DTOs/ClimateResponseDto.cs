namespace TerraVision.API.Models.DTOs
{
    public class ClimateResponseDto
    {
        public string City { get; set; }

        public double Temperature { get; set; }

        public int Humidity { get; set; }

        public double WindSpeed { get; set; }

        public int Pressure { get; set; }

        public string AlertType { get; set; }

        public string Severity { get; set; }

        public DateTime DateTime { get; set; }
    }
}
