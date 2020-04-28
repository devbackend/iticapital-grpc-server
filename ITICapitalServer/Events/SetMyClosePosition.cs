using System;
using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct SetMyClosePosition
    {
        [JsonPropertyName("row")] public int Row {get; set;} 
        [JsonPropertyName("rows_count")] public int RowsCount {get; set;} 
        [JsonPropertyName("portfolio")] public string Portfolio {get; set;} 
        [JsonPropertyName("symbol")] public string Symbol {get; set;} 
        [JsonPropertyName("amount")] public double Amount {get; set;} 
        [JsonPropertyName("price_buy")] public double PriceBuy {get; set;} 
        [JsonPropertyName("price_sell")] public double PriceSell {get; set;} 
        [JsonPropertyName("date_time")] public DateTime DateTime {get; set;} 
        [JsonPropertyName("open_order_id")] public string OpenOrderId {get; set;} 
        [JsonPropertyName("close_order_id")] public string CloseOrderId {get; set;}
    }
}