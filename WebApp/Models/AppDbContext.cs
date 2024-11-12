using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
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
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity(){
                    Id = 101,
                    Name = "WSEI",
                    NIP = "98348234",
                    REGON = "12313548353"
                }, 
                new OrganizationEntity(){
                    Id = 102,
                    Name = "PKP",
                    NIP = "53563646",
                    REGON = "53155134835"
                }
            );

        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new
                {
                    City = "Kraków",
                    Street = "św. Filipa 17",
                    OrganizationEntityId = 101
                },new
                {
                    City = "Warszawa",
                    Street = "Dworcowa 8",
                    OrganizationEntityId = 102
                }
            );
        
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Testowy",
                BirthDate = new DateOnly(2000, 01, 05),
                Email = "adam.testowy@mail.com",
                PhoneNumber = "123456789",
                Created = DateTime.Now,
                OrganizationId = 101
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Alan",
                LastName = "Nowak",
                BirthDate = new DateOnly(1990, 07, 05),
                Email = "alan.nowak@mail.com",
                PhoneNumber = "222333444",
                Created = DateTime.Now,
                OrganizationId = 102
            }
        );
    }
}