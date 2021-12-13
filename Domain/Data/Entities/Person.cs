namespace Domain.Data.Entities;
public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Photo Photo { get; set; }
}