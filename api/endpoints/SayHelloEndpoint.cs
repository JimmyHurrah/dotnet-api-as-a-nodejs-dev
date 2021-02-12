using Microsoft.AspNetCore.Http;
using System;

record SayHelloInput(string Name);
record SayHelloOutput(string Message);

public class SayHelloEndpoint : IApiEndpoint
{
  public string
  Method => "GET";

  public string
  Path => "/hello/{name}";

  public RequestDelegate
  Handler => async (HttpContext ctx) =>
  {
    var name = (string)ctx.Request.RouteValues["Name"];
    var input = new SayHelloInput(name);
    var message = $"Hello {input.Name} {Environment.GetEnvironmentVariable("YO")}";
    var output = new SayHelloOutput(message);
    await ctx.Response.WriteAsJsonAsync(output);
  };
}
