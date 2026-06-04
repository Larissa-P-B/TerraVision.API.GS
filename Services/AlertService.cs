using TerraVision.API.Models.Entities;
using TerraVision.API.Services.Interfaces;

namespace TerraVision.API.Services
{
    public class AlertService : IAlertService
    {
        private readonly List<Alert> _alerts =
        [
            new Alert
            {
                AlertType = "TORNADO",
                Severity = "CRITICA",
                Description = "Possível formação de tornado"
            },

            new Alert
            {
                AlertType = "VENDAVAL",
                Severity = "ALTA",
                Description = "Ventos acima de 90 km/h"
            },

            new Alert
            {
                AlertType = "TEMPESTADE SEVERA",
                Severity = "ALTA",
                Description = "Tempestade intensa detectada"
            },

            new Alert
            {
                AlertType = "ONDA DE CALOR",
                Severity = "MEDIA",
                Description = "Temperaturas extremas"
            },

            new Alert
            {
                AlertType = "ALAGAMENTO",
                Severity = "CRITICA",
                Description = "Risco elevado de enchentes"
            }
        ];

        public List<Alert> GetAlerts()
        {
            return _alerts;
        }

        public List<Alert> GetCriticalAlerts()
        {
            return _alerts
                .Where(a => a.Severity == "CRITICA")
                .ToList();
        }
    }
}
