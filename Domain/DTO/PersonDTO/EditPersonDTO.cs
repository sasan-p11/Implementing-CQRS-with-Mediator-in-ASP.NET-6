namespace Domain.DTO.PersonDTO
{
    public class EditPersonDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PhotoDTO Photo { get; set; }
    }
}