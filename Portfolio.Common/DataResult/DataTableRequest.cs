using Newtonsoft.Json;

namespace Portfolio.Common.DataResult;

    public class DataTableRequest
    {
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "length")]
        public int Length { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public List<Column>? Columns { get; set; }

        [JsonProperty(PropertyName = "search")]
        public Search? Search { get; set; }

        [JsonProperty(PropertyName = "order")]
        public List<Order>? Order { get; set; }
    }

    public class Column
    {
        [JsonProperty(PropertyName = "data")]
        public string? Data { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "searchable")]
        public bool Searchable { get; set; }

        [JsonProperty(PropertyName = "orderable")]
        public bool Orderable { get; set; }

        [JsonProperty(PropertyName = "search")]
        public Search? Search { get; set; }
    }

    public class Search
    {
        [JsonProperty(PropertyName = "value")]
        public string? Value { get; set; }

        [JsonProperty(PropertyName = "regex")]
        public string? Regex { get; set; }
    }

    public class Order
    {
        [JsonProperty(PropertyName = "column")]
        public int Column { get; set; }

        [JsonProperty(PropertyName = "dir")]
        public string? Dir { get; set; }
    }

