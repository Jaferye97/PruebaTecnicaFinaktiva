using Application.UseCases.EventLogs.Interfaces;
using Domain.Models.EventLogs;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.ActionFilters
{
    public class EventLogActionFilter : IAsyncActionFilter
    {
        private readonly IAddEventLogUseCase _addEventLogUseCase;

        public EventLogActionFilter(IAddEventLogUseCase eventLogUseCase)
        {
            _addEventLogUseCase = eventLogUseCase;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logRequest = new EventLogsModel
            {
                EventDate = DateTime.Now,
                Description = $"Se llamó al endpoint {context.ActionDescriptor.DisplayName}",
                EventType = "API",
                ReferenceEntity = context.HttpContext.Request.Path
            };

            await _addEventLogUseCase.ExecuteAsync(logRequest);

            await next();
        }
    }
}
