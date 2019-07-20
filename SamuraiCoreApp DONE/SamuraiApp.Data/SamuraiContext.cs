using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public SamuraiContext()
        {
        }

        public SamuraiContext(DbContextOptions<SamuraiContext> options)
            : base(options)
        { }


        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SomeEntity> SomeEntities { get; set; }
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.BattleId, s.SamuraiId });

            //modelBuilder.Entity<SamuraiBattle>()
            //    .Property(sb => sb.KillStreak);

            modelBuilder.Entity<SamuraiBattle>()
                .HasOne(sb => sb.Battle)
                .WithMany(b => b.SamuraiBattles)
                .HasForeignKey(sb => new { sb.BattleId });

            modelBuilder.Entity<SamuraiBattle>()
                .HasOne(sb => sb.Samurai)
                .WithMany(s => s.SamuraiBattles)
                .HasForeignKey(sb => new { sb.SamuraiId });

            modelBuilder.Entity<Samurai>()
                .HasOne(s => s.SecretIdentity)
                .WithOne(si => si.Samurai)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<SecretIdentity>(si => new { si.SamuraiId });

            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Samurai)
                .WithMany(s => s.Quotes)
                .HasForeignKey(q => q.SamuraiId);

            modelBuilder.Entity<SamuraiSomeEntity>()
                .HasKey(s => new { s.SomeEntityId, s.SamuraiId });

            modelBuilder.Entity<SamuraiSomeEntity>()
                .HasOne(sse => sse.Samurai)
                .WithMany(s => s.SamuraiSomeEntities)
                .HasForeignKey(ssi => new { ssi.SomeEntityId });

            modelBuilder.Entity<SamuraiSomeEntity>()
                .HasOne(sse => sse.SomeEntity)
                .WithMany(se => se.SamuraiSomeEntities)
                .HasForeignKey(ssi => new { ssi.SamuraiId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=SamuraiAppDataCore;Trusted_Connection=True;");
        }
    }
}
