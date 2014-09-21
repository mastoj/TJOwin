using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace TJOwin.HealthCheck
{
    public class HealthCheckMiddleware : OwinMiddleware
    {
        private ICheckHealth _healthChecker;
        private string _endpointUrl;

        public HealthCheckMiddleware(OwinMiddleware next, HealthCheckConfiguration config) : base(next)
        {
            _healthChecker = config.HealthChecker;
            _endpointUrl = config.Endpoint;
        }

        public override async Task Invoke(IOwinContext context)
        {
            if (context.Request.Uri.AbsolutePath == _endpointUrl)
            {
                var healthStatus = _healthChecker.CheckHealth();
                var response = JsonConvert.SerializeObject(healthStatus);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
            else
            {
                await Next.Invoke(context);
            }
        }
    }
}