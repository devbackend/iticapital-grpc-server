using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct OrderSucceeded
    {
        [JsonPropertyName("unique_id")] public int UniqueId { get; set; }
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
    }
}