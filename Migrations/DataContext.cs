using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Migrations;
public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
           .HasOne<Photo>(s => s.Photo)
           .WithOne(ad => ad.Person)
           .HasForeignKey<Photo>(ad => ad.PersonId);

        modelBuilder.Entity<AppUser>()
         .HasOne<Photo>(s => s.Photo)
         .WithOne(ad => ad.AppUser)
         .HasForeignKey<Photo>(ad => ad.AppUserId);
    }
}
