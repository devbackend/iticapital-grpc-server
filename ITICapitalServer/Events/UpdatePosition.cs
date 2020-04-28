using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct UpdatePosition
    {
        [JsonPropertyName("portfolio")] public string Portfolio { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("average_price")] public double AveragePrice { get; set; }
        [JsonPropertyName("amount")] public double Amount { get; set; }
        [JsonPropertyName("planned_amount")] public double PlannedAmount { get; set; }
    }
}