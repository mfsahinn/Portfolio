using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Common.DataResult;
using Portfolio.DTO.Request.AboutMe;
using Portfolio.DTO.Response.AboutMe;
using Portfolio.Interface.Abstrack;



namespace Portfolio.Web.Controllers;

public class AboutMeController : Controller
{
    private readonly IAboutMe _aboutMe;

    public AboutMeController(IAboutMe aboutMe)
    {
        _aboutMe = aboutMe;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2()
    {
        return View();
    }

    public PagingResult<AboutMeGetAllResponse> GetAll(DataTableRequest request)
    {
        return _aboutMe.GetAll(request);
    }


    public Result Insert([FromBody]AboutMeInsertRequest request)
    {
        // if (!ModelState.IsValid)
        // {
        //     var keyValuePairs = new List<KeyValuePair<string, string>>();


        //     var validationContext = new ValidationContext(request);
        //     var validationResults = new System.Collections.Generic.List<ValidationResult>();

        //     // Modeli doğrula
        //     bool isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

        //     foreach (var validationResult in validationResults)
        //     {
        //         foreach (var memberName in validationResult.MemberNames)
        //         {
        //             keyValuePairs.Add(new KeyValuePair<string, string>(memberName, validationResult.ErrorMessage));
        //         }
        //     }

        //     return new Result(false, keyValuePairs);

        // }
        // else
        // {

            return _aboutMe.Insert(request);

        // }
    }
}
