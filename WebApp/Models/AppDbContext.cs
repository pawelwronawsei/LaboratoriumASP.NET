using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Testowy",
                BirthDate = new DateOnly(2000, 01, 05),
                Email = "adam.testowy@mail.com",
                PhoneNumber = "123456789",
                Created = DateTime.Now
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Alan",
                LastName = "Nowak",
                BirthDate = new DateOnly(1990, 07, 05),
                Email = "alan.nowak@mail.com",
                PhoneNumber = "222333444",
                Created = DateTime.Now
            }
        );
    }
}