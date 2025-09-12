public class App
{
  public IClient _apiInterface {get;}
  public void Run(IClient _apiInterface)
  {
    IClient client = new Client();
    var baseAddress = "https://swapi.info/api/";
    var requestUri = "planets";

    var json = await client.Read(baseAddress, requestUri);
    var root = JsonSerializer.Deserialize<List<Root>>(json);
  }
}