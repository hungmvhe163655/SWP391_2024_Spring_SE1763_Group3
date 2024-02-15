using Entities.Models;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using Repositories.Configurations;

namespace BackendCore.Utils
{
    public class HomeManagementDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory = 
            LoggerFactory.Create(builder => { builder.AddNLog(); });

        public HomeManagementDbContext()
        {
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillStatus> BillStatuses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingService> BuildingServices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<BuildingResident> BuildingResidents { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<HomeManager> HomeManagers { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Disable On Delete Cascade for all table 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<BuildingResident>()
                .HasQueryFilter(x => x.IsDeleted == false);

            // Init data
            modelBuilder.ApplyConfiguration(new TenantConfiguration());
            modelBuilder.ApplyConfiguration(new HomeManagerConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingServiceConfiguration());
            modelBuilder.ApplyConfiguration(new BillStatusConfiguration());
            modelBuilder.ApplyConfiguration(new BillDetailConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
        }
    }
}
