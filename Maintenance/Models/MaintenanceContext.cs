using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Maintenance.Models
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext() : base("name=MaintenanceContext") { }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
