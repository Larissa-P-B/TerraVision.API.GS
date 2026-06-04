namespace TerraVision.API.Exceptions
{
    public class InvalidGuidException : Exception
    {
        public InvalidGuidException(string value)
            : base($"'{value}' não é um GUID válido.")
        {
        }

        public InvalidGuidException(Guid id)
        {
        }
    }
}
