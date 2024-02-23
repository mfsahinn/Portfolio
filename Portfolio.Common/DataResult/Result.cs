using Newtonsoft.Json;
using Portfolio.Common.DataResult.Base;

namespace Portfolio.Common.DataResult;

public class Result:IResult
{
   [JsonProperty(Order = 1)]
    public bool Status { get; set; }

    [JsonProperty(Order = 2)]
    public string[]? Messages { get; set; }

    public Result()
    {
    }

    public Result(bool status, string message)
    {
        Status = status;
        Messages = new string[1] { message };
    }

    public Result(bool status, string[] messages)
    {
        Status = status;
        Messages = messages;
    }

    public Result(bool status, List<string> messages)
    {
        Status = status;
        Messages = messages.ToArray();
    }
}
