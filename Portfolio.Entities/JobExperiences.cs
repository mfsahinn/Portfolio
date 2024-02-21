namespace Portfolio.Entities;

public class JobExperiences:BaseModel
{
    public string? CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Definition { get; set; }
}
