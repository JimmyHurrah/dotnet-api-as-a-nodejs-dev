using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System;

WebHost
.CreateDefaultBuilder()
.ConfigureServices(s =>
{
  // DI and Services
})
.Configure(app =>
{
  app.UseRouting();
  app.UseEndpoints(e =>
  {
    // Fetch all endpoints and make them available in the api
    System.Console.WriteLine($"");
    System.Console.WriteLine("ROUTES");
    System.Console.WriteLine($"======");
    AppDomain.CurrentDomain
      .GetAssemblies()
      .SelectMany(s => s.GetTypes())
      .Where(p => typeof(IApiEndpoint).IsAssignableFrom(p) && !p.IsInterface)
      .Select(t => Activator.CreateInstance(t) as IApiEndpoint)
      .ToList()
      .ForEach(t =>
      {
        System.Console.WriteLine($"{t.Method} {t.Path}");
        e.MapMethods(t.Path, new []{ t.Method }, t.Handler);
      });
    System.Console.WriteLine($"======");
    System.Console.WriteLine($"");
  });
}).Build().Run();
