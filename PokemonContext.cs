using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using PokemonAPI.Models;

namespace PokemonAPI.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; } = null!;

        public DbSet<Set> Sets { get; set; } = null!;

        public DbSet<Pokemon> Pokemon { get; set; } = null!;

        public DbSet<Attack> Attacks { get; set; } = null!;

        public DbSet<Region> Regions { get; set; } = null!;

        public DbSet<PokemonRegion> PokemonRegions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonRegion>()
                .HasKey(cs => new { cs.pokemonid, cs.RegionId });

            modelBuilder.Entity<PokemonRegion>()
                .HasOne<Pokemon>(sc => sc.Pokemon)
                .WithMany(s => s.PokemonRegions)
                .HasForeignKey(sc => sc.pokemonid);


            modelBuilder.Entity<PokemonRegion>()
                .HasOne<Region>(sc => sc.Region)
                .WithMany(s => s.PokemonRegions)
                .HasForeignKey(sc => sc.RegionId);
        }

    }
}