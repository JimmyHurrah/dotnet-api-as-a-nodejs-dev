using Microsoft.AspNetCore.Http;

public interface IApiEndpoint
{
  public string Path { get; }
  public string Method { get; }
  public RequestDelegate Handler { get; }
}
