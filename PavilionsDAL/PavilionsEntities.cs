namespace PavilionsDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PavilionsEntities : DbContext
    {
        public PavilionsEntities()
            : base("name=PavilionsConnection")
        {
        }

        public virtual DbSet<Arenda> Arendas { get; set; }
        public virtual DbSet<Arendator> Arendators { get; set; }
        public virtual DbSet<EnablePavilion> EnablePavilions { get; set; }
        public virtual DbSet<Plancton> Planctons { get; set; }
        public virtual DbSet<SC> SCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnablePavilion>()
                .HasMany(e => e.Arendas)
                .WithOptional(e => e.EnablePavilion)
                .HasForeignKey(e => new { e.SCID, e.PavilionNum });

            modelBuilder.Entity<SC>()
                .HasMany(e => e.EnablePavilions)
                .WithRequired(e => e.SC)
                .WillCascadeOnDelete(false);
        }
    }
}
