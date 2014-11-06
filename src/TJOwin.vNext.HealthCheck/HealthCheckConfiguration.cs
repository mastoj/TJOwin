namespace TJOwin.vNext.HealthCheck
{
    public class HealthCheckConfiguration
    {
        public ICheckHealth HealthChecker { get; private set; }
        public string Endpoint { get; private set; }

        public HealthCheckConfiguration(string endpoint = null, ICheckHealth healthChecker = null)
        {
            HealthChecker = healthChecker ?? new DefaultHealthChecker();
            Endpoint = endpoint ?? "/api/healthcheck";
        }
    }
}