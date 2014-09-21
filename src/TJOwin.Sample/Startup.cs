using Owin;
using TJOwin.HealthCheck;

namespace TJOwin.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config =new HealthCheckConfiguration("/hc", new Checker());
            app.UseHealthCheck(config);
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello");
            });
        } 
    }

    public class Checker : ICheckHealth
    {
        public HealthStatus CheckHealth()
        {
            return new HealthStatus()
            {
                Components = new[] {new ComponentHealth("Universe", ComponentStatus.Weird)}
            };
        }
    }
}