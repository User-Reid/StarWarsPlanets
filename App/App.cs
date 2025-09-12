using System.Text.Json.Serialization;
using System.Text.Json;

public class App
{
  public IClient _apiInterface { get; }
  public async Task Run(IClient _apiInterface)
  {
    const string baseAddress = "https://swapi.info/api/";
    const string requestUri = "planets";
    var confirmedPlanet = false;
    var json = await _apiInterface.Read(baseAddress, requestUri);
    var root = JsonSerializer.Deserialize<List<Root>>(json);

    Dictionary<string, Root> planetsDirectory = new();

    // foreach (var planet in root)
    // {
    //   planetsDirectory[planet.name] = planet;
    // }

    // do
    // {
    //   System.Console.WriteLine("Which planet would you like to get info on?");
    //   var userInput = Console.ReadLine();
    //   if (!planetsDirectory.ContainsKey(userInput))
    //   {
    //     System.Console.WriteLine("Invalid choice");
    //   }
    //   else
    //   {

    //     System.Console.WriteLine($"{planetsDirectory[userInput].name}: Population size of {planetsDirectory[userInput].population}, diameter of {planetsDirectory[userInput].diameter}, and surface water percentage of {planetsDirectory[userInput].surface_water}%.");
    //     confirmedPlanet = true;
    //   }
    // } while (confirmedPlanet == false);

    List<RelevantPlanetInfo> relevantPlanetInfoList = new List<RelevantPlanetInfo>();
    foreach (var planet in root)
    {
      relevantPlanetInfoList.Add(new RelevantPlanetInfo(planet));
    }

    System.Console.WriteLine(string.Join(", ", relevantPlanetInfoList));
    // System.Console.WriteLine("Loading Galaxy's Edge Planets");
    // System.Console.WriteLine("******************************");
    // foreach (var planet in root)
    // {
    //   System.Console.WriteLine($"Planet {planet.name}, Population: {planet.population}, Diameter: {planet.diameter}, Surface Water Percentage {planet.surface_water}.");
    // }
    // System.Console.WriteLine();
    // System.Console.WriteLine("Which property would you like to see?");
    // var userInput = Console.ReadLine();
  }
}

public struct RelevantPlanetInfo
{
  public string Name { get; init; }
  public int Population { get; init; }
  public int Diameter { get; init; }
  public int SurfaceWater { get; init; }

  public RelevantPlanetInfo(Root planet)
  {
    Name = planet.name;
    Population = int.Parse(planet.population);
    Diameter = int.Parse(planet.diameter);
    SurfaceWater = int.Parse(planet.surface_water);
  }
}