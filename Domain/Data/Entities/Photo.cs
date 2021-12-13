namespace Domain.Data.Entities;
public class Photo
{
    public string Id { get; set; }
    public string Url { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser{ get; set; }
    public Person Person{ get; set; }
    public Guid PersonId{ get; set; }
}