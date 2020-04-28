﻿using System.Text.Json.Serialization;

 namespace ITICapitalServer.Events
{
    public struct OrderCancelSucceeded
    {
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
    }
}