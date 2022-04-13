using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filter
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;
        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string dt = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("###################################");
            _logger.LogInformation($"{dt}");
            _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
            _logger.LogInformation("###################################");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string dt = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("###################################");
            _logger.LogInformation($"{dt}");
            _logger.LogInformation("###################################");
        }


    }
}
