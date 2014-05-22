// Client
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

[ServiceContract]
public interface IHelloService
{
  [OperationContract]
  string Greet (string name);
}

public class HelloClient : ClientBase<IHelloService>, IHelloService
{
  public HelloClient (Binding binding, EndpointAddress address)
    : base (binding, address)
  {
  }

  public string Greet (string name)
  {
    return Channel.Greet (name);
  }
}

public class Test
{
  public static void Main (string [] args)
  {
    string name = args.Length > 0 ? args [0] : "Anonymous Joe";
    var binding = new BasicHttpBinding ();
    var address = new EndpointAddress ("http://localhost:8080");
    var client = new HelloClient (binding, address);
    Console.WriteLine (client.Greet (name));
  }
}