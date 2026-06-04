using System.Net;
using TerraVision.API.Exceptions;

namespace TerraVision.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CityNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);

                context.Response.StatusCode =
                    (int)HttpStatusCode.NotFound;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Error = ex.Message,
                        StatusCode = 404
                    });
            }
            catch (ClimateReadingNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);

                context.Response.StatusCode =
                    (int)HttpStatusCode.NotFound;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Error = ex.Message,
                        StatusCode = 404
                    });
            }
            
            catch (InvalidGuidException ex)
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsJsonAsync(new
                {
                    Error = ex.Message,
                    StatusCode = 400
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Erro interno do sistema");

                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Error = "Erro interno do servidor",
                        StatusCode = 500
                    });
            }
        }
    }
}
