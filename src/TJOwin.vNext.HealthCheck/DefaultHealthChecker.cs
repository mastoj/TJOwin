namespace TJOwin.vNext.HealthCheck
{
    internal class DefaultHealthChecker : ICheckHealth
    {
        public HealthStatus CheckHealth()
        {
            return new HealthStatus()
            {
                Components = new [] { new ComponentHealth("Web", ComponentStatus.Healthy)}
            };
        }
    }
}