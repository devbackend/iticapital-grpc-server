using System.Text.Json.Serialization;

namespace ITICapitalServer.Events
{
    public struct OrderMoveFailed
    {
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
    }
}