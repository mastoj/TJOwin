using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using TJOwin.vNext.HealthCheck;

namespace TJOwin.vNext.Sample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //TJOwin.HealthCheck.AppBuilderExtensions.UseHealthCheck(null);
            var config = new HealthCheckConfiguration();
            app.UseHealthCheck(config);
            app.Use(helloworldMiddleware);
        }

        private RequestDelegate helloworldMiddleware(RequestDelegate arg)
        {
            RequestDelegate rd = (context) => 
            {
                context.Response.WriteAsync("Hello world");
                return arg(context);
            };
            return rd;
        }
    }
}
