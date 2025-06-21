
using Microsoft.EntityFrameworkCore;
using MTG.Domain.Models;

namespace MTG.Database.DBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Binder> Binders { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<MtgCard> MtgCards { get; set; }
        public DbSet<MtgColor> MtgColors { get; set; }
        public DbSet<MtgType> MtgTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Binder - Card (One-to-Many)
            modelBuilder.Entity<Binder>()
                .HasMany(b => b.Cards)
                .WithOne(c => c.Binder)
                .HasForeignKey(c => c.BinderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Card Inheritance - TPH (Table-per-Hierarchy)
            modelBuilder.Entity<Card>()
                .HasDiscriminator<string>("CardType")
                .HasValue<Card>("Base")
                .HasValue<MtgCard>("MTG");

            // MtgCard - MtgColor (Many-to-Many)
            modelBuilder.Entity<MtgCard>()
                .HasMany(mc => mc.MtgColors)
                .WithMany(c => c.MtgCards)
                .UsingEntity<Dictionary<string, object>>(
                    "MtgCardColor",
                    j => j.HasOne<MtgColor>().WithMany().HasForeignKey("MtgColorId"),
                    j => j.HasOne<MtgCard>().WithMany().HasForeignKey("MtgCardId"),
                    j =>
                    {
                        j.HasKey("MtgCardId", "MtgColorId");
                        j.ToTable("MtgCardColors");
                    });

            // MtgCard - MtgType (Many-to-Many)
            modelBuilder.Entity<MtgCard>()
                .HasMany(mc => mc.MtgTypes)
                .WithMany(t => t.MtgCards)
                .UsingEntity<Dictionary<string, object>>(
                    "MtgCardType",
                    j => j.HasOne<MtgType>().WithMany().HasForeignKey("MtgTypeId"),
                    j => j.HasOne<MtgCard>().WithMany().HasForeignKey("MtgCardId"),
                    j =>
                    {
                        j.HasKey("MtgCardId", "MtgTypeId");
                        j.ToTable("MtgCardTypes");
                    });

            // Seed MtgColors
            modelBuilder.Entity<MtgColor>().HasData(
                new MtgColor { Id = 1, Name = "White", Description = "White mana" },
                new MtgColor { Id = 2, Name = "Green", Description = "Green mana" },
                new MtgColor { Id = 3, Name = "Red", Description = "Red mana" },
                new MtgColor { Id = 4, Name = "Blue", Description = "Blue mana" },
                new MtgColor { Id = 5, Name = "Black", Description = "Black mana" }
            );

            // Seed MtgTypes
            modelBuilder.Entity<MtgType>().HasData(
                new MtgType { Id = 1, Name = "Land", Description = "Land card" },
                new MtgType { Id = 2, Name = "Creature", Description = "Creature card" },
                new MtgType { Id = 3, Name = "Enchantment", Description = "Enchantment card" },
                new MtgType { Id = 4, Name = "Sorcery", Description = "Sorcery card" },
                new MtgType { Id = 5, Name = "Instant", Description = "Instant card" },
                new MtgType { Id = 6, Name = "Artifact", Description = "Artifact card" }
            );
        }
    }
}
