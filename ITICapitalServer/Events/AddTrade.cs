using System;
using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct AddTrade
    {
        [JsonPropertyName("portfolio")] public string Portfolio { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("amount")] public double Amount { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("trade_id")] public string TradeId { get; set; }
        [JsonPropertyName("value")] public double Value { get; set; }
        [JsonPropertyName("accrued_coupon")] public double AccruedCoupon { get; set; }
    }
}