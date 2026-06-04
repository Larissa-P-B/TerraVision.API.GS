namespace TerraVision.API.Services
{
    public class RiskAnalysisService
    {
        public (string Alert, string Severity)
            Analyze(
                double temperature,
                double wind,
                int humidity,
                int pressure)
        {
            if (wind >= 120 && pressure < 990)
                return ("TORNADO", "CRÍTICA");

            if (temperature >= 42)
                return ("ONDA DE CALOR", "ALTA");

            if (humidity < 20 && temperature > 35)
                return ("SECA EXTREMA", "ALTA");

            if (wind > 60)
                return ("VENDAVAL", "MÉDIA");

            return ("NORMAL", "BAIXA");
        }
    }
}
