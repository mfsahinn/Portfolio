namespace Portfolio.Entities;

public class ProjectsDefinitions:BaseModel
{
    public Guid ProjectId { get; set; }
    public string? Definition { get; set; }
}
