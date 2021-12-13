namespace Domain.DTO.GenresDTO;
public class CreatePersonDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public PhotoDTO Photo { get; set; }
}

