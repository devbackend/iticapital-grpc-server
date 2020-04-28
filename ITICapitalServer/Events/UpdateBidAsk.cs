using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct UpdateBidAsk
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("bid_price")] public double BidPrice { get; set; }
        [JsonPropertyName("bid_size")] public double BidSize { get; set; }
        [JsonPropertyName("ask_price")] public double AskPrice { get; set; }
        [JsonPropertyName("ask_size")] public double AskSize { get; set; }
    }
}