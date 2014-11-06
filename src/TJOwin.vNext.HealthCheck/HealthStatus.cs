using System.Collections.Generic;

namespace TJOwin.vNext.HealthCheck
{
    public class HealthStatus
    {
        public IEnumerable<ComponentHealth> Components { get; set; }
    }
}