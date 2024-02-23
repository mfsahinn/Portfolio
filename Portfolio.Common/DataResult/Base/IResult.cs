namespace Portfolio.Common.DataResult.Base;

public interface IResult
{
    bool Status { get; set; }
    string[] Messages { get; set; }
}
