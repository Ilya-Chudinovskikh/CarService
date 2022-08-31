using CarService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.Db
{
    public class CarServiceContext : DbContext
    {
        public DbSet<RepairServiceEntity> RepairServices { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CarOwnerEntity> Owners { get; set; }
        public DbSet<MasterEntity> Masters { get; set; }
        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRepairServiceModel(modelBuilder);
            ConfigureCarModel(modelBuilder);
        }
        private static void ConfigureRepairServiceModel(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<RepairServiceEntity>();

            builder.HasOne(x => x.Car).WithMany().HasForeignKey(x => x.CarId);
            builder.HasOne(x => x.Master).WithMany().HasForeignKey(x => x.MasterId);
        }
        private static void ConfigureCarModel(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<CarEntity>();

            builder.HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId);
        }
    }
}
