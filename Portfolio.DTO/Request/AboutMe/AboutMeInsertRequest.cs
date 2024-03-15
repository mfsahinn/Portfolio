using System.ComponentModel.DataAnnotations;

namespace Portfolio.DTO.Request.AboutMe;

public class AboutMeInsertRequest
{   
    [Required]
    [MinLength(6, ErrorMessage = "The first name field must be at least 6 characters long")]
    public string? About { get; set; }

}
