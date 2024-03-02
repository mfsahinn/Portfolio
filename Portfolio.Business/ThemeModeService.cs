using Portfolio.Common.DataResult;
using Portfolio.Common.Enum;
using Portfolio.DataAccess.Context;
using Portfolio.DTO.Request.ThemeMode;
using Portfolio.DTO.Response.ThemeMode;
using Portfolio.Interface.Abstrack;

namespace Portfolio.Business;

public class ThemeModeService : IThemeMode
{
    private readonly AppDbContext _context;

    public ThemeModeService(AppDbContext context)
    {
        _context = context;
    }

    public Result ChangeThemeMode(ThemeModeChangeRequest request)
    {
        var Result = _context.ThemeModes.ToList();

        foreach (var item in Result)
        {
            if (item.Id == request.Id)
            {
                item.Status = (int)StatusEnum.Active;
            }
            else
            {
                item.Status = (int)StatusEnum.Passive;
            }
            _context.ThemeModes.Update(item);
        }
        _context.SaveChanges();

        return new Result(true, "Theme mode has been changed.");


    }

    public DataResult<GetActiveThemeModeResponse> GetActiveThemeMode()
    {
        var ActiveThemeMode = _context.ThemeModes.Where(x => x.Status == (int)StatusEnum.Active).FirstOrDefault();

        var ActiveThemeResponse = new GetActiveThemeModeResponse();

        switch (ActiveThemeMode?.Mode)
        {
            case (int)ThemeMode.Dark:
                ActiveThemeResponse.ActiveThemeMode = (int)ThemeMode.Dark;
                break;
            case (int)ThemeMode.Light:
                ActiveThemeResponse.ActiveThemeMode = (int)ThemeMode.Light;
                break;
            default:
                ActiveThemeResponse.ActiveThemeMode = (int)ThemeMode.Light;
                break;
        }

        return new DataResult<GetActiveThemeModeResponse>(true, "The active theme was successfully introduced.", ActiveThemeResponse);
    }
}

