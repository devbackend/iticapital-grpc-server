﻿using System.Text.Json.Serialization;

 namespace ITICapitalServer.Events
{
    public struct OrderMoveSucceeded
    {
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
    }
}