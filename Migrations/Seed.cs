using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Migrations;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Adventure" },
            new Genre { Id = 3, Name = "Comedy" },
            new Genre { Id = 4, Name = "Drama" },
            new Genre { Id = 5, Name = "Fantasy" },
            new Genre { Id = 6, Name = "Horror" });
    }
}

