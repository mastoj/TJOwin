using Owin;

namespace TJOwin.HealthCheck
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseHealthCheck(this IAppBuilder app, HealthCheckConfiguration config = null)
        {
            config = config ?? new HealthCheckConfiguration();
            return app.Use<HealthCheckMiddleware>(config);
        }
    }
}