
using Catalog.Core.Entities;

namespace Catalog.Presentation.MiddleWares
{
    public class GlobalExceptionHandlerMiddleWare
    {
        readonly RequestDelegate _next;
        readonly ILogger<GlobalExceptionHandlerMiddleWare> _logger;
        public GlobalExceptionHandlerMiddleWare(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                var errorResponse = new GenericResponse<string>()
                {
                    Data = "",
                    Message = $"Exception happened , {ex.Message}",
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                _logger.LogError(ex, $"Exception happened : {ex.Message}");
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
