using System;
using System.Text.Json.Serialization;
using SmartCOM4Lib;

namespace ITICapitalServer.Events
{
    public struct AddTick
    {
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("volume")] public double Volume { get; set; }
        [JsonPropertyName("trade_id")] public string TradeId { get; set; }
        [JsonPropertyName("action")] public StOrder_Action Action { get; set; }
    }
}