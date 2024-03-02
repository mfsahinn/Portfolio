using Newtonsoft.Json;
using Portfolio.Common.DataResult.Base;

namespace Portfolio.Common.DataResult;

public class PagingResult<T> : IResult, IPagingResult<T>
    {
        [JsonProperty(PropertyName = "Status", Order = 1)]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "Messages", Order = 2)]
        public string[] Messages { get; set; }

        [JsonProperty(PropertyName = "TotalRecordCount", Order = 3)]
        public int TotalRecordCount { get; set; }

        [JsonProperty(PropertyName = "FilteredRecordCount", Order = 4)]
        public int FilteredRecordCount { get; set; }

        [JsonProperty(PropertyName = "Data", Order = 5)]
        public List<T?> Data { get; set; }

        [JsonProperty(PropertyName = "RequestId", Order = 6)]
        public int RequestId { get; set; }
    }
