namespace TerraVision.API.Models.Entities
{
    public partial class ClimateReading
    {
        public string GetSummary()
        {
            return $"{City} | {Temperature}°C | {RiskLevel}";
        }

        public bool IsCritical()
        {
            return Severity == "ALTA" ||
                   Severity == "CRITICA";
        }
    }
}
