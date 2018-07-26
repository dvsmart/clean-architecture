using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Q.Domain.Assessment;
using Q.Domain.Asset;
using Q.Domain.CustomEntity;
using Q.Domain.Menu;
using Q.Domain.Task;
using Q.Domain.User;
using System.Reflection;

namespace Q.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<MenuGroup> MenuGroups { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<TaskPriority> TaskPriorities { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<AssetType> AssetTypes { get; set; }

        public DbSet<AssetProperty> AssetProperties { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<AssessmentScope> AssessmentScopes { get; set; }

        public DbSet<AssessmentStatus> AssessmentStatuses { get; set; }

        public DbSet<AssessmentType> AssessmentTypes { get; set; }

        public DbSet<CustomEntityGroup> CustomEntityGroups { get; set; }

        public DbSet<CustomEntity> CustomEntityDefinitions { get; set; }

        public DbSet<CustomEntityInstance> CustomEntityInstances { get; set; }

        public DbSet<CustomTab> CustomTabs { get; set; }

        public DbSet<CustomField> CustomFields { get; set; }

        public DbSet<CustomFieldType> CustomFieldTypes { get; set; }

        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetProperty>().Property(p => p.DataId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Assessment>().Property(p => p.DataId)..ValueGeneratedOnAdd();
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
