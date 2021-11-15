using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Device.Domain.Entities;
using System.Reflection;

namespace Device.Infrastructure.Data
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Domain.Entities.Device> Devices { get; set; }

        public DbSet<DeviceUser> DeviceUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
        }
    }
}