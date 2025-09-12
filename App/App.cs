using System.Text.Json.Serialization;
using System.Text.Json;

public class App
{
  public IClient _apiInterface { get; }
  public async Task Run(IClient _apiInterface)
  {
    const string baseAddress = "https://swapi.info/api/";
    const string requestUri = "planets";

    var json = await _apiInterface.Read(baseAddress, requestUri);
    var root = JsonSerializer.Deserialize<List<Root>>(json);

    System.Console.WriteLine("Loading Galaxy's Edge Planets");
    System.Console.WriteLine("******************************");
    foreach (var planet in root)
    {
      System.Console.WriteLine($"Planet {planet.name}, Population: {planet.population}, Diameter: {planet.diameter}, Surface Water Percentage {planet.surface_water}.");
    }
    System.Console.WriteLine();
    System.Console.WriteLine("Which property would you like to see?");
    var userInput = Console.ReadLine();
  }
}