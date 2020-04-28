using System;
using System.Text.Json.Serialization;
using SmartCOM4Lib;

namespace ITICapitalServer.Events
{
    public struct AddTickHistory
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("volume")] public double Volume { get; set; }
        [JsonPropertyName("trade_id")] public string TradeId { get; set; }
        [JsonPropertyName("action")] public StOrder_Action Action { get; set; }
    }
}