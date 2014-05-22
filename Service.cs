// Service
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

[ServiceContract]
public interface IHelloService
{
  [OperationContract]
  string Greet (string name);
}

public class HelloService : IHelloService
{
  public string Greet (string name)
  {
    return "hola, " + name;
  }
}

public class Test
{
  public static void Main (string [] args)
  {
    var binding = new BasicHttpBinding ();
    var address = new Uri ("http://localhost:8080");
    var host = new ServiceHost (typeof (HelloService));
    host.AddServiceEndpoint (
      typeof (IHelloService), binding, address);
    host.Open ();
    Console.WriteLine ("Type [CR] to stop...");
    Console.ReadLine ();
    host.Close ();
  }
}