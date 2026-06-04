namespace TerraVision.API.Models.Entities
{
    public abstract class MonitoringDevice
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public abstract string GetDeviceType();
    }
}
