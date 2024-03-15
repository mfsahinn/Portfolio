using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class BaseModel
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Status { get; set; }
}
