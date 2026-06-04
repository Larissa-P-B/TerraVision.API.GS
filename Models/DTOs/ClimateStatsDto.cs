namespace TerraVision.API.Models.DTOs
{
    public class ClimateStatsDto
    {
        public int TotalReadings { get; set; }

        public int NormalReadings { get; set; }

        public int HighRiskReadings { get; set; }

        public int CriticalReadings { get; set; }

        public DateTime? LastReadingDate { get; set; }
    }
}
