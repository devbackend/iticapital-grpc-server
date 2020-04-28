using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct OrderFailed
    {
        [JsonPropertyName("unique_id")] public int UniqueId { get; set; }
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
        [JsonPropertyName("reason")] public string Reason { get; set; }
    }
}