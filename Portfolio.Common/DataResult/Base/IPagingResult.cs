namespace Portfolio.Common.DataResult.Base;

 public interface IPagingResult<T>
    {
        List<T?> Data { get; set; }
    }
