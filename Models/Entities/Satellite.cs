namespace TerraVision.API.Models.Entities
{
    public class Satellite : MonitoringDevice
    {
        public string OrbitType { get; set; }

        public override string GetDeviceType()
        {
            return "Satélite Meteorológico";
        }
    }

}
