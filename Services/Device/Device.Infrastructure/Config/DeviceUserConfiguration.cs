using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Device.Infrastructure.Config
{
    public class DeviceUserConfiguration : IEntityTypeConfiguration<DeviceUser>
    {
        public void Configure(EntityTypeBuilder<DeviceUser> builder)
        {
            builder.HasMany(du=>du.UserDevices).WithOne(ud => ud.DeviceUser)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}