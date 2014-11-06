using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Builder;

namespace TJOwin.vNext.HealthCheck
{
    public class HealthCheckMiddleware
    {
        private ICheckHealth _healthChecker;
        private string _endpointUrl;
        private RequestDelegate _next;

        public HealthCheckMiddleware(RequestDelegate next, HealthCheckConfiguration config)
        {
            _healthChecker = config.HealthChecker;
            _endpointUrl = config.Endpoint;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value == _endpointUrl)
            {
                var healthStatus = _healthChecker.CheckHealth();
                var response = JsonConvert.SerializeObject(healthStatus);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}