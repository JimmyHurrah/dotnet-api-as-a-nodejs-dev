using System;

public record SayHelloInput(string Name);
public record SayHelloOutput(string Message);

// You wanted a banana
// but what you got was a gorilla holding the banana
// and the entire jungle.
// /Joe Armstrong, creator of Erlang,
static class SayHelloGorilla
{
  public static
  Func<SayHelloInput, SayHelloOutput>
  SayHello = input =>
  {
    var msg = $"Hello {input.Name} {Environment.GetEnvironmentVariable("YO")}";
    return new SayHelloOutput(msg);
  };
}
