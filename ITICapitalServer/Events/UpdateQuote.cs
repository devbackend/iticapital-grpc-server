using System;
using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct UpdateQuote
    {
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("date_time")] public DateTime DateTime { get; set; }
        [JsonPropertyName("price_open")] public double PriceOpen { get; set; }
        [JsonPropertyName("price_high")] public double PriceHigh { get; set; }
        [JsonPropertyName("price_low")] public double PriceLow { get; set; }
        [JsonPropertyName("price_close")] public double PriceClose { get; set; }
        [JsonPropertyName("price_last")] public double PriceLast { get; set; }
        [JsonPropertyName("last_size")] public double LastSize { get; set; }
        [JsonPropertyName("session_volume")] public double SessionVolume { get; set; }
        [JsonPropertyName("price_bid")] public double PriceBid { get; set; }
        [JsonPropertyName("price_ask")] public double PriceAsk { get; set; }
        [JsonPropertyName("size_bid")] public double SizeBid { get; set; }
        [JsonPropertyName("size_ask")] public double SizeAsk { get; set; }
        [JsonPropertyName("opened_price")] public double OpenedPrice { get; set; }
        [JsonPropertyName("guarantee_buy")] public double GuaranteeBuy { get; set; }
        [JsonPropertyName("guarantee_sell")] public double GuaranteeSell { get; set; }
        [JsonPropertyName("price_high_limit")] public double PriceHighLimit { get; set; }
        [JsonPropertyName("price_low_limit")] public double PriceLowLimit { get; set; }
        [JsonPropertyName("is_trading")] public bool IsTrading { get; set; }
        [JsonPropertyName("volatility")] public double Volatility { get; set; }
        [JsonPropertyName("theoretical_price")] public double TheoreticalPrice { get; set; }
        [JsonPropertyName("step_price")] public double StepPrice { get; set; }
    }
}