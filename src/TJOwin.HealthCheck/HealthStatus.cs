using System.Collections.Generic;

namespace TJOwin.HealthCheck
{
    public class HealthStatus
    {
        public IEnumerable<ComponentHealth> Components { get; set; }
    }
}