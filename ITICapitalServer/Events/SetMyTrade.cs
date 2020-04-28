using System;
using System.Text.Json.Serialization;
using SmartCOM4Lib;

namespace ITICapitalServer.Events
{
    public struct SetMyTrade
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("portfolio")] public string Portfolio { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("volume")] public double Volume { get; set; }
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
        [JsonPropertyName("stock_order_number")] public string StockOrderId { get; set; }
        [JsonPropertyName("action")] public StOrder_Action Action { get; set; }
        [JsonPropertyName("value")] public double Value { get; set; }
        [JsonPropertyName("accrued_coupon")] public double AccruedCoupon { get; set; }
    }
}