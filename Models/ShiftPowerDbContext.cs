using Ezana.ShiftManagment.API.Models.audit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ezana.ShiftManagment.API.Models;
using Ezana.ShiftManagment.API.Controllers;

namespace Ezana.ShiftManagment.API.Models
{
    public class ShiftPowerDbContext : DbContext
    {
       
            public ShiftPowerDbContext(DbContextOptions<ShiftPowerDbContext> options) : base(options) { }
            public DbSet<User> Users { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Shift> Shifts { get; set; }
            public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
            public DbSet<Schedule> Schedules { get; set; }
            public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
            public DbSet<EmployeementType> EmployeementTypes { get; set; }
            public DbSet<ShiftAssign> ShiftAssigns { get; set; }
            public DbSet<LookupType> lookupTypes { get; set; }
            public DbSet<Lookup> Lookups { get; set; }
            public DbSet<Company> Companies { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<ParentCompany> ParentCompanies { get; set; }
            public DbSet<Role> Roles { get; set; }  
            public DbSet<UserTask> UserTasks { get; set; }
            public DbSet<EmployeeScheduleSetting> EmployeeScheduleSettings { get; set; }
            public DbSet<RepeatType> RepeatTypes { get; set; }
            public DbSet<ScheduleStatus> ScheduleStatuses { get; set; }
            public DbSet<LeaveType> LeaveTypes { get; set; }
            public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
            //public DbSet<RoleToPermission> RoleToPermissions { get; set; }
            public DbSet<Permission> Permissions { get; set; }
            public DbSet<AppTask> Task { get; set; }
            public DbSet<TaskSettingType> TaskSettingTypes { get; set; }
            public DbSet<TaskSetting> TaskSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasNoKey();
            modelBuilder.Entity<Role>().HasNoKey();
            modelBuilder.Entity<Permission>().HasNoKey();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0 &&
                    entityType.Name != "Users" && entityType.Name != "Roles")
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn");
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.GetType().GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    entry.Property("LastModifiedOn").CurrentValue = timestamp;

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedOn").CurrentValue = timestamp;
                    }
                }
            }
            return base.SaveChanges();
        }

       
    }
}