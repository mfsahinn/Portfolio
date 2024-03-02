using Portfolio.Common.DataResult;
using Portfolio.Common.Enum;
using Portfolio.DataAccess.Context;
using Portfolio.DTO.Request.AboutMe;
using Portfolio.DTO.Response.AboutMe;
using Portfolio.Interface.Abstrack;

namespace Portfolio.Business;

public class AboutMeService : IAboutMe
{
    private readonly AppDbContext _context;

    public AboutMeService(AppDbContext context)
    {
        _context = context;
    }

    public Result Delete(AboutMeDeleteRequest request)
    {
        var Result = _context.AboutMe.Where(x => x.Id == request.Id).FirstOrDefault();

        if (Result != null)
        {
            Result.Status = (int)StatusEnum.Deleted;

            _context.AboutMe.Update(Result);

            var ResultContext = _context.SaveChanges();

            if (ResultContext < 0)
            {
                return new Result(true, "Deletion Successful");
            }
            else
            {
                return new Result(false, "An Error Occurred During The Delete Operation.");
            }

        }
        return new Result(false, "No record to delete was found.");
    }

    public DataResult<List<AboutMeGetAllResponse>> GetAll()
    {
        var allResult = _context.AboutMe
                                .Where(x => x.Status != (int)StatusEnum.Deleted && x.Status != (int)StatusEnum.Passive)
                                .Select(x => new AboutMeGetAllResponse
                                {
                                    Id = x.Id,
                                    About = x.About
                                })
                                .ToList();

        return new DataResult<List<AboutMeGetAllResponse>>(true, "List Fetch Successful.", allResult);
    }

    public PagingResult<AboutMeGetAllResponse> GetAll(DataTableRequest request)
    {
        return _context.AboutMe.Select(x=> new AboutMeGetAllResponse{
             Id=x.Id,
            About=x.About
        }).Prepare2DataTablePagingResult((DataTableRequest)request,"test");
    }

    public Result Insert(AboutMeInsertRequest request)
    {
        _context.AboutMe.Add(new Entities.AboutMe
        {
            Id = Guid.NewGuid(),
            Status = (int)StatusEnum.Active,
            About = request.About,
            CreatedDate=DateTime.Now
        });

        var ResultContent = _context.SaveChanges();

        if (ResultContent < 0)
        {
            return new Result(true, "Insert was successful.");
        }
        else
        {
            return new Result(false, "Addition Failed.");
        }
    }

    public Result SetPassive(AboutMeSetPassiveRequest request)
    {
        var Result = _context.AboutMe.Where(x => x.Id == request.Id).FirstOrDefault();

        if (Result != null)
        {
            Result.Status = (int)StatusEnum.Passive;

            _context.AboutMe.Update(Result);

            var ResultContent = _context.SaveChanges();

            if (ResultContent < 0)
            {
                return new Result(true, "Set Passive was successful.");
            }
            else
            {
                return new Result(false, "Set Passive Failed.");
            }

        }

        return new Result(false, "No record to set passive was found.");

    }

    public Result Update(AboutMeUpdateRequest request)
    {
        var Result = _context.AboutMe.Where(x => x.Id == request.Id).FirstOrDefault();

        if (Result != null)
        {
            Result.About = request.About;

            _context.AboutMe.Update(Result);
            var ResultContext = _context.SaveChanges();

            if (ResultContext < 0)
            {
                return new Result(true, "Update Successful");
            }
            else
            {
                return new Result(false, "An Error Occurred During The Update Operation.");
            }

        }

        return new Result(false, "No record to update was found.");
    }
}
