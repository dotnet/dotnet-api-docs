// Supporting file for the ITransportHeaders_3_Server.cs

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class MyITransportHeadersClient
{
   public static void Main()
   {
      try
      {
         TcpChannel myTcpChannel1 = new TcpChannel();
         ChannelServices.RegisterChannel(myTcpChannel1);
         MyHelloServer myHelloServerObj =
         (MyHelloServer)Activator.GetObject(typeof(MyHelloServer),"tcp://localhost:8085/SayHello");
         if (myHelloServerObj == null)
            System.Console.WriteLine("Could not locate server");
         else
            Console.WriteLine(myHelloServerObj.MyHelloMethod("World"));
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception is raised on the client side: " +e.Message);
      }
   }
}