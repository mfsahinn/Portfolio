namespace Portfolio.DTO.Response.AboutMe;

public class AboutMeGetAllResponse
{
    public Guid Id { get; set; }
    public string? About { get; set; }
    public int? Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
