using Microsoft.EntityFrameworkCore;

namespace meditation.Infrastructure.DataStoreContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
