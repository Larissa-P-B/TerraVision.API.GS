namespace TerraVision.API.Models.DTOs
{
    public class OpenWeatherResponseDto
    {
        public MainInfo Main { get; set; }

        public WindInfo Wind { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }

        public int Humidity { get; set; }

        public int Pressure { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}
