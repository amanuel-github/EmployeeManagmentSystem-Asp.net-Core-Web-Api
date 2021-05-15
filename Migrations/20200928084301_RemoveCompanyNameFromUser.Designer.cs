﻿// <auto-generated />
using System;
using Ezana.ShiftManagment.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ezana.ShiftManagment.API.Migrations
{
    [DbContext(typeof(ShiftPowerDbContext))]
    [Migration("20200928084301_RemoveCompanyNameFromUser")]
    partial class RemoveCompanyNameFromUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Ezana.ShiftManagment.API.Controllers.ScheduleStatus", b =>
                {
                    b.Property<int>("scheduleStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("color")
                        .HasColumnType("text");

                    b.Property<string>("scheduleName")
                        .HasColumnType("text");

                    b.HasKey("scheduleStatusId");

                    b.ToTable("ScheduleStatuses");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CompanyLogo")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("CompanyPhone")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IndustryCatogryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<byte[]>("EmployeePic")
                        .HasColumnType("bytea");

                    b.Property<int>("EmployeeType")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeementTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EmploymentStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Tel")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.EmployeeLeave", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LeaveTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("EmployeeLeaves");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.EmployeeSchedule", b =>
                {
                    b.Property<int>("EmployeeScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndWorkingHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsHoliday")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWeekend")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RecurrenceException")
                        .HasColumnType("text");

                    b.Property<string>("RecurrenceRule")
                        .HasColumnType("text");

                    b.Property<string>("ScheduleName")
                        .HasColumnType("text");

                    b.Property<int>("ScheduleStatusId")
                        .HasColumnType("integer");

                    b.Property<int>("ShiftId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EmployeeScheduleId");

                    b.HasIndex("ScheduleStatusId");

                    b.HasIndex("ShiftId");

                    b.ToTable("EmployeeSchedules");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.EmployeeScheduleSetting", b =>
                {
                    b.Property<int>("EmployeeScheduleSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EmployeeScheduleSettingId");

                    b.ToTable("EmployeeScheduleSettings");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.EmployeeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmployeeStatuses");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.EmployeementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmployeementTypes");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LeaveTypes");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Lookup", b =>
                {
                    b.Property<int>("LookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LookUpTypeId")
                        .HasColumnType("integer");

                    b.HasKey("LookupId");

                    b.HasIndex("LookUpTypeId");

                    b.ToTable("Lookups");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.LookupType", b =>
                {
                    b.Property<int>("LookUpTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("LookUpTypeId");

                    b.ToTable("lookupTypes");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.ParentCompany", b =>
                {
                    b.Property<int>("ParentCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IndustryCatogryId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsBranch")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ParentCompanyAddress")
                        .HasColumnType("text");

                    b.Property<string>("ParentCompanyName")
                        .HasColumnType("text");

                    b.Property<string>("ParentCompanyTel")
                        .HasColumnType("text");

                    b.HasKey("ParentCompanyId");

                    b.ToTable("ParentCompanies");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PermissionName")
                        .HasColumnType("text");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.RepeatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RepeatEndAt")
                        .HasColumnType("text");

                    b.Property<int>("RepeatEndOcc")
                        .HasColumnType("integer");

                    b.Property<int>("RepeatEndType")
                        .HasColumnType("integer");

                    b.Property<int>("RepeatEvery")
                        .HasColumnType("integer");

                    b.Property<string>("RepeatName")
                        .HasColumnType("text");

                    b.Property<int>("RepeatTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RepeatTypes");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ShiftEndTime")
                        .HasColumnType("text");

                    b.Property<string>("ShiftName")
                        .HasColumnType("text");

                    b.Property<string>("ShiftStartTime")
                        .HasColumnType("text");

                    b.HasKey("ShiftId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.ShiftAssign", b =>
                {
                    b.Property<int>("ShiftAssignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndWorkHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ShiftId")
                        .HasColumnType("integer");

                    b.HasKey("ShiftAssignId");

                    b.ToTable("ShiftAssigns");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TaskName")
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("TaskId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.User", b =>
                {
                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.UserTask", b =>
                {
                    b.Property<int>("UserTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserTaskId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.EmployeeSchedule", b =>
                {
                    b.HasOne("Ezana.ShiftManagment.API.Controllers.ScheduleStatus", "ScheduleStatus")
                        .WithMany()
                        .HasForeignKey("ScheduleStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ezana.ShiftManagment.API.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Lookup", b =>
                {
                    b.HasOne("Ezana.ShiftManagment.API.Models.LookupType", null)
                        .WithMany("Lookup")
                        .HasForeignKey("LookUpTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ezana.ShiftManagment.API.Models.Shift", b =>
                {
                    b.HasOne("Ezana.ShiftManagment.API.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
