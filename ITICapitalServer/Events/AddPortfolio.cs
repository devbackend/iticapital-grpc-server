using System.Text.Json.Serialization;
using SmartCOM4Lib;

namespace ITICapitalServer.Events
{
    public struct AddPortfolio
    {
        [JsonPropertyName("row")] public int Row { get; set; }
        [JsonPropertyName("rows_count")] public int RowsCount { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("exchange")] public string Exchange { get; set; }
        [JsonPropertyName("status")] public StPortfolioStatus Status { get; set; }
    }
}