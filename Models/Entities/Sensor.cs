namespace TerraVision.API.Models.Entities
{
    public class Sensor : MonitoringDevice
    {
        public string Region { get; set; }

        public override string GetDeviceType()
        {
            return "Sensor Climático";
        }
    }

}
