using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

  public class Client
  {
    public static void Main()
    {
      TcpChannel myChannel = new TcpChannel();
      ChannelServices.RegisterChannel(myChannel);
      MyServerImpl myObject =
         (MyServerImpl)Activator.GetObject(typeof(MyServerImpl),
                    "tcp://localhost:8085/SayHello");
      Console.WriteLine(myObject.MyMethod("ClientString"));
    }
  }
