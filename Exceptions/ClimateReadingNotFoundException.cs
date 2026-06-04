namespace TerraVision.API.Exceptions
{
    public class ClimateReadingNotFoundException : Exception
    {
        public ClimateReadingNotFoundException(Guid id)
            : base($"Leitura climática {id} não encontrada.")
        {
        }
    }
}
