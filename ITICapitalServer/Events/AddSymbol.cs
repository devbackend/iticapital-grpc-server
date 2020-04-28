using System;
using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct AddSymbol
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("isin")] public string Isin { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("short_name")] public string ShortName { get; set; }
        [JsonPropertyName("long_name")] public string LongName { get; set; }
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("decimals")] public int Decimals { get; set; }
        [JsonPropertyName("lot_size")] public int LotSize { get; set; }
        [JsonPropertyName("price_step")] public double PriceStep { get; set; }
        [JsonPropertyName("exchange_name")] public string ExchangeName { get; set; }
        [JsonPropertyName("expiry_date")] public DateTime ExpiryDate { get; set; }
        [JsonPropertyName("days_before_expiry")] public double DaysBeforeExpiry { get; set; }
        [JsonPropertyName("price_step_point")] public double PriceStepPoint { get; set; }
        [JsonPropertyName("strike")] public double Strike { get; set; }
    }
}