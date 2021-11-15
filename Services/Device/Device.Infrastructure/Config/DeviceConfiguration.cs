using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Device.Infrastructure.Config
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Domain.Entities.Device>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Device> builder)
        {
            builder.OwnsOne( d => d.Address, a => {
                a.WithOwner();
            });

            builder.OwnsOne( d => d.DeviceSensor, ds => {
                ds.WithOwner();
            });

           builder.HasOne( d => d.DeviceUser).WithMany( du => du.UserDevices);
        }
    }
}