public interface IClient
{
  Task<string> Read(string baseAddress, string requestUri);
}