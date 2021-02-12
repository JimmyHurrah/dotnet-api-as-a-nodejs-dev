using Microsoft.AspNetCore.Http;
using System;
using static SayHelloGorilla;

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
    var output = SayHello(input);
    await ctx.Response.WriteAsJsonAsync(output);
  };
}
