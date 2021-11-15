using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.Domain.Entities
{
    public class Device : BaseEntity
    {

        private Device() { }

        public Device(string description,
         double latitude, double Longitude,
         string devicePublicId, double deviceMaxValue)
        {
            Description = description;
            MaxConsumption = 0;
            AvgConsumption = 0;

            Address = new Address
            {
                Latitude = latitude,
                Longitude = Longitude
            };

            DeviceSensor = new DeviceSensor
            {
                SensorPublicId = devicePublicId,
                MaxValue = deviceMaxValue
            };

        }

        public void SetDeviceUser(Guid userId)
        {
            DeviceUserId = userId;
        }

        public string Description { get; internal set; }

        public Address Address { get; internal set; }

        public double MaxConsumption { get; internal set; }

        public double AvgConsumption { get; internal set; }

        public DeviceSensor DeviceSensor { get; set; }

        public Guid? DeviceUserId { get; set; }
        public DeviceUser DeviceUser { get; set; }


    }
}