using Microsoft.AspNetCore.Mvc;
using Portfolio.Common.DataResult;
using Portfolio.DTO.Response.AboutMe;
using Portfolio.Interface.Abstrack;

namespace Portfolio.Web.Controllers;

public class AboutMeController: Controller
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

    public PagingResult<AboutMeGetAllResponse> GetAll(DataTableRequest request)
    {
        
        return _aboutMe.GetAll(request);

    }
}
