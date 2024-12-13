using meditation.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace meditation.Infrastructure.DataStoreContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) { }

        public DbSet<MantraModel> Mantras { get; set; }
        public DbSet<AdditionalMantraModel> AdditionalMantras { get; set; }
        public DbSet<GaneshaMantraModel> GaneshaMantras { get; set; }
        public DbSet<KrishnaMantraModel> KrishnaMantras { get; set; }
        public DbSet<MahakaliMantraModel> MahakaliMantras { get; set; }
        public DbSet<MahamrityunjayaModel> Mahamrityunjayas { get; set; }
        public DbSet<ShivaMantraModel> ShivaMantras { get; set; }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //fixing decimal problem in sqlite
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}
