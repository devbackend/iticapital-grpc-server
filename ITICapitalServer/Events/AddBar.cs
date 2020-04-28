using System;
using System.Text.Json.Serialization;
using SmartCOM4Lib;

namespace ITICapitalServer.Events
{
    public struct AddBar
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("interval")] public StBarInterval Interval { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("open_price")] public double OpenPrice { get; set; }
        [JsonPropertyName("high_price")] public double HighPrice { get; set; }
        [JsonPropertyName("low_price")] public double LowPrice { get; set; }
        [JsonPropertyName("close_price")] public double ClosePrice { get; set; }
        [JsonPropertyName("volume")] public double Volume { get; set; }
        [JsonPropertyName("opened")] public double Opened { get; set; }
    }
}