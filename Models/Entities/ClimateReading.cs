namespace TerraVision.API.Models.Entities
{
    public partial class ClimateReading
    {
        public Guid Id { get; set; }

        public string City { get; set; } = string.Empty;

        public double Temperature { get; set; }

        public int Humidity { get; set; }

        public double WindSpeed { get; set; }

        public int Pressure { get; set; }

        public string RiskLevel { get; set; } = string.Empty;

        public string Severity { get; set; } = string.Empty;

        public DateTime ReadingDate { get; set; }
    }
}
