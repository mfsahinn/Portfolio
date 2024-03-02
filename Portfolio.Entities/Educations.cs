namespace Portfolio.Entities;

public class Educations:BaseModel
{
    public string? SchoolName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Gano { get; set; }
}
