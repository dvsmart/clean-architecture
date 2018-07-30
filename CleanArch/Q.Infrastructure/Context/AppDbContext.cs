using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Q.Domain.Assessment;
using Q.Domain.Asset;
using Q.Domain.Common;
using Q.Domain.CustomEntity;
using Q.Domain.Menu;
using Q.Domain.Task;
using Q.Domain.User;
using System;
using System.Reflection;

namespace Q.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region  == Assets ==

        public DbSet<Asset> Assets { get; set; }

        public DbSet<AssetType> AssetTypes { get; set; }

        public DbSet<AssetProperty> AssetProperties { get; set; }

        #endregion

        #region == Assessments ==
        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<AssessmentScope> AssessmentScopes { get; set; }

        public DbSet<AssessmentStatus> AssessmentStatuses { get; set; }

        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        #endregion

        #region == Tasks ==
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<TaskPriority> TaskPriorities { get; set; }

        public DbSet<TaskComment> TaskComments { get; set; }
        #endregion

        #region == Users ==
        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region == Menu ==
        public DbSet<MenuGroup> MenuGroups { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
        #endregion

        #region == Custom Entity Groups ==
        public DbSet<CustomEntityGroup> CustomEntityGroups { get; set; }
        #endregion

        #region == Custom Entities ==
        public DbSet<CustomEntity> CustomEntityDefinitions { get; set; }

        public DbSet<CustomTab> CustomTabs { get; set; }

        public DbSet<CustomField> CustomFields { get; set; }

        public DbSet<CustomFieldType> CustomFieldTypes { get; set; }

        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
        #endregion

        #region == Custom Entity Instances ==

        public DbSet<CustomEntityInstance> CustomEntityInstances { get; set; }

        #endregion

        #region == Common ==
        public DbSet<RecurrenceType> RecurrenceTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetProperty>().Property(p => p.DataId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Assessment>().Property(p => p.DataId).ValueGeneratedOnAdd();

            modelBuilder.Entity<RecurrenceType>().HasData(
                new RecurrenceType
                {
                    RecurrenceNumber = 1,
                    DatePart = "yy",
                    AddedBy = 1,
                    AddedDate = DateTime.Now,
                    IsActive = true,
                    Name = "Annually",
                    IsArchived = false,
                    IsDeleted = false,
                    Id = 1
                },
                new RecurrenceType
                {
                    RecurrenceNumber = 1,
                    DatePart = "MM",
                    AddedBy = 1,
                    AddedDate = DateTime.Now,
                    IsActive = true,
                    Name = "Monthly",
                    IsArchived = false,
                    IsDeleted = false,
                    Id = 2
                },
                new RecurrenceType
                {
                    RecurrenceNumber = 1,
                    DatePart = "dd",
                    AddedBy = 1,
                    AddedDate = DateTime.Now,
                    IsActive = true,
                    Name = "Daily",
                    IsArchived = false,
                    IsDeleted = false,
                    Id = 3
                });
        }

    }

    public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=DHAKSHYVIJAYLTD\\SQLEXPRESS;Database=QPocDb;Trusted_Connection=True;MultipleActiveResultSets=true;integrated security=True",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new AppDbContext(builder.Options);
        }
    }
}
