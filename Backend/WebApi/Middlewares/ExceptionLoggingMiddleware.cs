using Application.UseCases.EventLogs.Interfaces;
using Domain.Models.EventLogs;

namespace WebApi.Middlewares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAddEventLogUseCase _addEventLogUseCase)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var log = new EventLogsModel
                {
                    EventDate = DateTime.Now,
                    Description = "Error no controlado",
                    EventType = "API",
                    ExceptionMessage = ex.Message,
                    ReferenceEntity = context.Request.Path
                };

                await _addEventLogUseCase.ExecuteAsync(log);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { error = "Ocurrió un error inesperado." });
            }
        }
    }
}
