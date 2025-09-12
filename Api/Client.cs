using System.Text.Json.Serialization;

public class Client : IClient
{
  public async Task<string> Read(string baseAddress, string requestUri)
  {
    var client = new HttpClient();
    client.BaseAddress = new Uri(baseAddress);
    var response = await client.GetAsync(requestUri);
    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
  }
}

public record Root(
        [property: JsonPropertyName("name")] string name,
        [property: JsonPropertyName("rotation_period")] string rotation_period,
        [property: JsonPropertyName("orbital_period")] string orbital_period,
        [property: JsonPropertyName("diameter")] int diameter,
        [property: JsonPropertyName("climate")] string climate,
        [property: JsonPropertyName("gravity")] string gravity,
        [property: JsonPropertyName("terrain")] string terrain,
        [property: JsonPropertyName("surface_water")] int surface_water,
        [property: JsonPropertyName("population")] int population,
        [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
        [property: JsonPropertyName("films")] IReadOnlyList<string> films,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("edited")] DateTime edited,
        [property: JsonPropertyName("url")] string url
    );