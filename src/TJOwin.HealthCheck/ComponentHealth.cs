using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TJOwin.HealthCheck
{
    public class ComponentHealth
    {
        public string ComponentName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ComponentStatus StatusName
        {
            get { return Status; }
        }

        public ComponentStatus Status { get; set; }

        public ComponentHealth(string componentName, ComponentStatus status)
        {
            ComponentName = componentName;
            Status = status;
        }
    }
}