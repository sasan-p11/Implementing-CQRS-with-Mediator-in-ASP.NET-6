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

        modelBuilder.Entity<Person>().HasData(
            new Person
            {
                Id = 1,
                Name = "John Doe",
                Biography = "John Doe is a fictional character and the main protagonist of the fictional series The Walking Dead.",
                DateOfBirth = new DateTime(1958, 1, 1),
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
                PictureId = "qi9zcoygcctcpmqobyah"
            },
            new Person
            {
                Id = 2,
                Name = "Rick Grimes",
                Biography = "Rick Grimes is a fictional character and the main protagonist of the fictional series The Walking Dead.",
                DateOfBirth = new DateTime(1958, 1, 1),
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
                PictureId = "qi9zcoygcctcpmqobyah"
            },
            new Person
            {
                Id = 3,
                Name = "Michonne",
                Biography = "Michonne is a fictional character and the main protagonist of the fictional series The Walking Dead.",
                DateOfBirth = new DateTime(1958, 1, 1),
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
                PictureId = "qi9zcoygcctcpmqobyah"
            },
            new Person
            {
                Id = 4,
                Name = "Glenn Rhee",
                Biography = "Glenn Rhee is a fictional character and the main protagonist of the fictional series The Walking Dead.",
                DateOfBirth = new DateTime(1958, 1, 1),
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
                PictureId = "qi9zcoygcctcpmqobyah"
            }

        );
    }
}

