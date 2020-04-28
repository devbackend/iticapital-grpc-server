using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct SetPortfolio
    {
        [JsonPropertyName("portfolio")] public string Portfolio { get; set; }
        [JsonPropertyName("money")] public double Money { get; set; }
        [JsonPropertyName("leverage")] public double Leverage { get; set; }
        [JsonPropertyName("commission")] public double Commission { get; set; }
        [JsonPropertyName("profit")] public double Profit { get; set; }
        [JsonPropertyName("liquidation_price")] public double LiquidationPrice { get; set; }
        [JsonPropertyName("initial_margin")] public double InitialMargin { get; set; }
        [JsonPropertyName("total_assets")] public double TotalAssets { get; set; }
    }
}