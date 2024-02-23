using Newtonsoft.Json;
using Portfolio.Common.DataResult.Base;

namespace Portfolio.Common.DataResult;

public class DataResult<T>: IResult, IDataResult<T>
{
    [JsonProperty(Order = 1)]
    public bool Status { get; set; }

    [JsonProperty(Order = 2)]
    public string[] Messages { get; set; }

    [JsonProperty(Order = 3)]
    public T? Data { get; set; }

    public DataResult()
    {
    }

    public DataResult(bool status, string message, T data)
    {
        Status = status;
        Messages = new string[1] { message };
        Data = data;
    }

    public DataResult(bool status, string[] messages, T data)
    {
        Status = status;
        Messages = messages;
        Data = data;
    }

    public DataResult(bool status, List<string> messages, T data)
    {
        Status = status;
        Messages = messages.ToArray();
        Data = data;
    }
}
