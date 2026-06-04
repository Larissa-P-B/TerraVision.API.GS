namespace TerraVision.API.Exceptions
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException(string city)
            : base($"Cidade '{city}' não encontrada.")
        {
        }
    }
}
