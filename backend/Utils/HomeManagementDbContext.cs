using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Backend.Utils
{
    public class HomeManagementDbContext : DbContext
    {
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
        public DbSet<UtilityCost> UtilityCosts { get; set; }
        public DbSet<UtilityCostType> UtilityCostTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<HomeManager> HomeManagers { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Disable On Delete Cascade for all table 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            // Allow Temporal table for Building Service and Utility Cost Type
            // table, is used to tracked history
            modelBuilder.Entity<BuildingService>()
                .ToTable("BuildingServices", bs => bs.IsTemporal());
            modelBuilder.Entity<UtilityCostType>()
                .ToTable("UtilityCostTypes", uct => uct.IsTemporal());
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
