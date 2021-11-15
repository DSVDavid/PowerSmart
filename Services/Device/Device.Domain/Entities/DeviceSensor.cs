using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.Domain.Entities
{
    public class DeviceSensor 
    {
        public string SensorPublicId { get; set; }
        
        public double MaxValue { get; set; }

        
    }
}