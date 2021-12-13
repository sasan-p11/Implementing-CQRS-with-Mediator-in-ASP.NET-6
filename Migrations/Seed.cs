using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Migrations;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = Guid.NewGuid(), Name = "Action" },
            new Genre { Id = Guid.NewGuid(), Name = "Adventure" },
            new Genre { Id = Guid.NewGuid(), Name = "Comedy" },
            new Genre { Id = Guid.NewGuid(), Name = "Drama" },
            new Genre { Id = Guid.NewGuid(), Name = "Fantasy" },
            new Genre { Id = Guid.NewGuid(), Name = "Horror" });

        //modelBuilder.Entity<Person>().HasData(
        //    new Person
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "John Doe",
        //        Biography = "John Doe is a fictional character and the main protagonist of the fictional series The Walking Dead.",
        //        DateOfBirth = new DateTime(1958, 1, 1),
        //        Photo = new Photo
        //        {
        //            Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
        //            Id = "qi9zcoygcctcpmqobyah"
        //        }
        //    },
        //    new Person
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Rick Grimes",
        //        Biography = "Rick Grimes is a fictional character and the main protagonist of the fictional series The Walking Dead.",
        //        DateOfBirth = new DateTime(1958, 1, 1),
        //        Photo = new Photo
        //        {
        //            Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
        //            Id = "qi9zcoygcctcpmqobyah"
        //        }
        //    },
        //    new Person
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Michonne",
        //        Biography = "Michonne is a fictional character and the main protagonist of the fictional series The Walking Dead.",
        //        DateOfBirth = new DateTime(1958, 1, 1),
        //        Photo = new Photo
        //        {
        //            Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png",
        //            Id = "qi9zcoygcctcpmqobyah"
        //        },
        //    },
        //    new Person
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Glenn Rhee",
        //        Biography = "Glenn Rhee is a fictional character and the main protagonist of the fictional series The Walking Dead.",
        //        DateOfBirth = new DateTime(1958, 1, 1),
        //        Photo = new Photo
        //        {
        //            Id = "qi9zcoygcctcpmqobyah",
        //            Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png"
        //        }
        //    });


        //modelBuilder.Entity<AppUser>().HasData(
        //    new AppUser
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "John Doe1",
        //        Email = "Test1@gmail.com",
        //        DisplayName = "John Doe1",
        //        City = "New York1",
        //        Password = "Test1",
        //        Photo = new Photo
        //        {
        //            Id = "qi9zcoygcctcpmqobyah",
        //            Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png"
        //        }
        //    },
            //new AppUser
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "John Doe2",
            //    Email = "Test2@gmail.com",
            //    DisplayName = "John Doe2",
            //    City = "New York2",
            //    Password = "Test2",
            //    Photo = new Photo
            //    {
            //        Id = "qi9zcoygcctcpmqobyah",
            //        Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png"
            //    }
            //},
            //new AppUser
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "John Doe3",
            //    Email = "Test3@gmail.com",
            //    DisplayName = "John Doe3",
            //    City = "New York3",
            //    Password = "Test3",
            //    Photo = new Photo
            //    {
            //        Id = "qi9zcoygcctcpmqobyah",
            //        Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png"
            //    }
            //},
            //new AppUser
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "John Doe4",
            //    Email = "Test4@gmail.com",
            //    DisplayName = "John Doe4",
            //    City = "New York4",
            //    Password = "Test4",
            //    Photo = new Photo
            //    {
            //        Id = "qi9zcoygcctcpmqobyah",
            //        Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/John_Doe_%28The_Walking_Dead%29.png/220px-John_Doe_%28The_Walking_Dead%29.png"
            //    }
            //}

      //  );
    }
}

