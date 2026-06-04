using TerraVision.API.Models.Entities;

namespace TerraVision.API.Services.Interfaces
{
    public interface IAlertService
    {
        List<Alert> GetAlerts();

        List<Alert> GetCriticalAlerts();
    }
}
