using Portfolio.Common.DataResult;
using Portfolio.DTO.Request.ThemeMode;
using Portfolio.DTO.Response.ThemeMode;

namespace Portfolio.Interface.Abstrack;

public interface IThemeMode
{
    DataResult<GetActiveThemeModeResponse> GetActiveThemeMode();

    Result ChangeThemeMode(ThemeModeChangeRequest request);
}
