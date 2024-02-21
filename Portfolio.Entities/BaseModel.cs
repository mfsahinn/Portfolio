using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities;

public class BaseModel
{
    [Key]
    public Guid Id { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedBy { get; set; }
    public DateTime UpdateDate { get; set; }
    public int? Status { get; set; }
}
