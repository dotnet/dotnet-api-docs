// <Internal>
// This program contains snippets for the following members:
// 1) System.Net.Sockets.MulticastOption;
// 2) System.Net.Sockets.MulticastOption.MulticastOption(IPAddress, IPAddress);
// 3) System.Net.Sockets.MulticastOption.Group;
// 4) System.Net.Sockets.MulticastOption.LocalAddress;
// </Internal>

//<Snippet1>

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

// This is the listener example that shows how to use the MulticastOption class.
// In particular, it shows how to use the MulticastOption(IPAddress, IPAddress)
// constructor, which you need to use if you have a host with more than one
// network card.
// The first parameter specifies the multicast group address, and the second
// specifies the local address of the network card you want to use for the data
// exchange.
// You must run this program in conjunction with the sender program as
// follows:
// Open a console window and run the listener from the command line.
// In another console window run the sender. In both cases you must specify
// the local IPAddress to use. To obtain this address run the ipconfig command
// from the command line.
//
namespace Mssc.TransportProtocols.Utilities
{
    public class TestMulticastOption
    {
        private static IPAddress s_mcastAddress;
        private static int s_mcastPort;
        private static Socket s_mcastSocket;
        private static MulticastOption s_mcastOption;

        // <Snippet3>
        private static void MulticastOptionProperties()
        {
            Console.WriteLine("Current multicast group is: " + s_mcastOption.Group);
            Console.WriteLine("Current multicast local address is: " + s_mcastOption.LocalAddress);
        }
        // </Snippet3>

        private static void StartMulticast()
        {
            try
            {
                s_mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                Console.Write("Enter the local IP address: ");

                IPAddress localIPAddr = IPAddress.Parse(Console.ReadLine());

                //IPAddress localIP = IPAddress.Any;
                EndPoint localEP = (EndPoint)new IPEndPoint(localIPAddr, s_mcastPort);

                s_mcastSocket.Bind(localEP);

                // <Snippet2>

                // Define a MulticastOption object specifying the multicast group
                // address and the local IPAddress.
                // The multicast group address is the same as the address used by the server.
                s_mcastOption = new MulticastOption(s_mcastAddress, localIPAddr);

                s_mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            s_mcastOption);
                // </Snippet2>
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveBroadcastMessages()
        {
            bool done = false;
            byte[] bytes = new byte[100];
            IPEndPoint groupEP = new(s_mcastAddress, s_mcastPort);
            EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for multicast packets.......");
                    Console.WriteLine("Enter ^C to terminate.");

                    s_mcastSocket.ReceiveFrom(bytes, ref remoteEP);

                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                      groupEP.ToString(),
                      Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                }

                s_mcastSocket.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Main(string[] args)
        {
            // Initialize the multicast address group and multicast port.
            // Both address and port are selected from the allowed sets as
            // defined in the related RFC documents. These are the same
            // as the values used by the sender.
            s_mcastAddress = IPAddress.Parse("224.168.100.2");
            s_mcastPort = 11000;

            // Start a multicast group.
            StartMulticast();

            // Display MulticastOption properties.
            MulticastOptionProperties();

            // Receive broadcast messages.
            ReceiveBroadcastMessages();
        }
    }
}
// </Snippet1>
