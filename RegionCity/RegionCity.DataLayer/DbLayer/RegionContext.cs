namespace RegionCity.DataLayer.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RegionContext : DbContext
    {
        public RegionContext(string conString)
           : base(conString)
        {
        }
        public RegionContext()
            : base("name=RegionContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}
