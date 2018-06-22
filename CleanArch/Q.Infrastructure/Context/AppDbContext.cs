using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
    }

    public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=DHAKSHY-VIJAY\\SQLEXPRESS;Database=QPocDb;Trusted_Connection=True;MultipleActiveResultSets=true;integrated security=True",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new AppDbContext(builder.Options);
        }
    }
}
