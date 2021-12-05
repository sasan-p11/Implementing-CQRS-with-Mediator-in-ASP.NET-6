
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gener>().HasData(
            new Gener { Id = 1, Name = "Action" },
            new Gener { Id = 2, Name = "Adventure" },
            new Gener { Id = 3, Name = "Comedy" },
            new Gener { Id = 4, Name = "Drama" },
            new Gener { Id = 5, Name = "Fantasy" },
            new Gener { Id = 6, Name = "Horror" }
        );
    }
}