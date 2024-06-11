using Kolok2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolok2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Backpacks> Backpacks { get; set; }
    public DbSet<Characters> Characters { get; set; }
    public DbSet<CharacterTitles> CharacterTitles { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Titles> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Backpacks>().HasData(new List<Backpacks>
        {
            new Backpacks
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 1
            }
        });

        modelBuilder.Entity<Characters>().HasData(new List<Characters>
        {
            new Characters
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                CurrentWeight = 10,
                MaxWeight = 20
            }
        });
        
        modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>
        {
            new CharacterTitles
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2024-05-21")
            }
        });
        
        modelBuilder.Entity<Items>().HasData(new List<Items>
        {
            new Items
            {
                Id = 1,
                Name = "Hubert",
                Weight = 10
            }
        });
        
        modelBuilder.Entity<Titles>().HasData(new List<Titles>
        {
            new Titles
            {
                Id = 1,
                Name = "Grzegorz"
            }
        });
    }
}