using System.Text.Json.Serialization;

public record Friend(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name);
