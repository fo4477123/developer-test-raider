using System.Text.Json;
using System.Text.Json.Serialization;

public record User(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("index")] int Index,
    [property: JsonPropertyName("guid")] Guid guid,
    [property: JsonPropertyName("isActive")] bool IsActive,
    [property: JsonPropertyName("balance")] string Balance,
    [property: JsonPropertyName("iconName")] string? IconName,
    [property: JsonPropertyName("age")] int Age,
    [property: JsonPropertyName("eyeColor")] string EyeColor,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("gender")] string Gender,
    [property: JsonPropertyName("company")] string Company,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("phone")] string Phone,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("about")] string About,
    [property: JsonPropertyName("registered")] string Registered,
    [property: JsonPropertyName("latitude")] double Latitude,
    [property: JsonPropertyName("longitude")] double Longitude,
    [property: JsonPropertyName("tags")] string[] Tags,
    [property: JsonPropertyName("friends")] Friend[] Friends,
    [property: JsonPropertyName("greeting")] string Greeting,
    [property: JsonPropertyName("favoriteFruit")] string FavoriteFruit);
