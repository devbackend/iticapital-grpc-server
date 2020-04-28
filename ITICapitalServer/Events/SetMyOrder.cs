using System;
using System.Text.Json.Serialization;
using SmartCOM4Lib;

namespace ITICapitalServer.Events
{
    public struct SetMyOrder
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("portfolio")] public string Portfolio { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("state")] public StOrder_State State { get; set; }
        [JsonPropertyName("action")] public StOrder_Action Action { get; set; }
        [JsonPropertyName("type")] public StOrder_Type Type { get; set; }
        [JsonPropertyName("validity")] public StOrder_Validity Validity { get; set; }
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("amount")] public double Amount { get; set; }
        [JsonPropertyName("price_stop")] public double PriceStop { get; set; }
        [JsonPropertyName("filled_volume")] public double FilledVolume { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
        [JsonPropertyName("stock_order_number")] public string StockOrderId { get; set; }
        [JsonPropertyName("unique_id")] public int UniqueId { get; set; }
    }
}