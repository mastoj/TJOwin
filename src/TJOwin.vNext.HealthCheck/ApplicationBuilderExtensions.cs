using System;
using Microsoft.AspNet.Builder;

namespace TJOwin.vNext.HealthCheck
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app, HealthCheckConfiguration config = null)
        {
            config = config ?? new HealthCheckConfiguration();
            return app.Use(next => new HealthCheckMiddleware(next, config).Invoke);
        }
    }
}