using Portfolio.Common.DataResult;
using Portfolio.DTO.Request.AboutMe;
using Portfolio.DTO.Response.AboutMe;

namespace Portfolio.Interface.Abstrack;

public interface IAboutMe
{
    Result Insert(AboutMeInsertRequest request);
    Result Update(AboutMeUpdateRequest request);
    Result Delete(AboutMeDeleteRequest request);
    DataResult<List<AboutMeGetAllResponse>> GetAll();
    Result SetPassive(AboutMeSetPassiveRequest request);
    PagingResult<AboutMeGetAllResponse> GetAll(DataTableRequest request);
}
