namespace TerraVision.API.Models.DTOs
{
    public class DeviceDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DeviceType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
