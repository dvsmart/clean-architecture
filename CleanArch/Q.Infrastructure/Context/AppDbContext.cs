using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Q.Domain.Assessment;
using Q.Domain.Asset;
using Q.Domain.Common;
using Q.Domain.CustomEntity;
using Q.Domain.Event;
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

        #region == Event ==

        public DbSet<Event> Events { get; set; }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomFieldType>().HasData(
                    new CustomFieldType
                    {
                        Id = 1,
                        Type = "text",
                    },
                    new CustomFieldType
                    {
                        Id = 2,
                        Type = "date"
                    },
                    new CustomFieldType
                    {
                        Id = 3,
                        Type = "time"
                    },
                    new CustomFieldType
                    {
                        Id = 4,
                        Type = "textarea"
                    },
                    new CustomFieldType
                    {
                        Id = 5,
                        Type = "currency"
                    },
                    new CustomFieldType
                    {
                        Id = 6,
                        Type = "checkbox"
                    },
                    new CustomFieldType
                    {
                        Id = 7,
                        Type = "select"
                    },
                    new CustomFieldType
                    {
                        Id = 8,
                        Type = "numerical"
                    },
                    new CustomFieldType
                    {
                        Id = 9,
                        Type = "percent"
                    },
                    new CustomFieldType
                    {
                        Id = 10,
                        Type = "image"
                    },
                    new CustomFieldType
                    {
                        Id = 11,
                        Type = "phone"
                    },
                    new CustomFieldType
                    {
                        Id = 12,
                        Type = "email"
                    },
                    new CustomFieldType
                    {
                        Id = 13,
                        Type = "richtextarea"
                    }
                   );

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

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
            {
                Id = 1,
                RoleName = "Admin",
                AddedBy = 1,
                AddedDate = DateTime.UtcNow,
                IsArchived = false,
                IsDeleted = false,
            }, new UserRole
            {
                Id = 2,
                RoleName = "user",
                AddedBy = 1,
                AddedDate = DateTime.UtcNow,
                IsArchived = false,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserType>().HasData(new UserType
            {
                Id = 1,
                Name = "Visitor",
                AddedBy = 1,
                AddedDate = DateTime.UtcNow,
                IsArchived = false,
                IsDeleted = false,
            }, new UserType
            {
                Id = 2,
                Name = "Reporter",
                AddedBy = 1,
                AddedDate = DateTime.UtcNow,
                IsArchived = false,
                IsDeleted = false,
            });
        }

    }

    public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            //DHAKSHYVIJAYLTD\SQLEXPRESS
            //AKDEV19\\SQLEXPRESS
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=tcp:dvonlinesql.database.windows.net,1433;Initial Catalog=qpocDb;Persist Security Info=False;User ID=dvadmin;Password=Pa55word29$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new AppDbContext(builder.Options);
        }
    }
}
