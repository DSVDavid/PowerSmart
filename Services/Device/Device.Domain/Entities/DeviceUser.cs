using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.Domain.Entities
{
    public class DeviceUser : BaseEntity
    {
        public string UserName { get; set; }
        
        public ICollection<Device> UserDevices { get; set; }
        
        
    }
}