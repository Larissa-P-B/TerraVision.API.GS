namespace TerraVision.API.Models.Structs
{
    public struct GeoCoordinate
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
