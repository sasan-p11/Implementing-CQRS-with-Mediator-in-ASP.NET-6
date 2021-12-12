namespace Domain.DTO.PersonDTO
{
    public class EditPersonDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; }
        public string PictureId { get; set; }
    }
}