using System.Text.Json;

IClient client = new Client();
var baseAddress = "https://swapi.info/api/";
var requestUri = "planets";

var json = await client.Read(baseAddress, requestUri);
var root = JsonSerializer.Deserialize<List<Root>>(json);

Console.ReadKey();
