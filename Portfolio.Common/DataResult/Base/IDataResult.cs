namespace Portfolio.Common.DataResult.Base;

public interface IDataResult<T>
{
    T? Data { get; set; }
}
