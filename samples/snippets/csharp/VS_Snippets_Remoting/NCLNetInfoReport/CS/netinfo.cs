// Sample NCLNetInfoReport

using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Examples
{
    class ShowNetInformation
    {
        //<Snippet1>
        public static void ShowIPStatistics(NetworkInterfaceComponent version)
        {
            //<Snippet20>
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat;

            Console.WriteLine();
            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                    ipstat = properties.GetIPv4GlobalStatistics();
                    Console.WriteLine("IPv4 Statistics");
                    break;
                case NetworkInterfaceComponent.IPv6:
                    ipstat = properties.GetIPv6GlobalStatistics();
                    Console.WriteLine("IPv6 Statistics");
                    break;
                default:
                    throw new ArgumentException("Invalid version provided.", nameof(version));
            }
            //</Snippet20>

            Console.WriteLine($"  Forwarding enabled ...................... : {ipstat.ForwardingEnabled}");
            Console.WriteLine($"  Interfaces .............................. : {ipstat.NumberOfInterfaces}");
            Console.WriteLine($"  IP addresses ............................ : {ipstat.NumberOfIPAddresses}");
            Console.WriteLine($"  Routes .................................. : {ipstat.NumberOfRoutes}");
            Console.WriteLine($"  Default TTL ............................. : {ipstat.DefaultTtl}");
            Console.WriteLine();

            Console.WriteLine($"  Inbound Packet Data:");
            Console.WriteLine($"      Received ............................ : {ipstat.ReceivedPackets}");
            Console.WriteLine($"      Forwarded ........................... : {ipstat.ReceivedPacketsForwarded}");
            Console.WriteLine($"      Delivered ........................... : {ipstat.ReceivedPacketsDelivered}");
            Console.WriteLine($"      Discarded ........................... : {ipstat.ReceivedPacketsDiscarded}");
            Console.WriteLine($"      Header Errors ....................... : {ipstat.ReceivedPacketsWithHeadersErrors}");
            Console.WriteLine($"      Address Errors ...................... : {ipstat.ReceivedPacketsWithAddressErrors}");
            Console.WriteLine($"      Unknown Protocol Errors ............. : {ipstat.ReceivedPacketsWithUnknownProtocol}");
            Console.WriteLine();

            Console.WriteLine($"  Outbound Packet Data:");
            Console.WriteLine($"      Requested ........................... : {ipstat.OutputPacketRequests}");
            Console.WriteLine($"      Discarded ........................... : {ipstat.OutputPacketsDiscarded}");
            Console.WriteLine($"      No Routing Discards ................. : {ipstat.OutputPacketsWithNoRoute}");
            Console.WriteLine($"      Routing Entry Discards .............. : {ipstat.OutputPacketRoutingDiscards}");
            Console.WriteLine();

            Console.WriteLine($"  Reassembly Data:");
            Console.WriteLine($"      Reassembly Timeout .................. : {ipstat.PacketReassemblyTimeout}");
            Console.WriteLine($"      Reassemblies Required ............... : {ipstat.PacketReassembliesRequired}");
            Console.WriteLine($"      Packets Reassembled ................. : {ipstat.PacketsReassembled}");
            Console.WriteLine($"      Packets Fragmented .................. : {ipstat.PacketsFragmented}");
            Console.WriteLine($"      Fragment Failures ................... : {ipstat.PacketFragmentFailures}");
            Console.WriteLine();
        }
        // The example displays the following output:
        // IPv4 Statistics
        //   Forwarding enabled...................... : True
        //   Interfaces ............................. : 8
        //   IP addresses ........................... : 31
        //   Routes.................................. : 9
        //   Default TTL ............................ : 128
        //
        //   Inbound Packet Data:
        //       Received............................ : 1133821
        //       Forwarded........................... : 0
        //       Delivered........................... : 1212372
        //       Discarded........................... : 32411
        //       Header Errors ...................... : 0
        //       Address Errors ..................... : 0
        //       Unknown Protocol Errors............. : 0
        //
        //   Outbound Packet Data:
        //       Requested........................... : 1941303
        //       Discarded........................... : 272738
        //       No Routing Discards................. : 0
        //       Routing Entry Discards.............. : 0
        //
        //   Reassembly Data:
        //       Reassembly Timeout .................. : 60
        //       Reassemblies Required ............... : 0
        //       Packets Reassembled ................. : 0
        //       Packets Fragmented .................. : 0
        //       Fragment Failures ................... : 0
        //</Snippet1>

        //<Snippet2>
        public static void ShowTcpStatistics(NetworkInterfaceComponent version)
        {
            //<Snippet21>
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpStatistics tcpstat;

            Console.WriteLine();
            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                    tcpstat = properties.GetTcpIPv4Statistics();
                    Console.WriteLine("TCP/IPv4 Statistics:");
                    break;
                case NetworkInterfaceComponent.IPv6:
                    tcpstat = properties.GetTcpIPv6Statistics();
                    Console.WriteLine("TCP/IPv6 Statistics:");
                    break;
                default:
                    throw new ArgumentException("Invalid version provided.", nameof(version));
            }
            //</Snippet21>

            Console.WriteLine($"  Minimum Transmission Timeout............. : {tcpstat.MinimumTransmissionTimeout}");
            Console.WriteLine($"  Maximum Transmission Timeout............. : {tcpstat.MaximumTransmissionTimeout}");
            Console.WriteLine();

            Console.WriteLine("  Connection Data:");
            Console.WriteLine($"      Current  ............................ : {tcpstat.CurrentConnections}");
            Console.WriteLine($"      Cumulative .......................... : {tcpstat.CumulativeConnections}");
            Console.WriteLine($"      Initiated ........................... : {tcpstat.ConnectionsInitiated}");
            Console.WriteLine($"      Accepted ............................ : {tcpstat.ConnectionsAccepted}");
            Console.WriteLine($"      Failed Attempts ..................... : {tcpstat.FailedConnectionAttempts}");
            Console.WriteLine($"      Reset ............................... : {tcpstat.ResetConnections}");
            Console.WriteLine();

            Console.WriteLine("  Segment Data:");
            Console.WriteLine($"      Received  ........................... : {tcpstat.SegmentsReceived}");
            Console.WriteLine($"      Sent ................................ : {tcpstat.SegmentsSent}");
            Console.WriteLine($"      Retransmitted ....................... : {tcpstat.SegmentsResent}");
            Console.WriteLine();
        }
        // The example displays the following output:
        // TCP/IPv4 Statistics:
        //   Minimum Transmission Timeout............. : 5
        //   Maximum Transmission Timeout............. : 4294967295
        //
        //   Connection Data:
        //       Current............................ : 77
        //       Cumulative.......................... : 107
        //       Initiated........................... : 6324
        //       Accepted............................ : 116
        //       Failed Attempts..................... : 105
        //       Reset............................... : 277
        //
        //   Segment Data:
        //       Received........................... : 1871498
        //       Sent................................ : 692931
        //       Retransmitted....................... : 0
        //</Snippet2>

        //<Snippet3>
        public static void ShowUdpStatistics(NetworkInterfaceComponent version)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            UdpStatistics udpStat;

            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                    udpStat = properties.GetUdpIPv4Statistics();
                    Console.WriteLine("UDP IPv4 Statistics");
                    break;
                case NetworkInterfaceComponent.IPv6:
                    udpStat = properties.GetUdpIPv6Statistics();
                    Console.WriteLine("UDP IPv6 Statistics");
                    break;
                default:
                    throw new ArgumentException("Invalid version provided.", nameof(version));
                    //    break;
            }

            Console.WriteLine($"  Datagrams Received ...................... : {udpStat.DatagramsReceived}");
            Console.WriteLine($"  Datagrams Sent .......................... : {udpStat.DatagramsSent}");
            Console.WriteLine($"  Incoming Datagrams Discarded ............ : {udpStat.IncomingDatagramsDiscarded}");
            Console.WriteLine($"  Incoming Datagrams With Errors .......... : {udpStat.IncomingDatagramsWithErrors}");
            Console.WriteLine($"  UDP Listeners ........................... : {udpStat.UdpListeners}");
            Console.WriteLine();
        }
        // The example displays the following output:
        // UDP IPv4 Statistics
        //   Datagrams Received...................... : 240196
        //   Datagrams Sent.......................... : 426341
        //   Incoming Datagrams Discarded............ : 25636
        //   Incoming Datagrams With Errors .......... : 6779
        //   UDP Listeners ........................... : 24
        //</Snippet3>

        //<Snippet4>
        public static void ShowEchoIcmpv4(IcmpV4Statistics stat4)
        {
            if (stat4 != null)
            {
                Console.WriteLine("ICMP v4 Echo Requests");
                Console.WriteLine($"  Sent ................................ : {stat4.EchoRequestsSent}");
                Console.WriteLine($"  Received ............................ : {stat4.EchoRequestsReceived}");
                Console.WriteLine("ICMP v4 Echo Replies");
                Console.WriteLine($"  Sent ................................ : {stat4.EchoRepliesSent}");
                Console.WriteLine($"  Received ............................ : {stat4.EchoRepliesReceived}");
            }
        }
        // The example displays the following output:
        // ICMP v4 Echo Requests
        //   Sent................................ : 0
        //   Received............................ : 0
        // ICMP v4 Echo Replies
        //   Sent................................ : 0
        //   Received............................ : 0

        public static void ShowEchoIcmpv6(IcmpV6Statistics stat6)
        {
            if (stat6 != null)
            {
                Console.WriteLine("ICMP v6 Echo Requests");
                Console.WriteLine($"  Sent ................................ : {stat6.EchoRequestsSent}");
                Console.WriteLine($"  Received ............................ : {stat6.EchoRequestsReceived}");
                Console.WriteLine("ICMP v6 Echo Replies");
                Console.WriteLine($"  Sent ................................ : {stat6.EchoRepliesSent}");
                Console.WriteLine($"  Received ............................ : {stat6.EchoRepliesReceived}");
            }
        }
        // The example displays the following output:
        // ICMP v6 Echo Requests
        //   Sent................................ : 0
        //   Received............................ : 0
        // ICMP v6 Echo Replies
        //   Sent................................ : 0
        //   Received............................ : 0
        //</Snippet4>

        //<Snippet5>
        internal static void ShowIcmpv4MessagesAndErrors(IcmpV4Statistics stat4)
        {
            if (stat4 != null)
            {
                Console.WriteLine("ICMP v4 Messages");
                Console.WriteLine($"  Sent ................................ : {stat4.MessagesSent}");
                Console.WriteLine($"  Received ............................ : {stat4.MessagesReceived}");
                Console.WriteLine("ICMP v4 Errors");
                Console.WriteLine($"  Sent ................................ : {stat4.ErrorsSent}");
                Console.WriteLine($"  Received ............................ : {stat4.ErrorsReceived}");
            }
        }
        // The example displays the following output:
        // ICMP v4 Messages
        //   Sent................................ : 14383
        //   Received............................ : 14343
        // ICMP v4 Errors
        //   Sent ............................... : 0
        //   Received............................ : 0

        internal static void ShowIcmpv6MessagesAndErrors(IcmpV6Statistics stat6)
        {
            if (stat6 != null && Socket.OSSupportsIPv6)
            {
                Console.WriteLine("ICMP v6 Messages");
                Console.WriteLine($"  Sent ................................ : {stat6.MessagesSent}");
                Console.WriteLine($"  Received ............................ : {stat6.MessagesReceived}");
                Console.WriteLine("ICMP v6 Errors");
                Console.WriteLine($"  Sent ................................ : {stat6.ErrorsSent}");
                Console.WriteLine($"  Received ............................ : {stat6.ErrorsReceived}");
            }
        }
        // The example displays the following output:
        // ICMP v6 Messages
        //   Sent................................ : 0
        //   Received............................ : 0
        // ICMP v6 Errors
        //   Sent ............................... : 0
        //   Received............................ : 0
        //</Snippet5>

        //<Snippet6>
        public static void ShowIcmpV4Statistics()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics stat = properties.GetIcmpV4Statistics();
            Console.WriteLine("ICMP V4 Statistics:");
            Console.WriteLine("  Messages");
            Console.WriteLine($"    Sent ................................ : {stat.MessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.MessagesReceived}");
            Console.WriteLine("  Errors");
            Console.WriteLine($"    Sent ................................ : {stat.ErrorsSent}");
            Console.WriteLine($"    Received ............................ : {stat.ErrorsReceived}");
            Console.WriteLine("  Echo Requests");
            Console.WriteLine($"    Sent ................................ : {stat.EchoRequestsSent}");
            Console.WriteLine($"    Received ............................ : {stat.EchoRequestsReceived}");
            Console.WriteLine("  Echo Replies");
            Console.WriteLine($"    Sent ................................ : {stat.EchoRepliesSent}");
            Console.WriteLine($"    Received ............................ : {stat.EchoRepliesReceived}");
            Console.WriteLine("  Destination Unreachables");
            Console.WriteLine($"    Sent ................................ : {stat.DestinationUnreachableMessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.DestinationUnreachableMessagesReceived}");
            Console.WriteLine("  Source Quenches");
            Console.WriteLine($"    Sent ................................ : {stat.SourceQuenchesSent}");
            Console.WriteLine($"    Received ............................ : {stat.SourceQuenchesReceived}");
            Console.WriteLine("  Redirects");
            Console.WriteLine($"    Sent ................................ : {stat.RedirectsSent}");
            Console.WriteLine($"    Received ............................ : {stat.RedirectsReceived}");
            Console.WriteLine("  TimeExceeded");
            Console.WriteLine($"    Sent ................................ : {stat.TimeExceededMessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.TimeExceededMessagesReceived}");
            Console.WriteLine("  Parameter Problems");
            Console.WriteLine($"    Sent ................................ : {stat.ParameterProblemsSent}");
            Console.WriteLine($"    Received ............................ : {stat.ParameterProblemsReceived}");
            Console.WriteLine("  Timestamp Requests");
            Console.WriteLine($"    Sent ................................ : {stat.TimestampRequestsSent}");
            Console.WriteLine($"    Received ............................ : {stat.TimestampRequestsReceived}");
            Console.WriteLine("  Timestamp Replies");
            Console.WriteLine($"    Sent ................................ : {stat.TimestampRepliesSent}");
            Console.WriteLine($"    Received ............................ : {stat.TimestampRepliesReceived}");
            Console.WriteLine("  Address Mask Requests");
            Console.WriteLine($"    Sent ................................ : {stat.AddressMaskRequestsSent}");
            Console.WriteLine($"    Received ............................ : {stat.AddressMaskRequestsReceived}");
            Console.WriteLine("  Address Mask Replies");
            Console.WriteLine($"    Sent ................................ : {stat.AddressMaskRepliesSent}");
            Console.WriteLine($"    Received ............................ : {stat.AddressMaskRepliesReceived}");
            Console.WriteLine();
        }
        // The example displays the following output:
        // ICMP V4 Statistics:
        //  Messages
        //    Sent................................ : 14235
        //    Received............................ : 14195
        //  Errors
        //    Sent ............................... : 0
        //    Received............................ : 0
        //  Echo Requests
        //    Sent................................ : 0
        //    Received............................ : 0
        //  Echo Replies
        //    Sent................................ : 0
        //    Received............................ : 0
        //  Destination Unreachables
        //    Sent................................ : 14235
        //    Received............................ : 14195
        //  Source Quenches
        //    Sent................................ : 0
        //    Received............................ : 0
        //  Redirects
        //    Sent ............................... : 0
        //    Received............................ : 0
        //  TimeExceeded
        //    Sent ............................... : 0
        //    Received............................ : 0
        //  Parameter Problems
        //    Sent................................ : 0
        //    Received............................ : 0
        //  Timestamp Requests
        //    Sent................................ : 0
        //    Received............................ : 0
        //  Timestamp Replies
        //    Sent................................ : 0
        //    Received............................ : 0
        //  Address Mask Requests
        //    Sent ............................... : 0
        //    Received............................ : 0
        //  Address Mask Replies
        //    Sent ............................... : 0
        //    Received............................ : 0
        //</Snippet6>

        //<Snippet7>
        public static void ShowIcmpV6Statistics()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV6Statistics stat = properties.GetIcmpV6Statistics();
            Console.WriteLine("ICMP V6 Statistics:");
            Console.WriteLine("  Messages");
            Console.WriteLine($"    Sent ................................ : {stat.MessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.MessagesReceived}");
            Console.WriteLine("  Errors");
            Console.WriteLine($"    Sent ................................ : {stat.ErrorsSent}");
            Console.WriteLine($"    Received ............................ : {stat.ErrorsReceived}");
            Console.WriteLine("  Echo Requests");
            Console.WriteLine($"    Sent ................................ : {stat.EchoRequestsSent}");
            Console.WriteLine($"    Received ............................ : {stat.EchoRequestsReceived}");
            Console.WriteLine("  Echo Replies");
            Console.WriteLine($"    Sent ................................ : {stat.EchoRepliesSent}");
            Console.WriteLine($"    Received ............................ : {stat.EchoRepliesReceived}");
            Console.WriteLine("  Destination Unreachables");
            Console.WriteLine($"    Sent ................................ : {stat.DestinationUnreachableMessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.DestinationUnreachableMessagesReceived}");
            Console.WriteLine("  Parameter Problems");
            Console.WriteLine($"    Sent ................................ : {stat.ParameterProblemsSent}");
            Console.WriteLine($"    Received ............................ : {stat.ParameterProblemsReceived}");
            Console.WriteLine("  Packets Too Big");
            Console.WriteLine($"    Sent ................................ : {stat.PacketTooBigMessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.PacketTooBigMessagesReceived}");
            Console.WriteLine("  Redirects");
            Console.WriteLine($"    Sent ................................ : {stat.RedirectsSent}");
            Console.WriteLine($"    Received ............................ : {stat.RedirectsReceived}");
            Console.WriteLine("  Router Advertisements");
            Console.WriteLine($"    Sent ................................ : {stat.RouterAdvertisementsSent}");
            Console.WriteLine($"    Received ............................ : {stat.RouterAdvertisementsReceived}");
            Console.WriteLine("  Router Solicitations");
            Console.WriteLine($"    Sent ................................ : {stat.RouterSolicitsSent}");
            Console.WriteLine($"    Received ............................ : {stat.RouterSolicitsReceived}");
            Console.WriteLine("  Time Exceeded");
            Console.WriteLine($"    Sent ................................ : {stat.TimeExceededMessagesSent}");
            Console.WriteLine($"    Received ............................ : {stat.TimeExceededMessagesReceived}");
            Console.WriteLine("  Neighbor Advertisements");
            Console.WriteLine($"    Sent ................................ : {stat.NeighborAdvertisementsSent}");
            Console.WriteLine($"    Received ............................ : {stat.NeighborAdvertisementsReceived}");
            Console.WriteLine("  Neighbor Solicitations");
            Console.WriteLine($"    Sent ................................ : {stat.NeighborSolicitsSent}");
            Console.WriteLine($"    Received ............................ : {stat.NeighborSolicitsReceived}");
            Console.WriteLine("  Membership Queries");
            Console.WriteLine($"    Sent ................................ : {stat.MembershipQueriesSent}");
            Console.WriteLine($"    Received ............................ : {stat.MembershipQueriesReceived}");
            Console.WriteLine("  Membership Reports");
            Console.WriteLine($"    Sent ................................ : {stat.MembershipReportsSent}");
            Console.WriteLine($"    Received ............................ : {stat.MembershipReportsReceived}");
            Console.WriteLine("  Membership Reductions");
            Console.WriteLine($"    Sent ................................ : {stat.MembershipReductionsSent}");
            Console.WriteLine($"    Received ............................ : {stat.MembershipReductionsReceived}");
            Console.WriteLine();
        }
        // The example displays the following output:
        // ICMP V6 Statistics:
          // Messages
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Errors
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Echo Requests
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Echo Replies
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Destination Unreachables
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Parameter Problems
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Packets Too Big
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Redirects
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Router Advertisements
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Router Solicitations
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Time Exceeded
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Neighbor Advertisements
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Neighbor Solicitations
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Membership Queries
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Membership Reports
          //   Sent ................................ : 0
          //   Received ............................ : 0
          // Membership Reductions
          //   Sent ................................ : 0
          //   Received ............................ : 0
        //</Snippet7>

        //<Snippet14>
        private static void ShowIPAddresses(string label, IPAddressCollection addresses)
        {
            if (addresses.Count == 0)
                return;

            foreach (IPAddress ip in addresses)
            {
                string address = ip.ToString();
                string line = address.PadLeft(label.Length + address.Length + 1);
                Console.WriteLine(line);
            }
        }
        //</Snippet14>
        //<snippet8>
        public static void ShowIPAddresses(IPInterfaceProperties adapterProperties)
        {
            //<Snippet9>
            IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
            if (dnsServers != null)
            {
                foreach (IPAddress dns in dnsServers)
                {
                    Console.WriteLine($"  DNS Servers ............................. : {dns}");
                }
            }
            //</Snippet9>
            IPAddressInformationCollection anyCast = adapterProperties.AnycastAddresses;
            if (anyCast != null)
            {
                foreach (IPAddressInformation any in anyCast)
                {
                    string isTransient = any.IsTransient ? "Transient" : "";
                    string isDnsEligible = any.IsDnsEligible ? "DNS Eligible" : "";
                    Console.WriteLine($"  Anycast Address .......................... : {any.Address} {isTransient} {isDnsEligible}");
                }
                Console.WriteLine();
            }

            MulticastIPAddressInformationCollection multiCast = adapterProperties.MulticastAddresses;
            if (multiCast != null)
            {
                foreach (IPAddressInformation multi in multiCast)
                {
                    string isTransient = multi.IsTransient ? "Transient" : "";
                    string isDnsEligible = multi.IsDnsEligible ? "DNS Eligible" : "";
                    Console.WriteLine($"  Multicast Address ....................... : {multi.Address} {isTransient} {isDnsEligible}");
                }
                Console.WriteLine();
            }
            //<Snippet10>
            UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
            if (uniCast != null)
            {
                foreach (UnicastIPAddressInformation uni in uniCast)
                {
                    Console.WriteLine($"  Unicast Address ......................... : {uni.Address}");
                    Console.WriteLine($"     Prefix Origin ........................ : {uni.PrefixOrigin}");
                    Console.WriteLine($"     Suffix Origin ........................ : {uni.SuffixOrigin}");
                    Console.WriteLine($"     Duplicate Address Detection .......... : {uni.DuplicateAddressDetectionState}");

                    // Calculate the date and time at the end of the lifetimes.
                    DateTime now = DateTime.Now;
                    DateTime addressValidLifetime = now + TimeSpan.FromSeconds(uni.AddressValidLifetime);
                    DateTime addressPreferredLifetime = now + TimeSpan.FromSeconds(uni.AddressPreferredLifetime);
                    DateTime dhcpLeaseLifetime = now + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime);

                    // Format the lifetimes as "Sunday, February 16, 2003 11:33:44 PM" if en-us is the current culture.
                    string lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";

                    // Convert to the local time zone and to a string using the format.
                    string addressValidLifetimeString =
                        addressValidLifetime.ToLocalTime().ToString(
                            lifeTimeFormat,
                            System.Globalization.CultureInfo.CurrentCulture
                        );

                    string addressPreferredLifetimeString =
                        addressPreferredLifetime.ToLocalTime().ToString(
                            lifeTimeFormat,
                            System.Globalization.CultureInfo.CurrentCulture
                        );

                    string dhcpLeaseLifetimeString =
                        dhcpLeaseLifetime.ToLocalTime().ToString(
                            lifeTimeFormat,
                            System.Globalization.CultureInfo.CurrentCulture
                        );

                    Console.WriteLine($"     Valid Life Time ...................... : {addressValidLifetimeString}");
                    Console.WriteLine($"     Preferred life time .................. : {addressPreferredLifetimeString}");
                    Console.WriteLine($"     DHCP Leased Life Time ................ : {dhcpLeaseLifetimeString}");
                }
                Console.WriteLine();
            }
            //</Snippet10>
        }
        //</snippet8>

        //<Snippet11>
        public static void ShowInterfaceStatistics(NetworkInterface adapter)
        {
            IPv4InterfaceStatistics stats = adapter.GetIPv4Statistics();
            Console.WriteLine();
            Console.WriteLine("  Interface Statistics:");
            Console.WriteLine($"     Bytes sent ........................... : {stats.BytesSent}");
            Console.WriteLine($"     Bytes received ....................... : {stats.BytesReceived}");
            Console.WriteLine($"     Unicast Packets Sent ................. : {stats.UnicastPacketsSent}");
            Console.WriteLine($"     Unicast Packets Received ............. : {stats.UnicastPacketsReceived}");
            Console.WriteLine($"     Non Unicast Packets Sent ............. : {stats.NonUnicastPacketsSent}");
            Console.WriteLine($"     Non Unicast Packets Received ......... : {stats.NonUnicastPacketsReceived}");
            Console.WriteLine($"     Incoming Packets Discarded ........... : {stats.IncomingPacketsDiscarded}");
            Console.WriteLine($"     Outgoing Packets Discarded ........... : {stats.OutgoingPacketsDiscarded}");
            Console.WriteLine($"     Incoming Packets Errors .............. : {stats.IncomingPacketsWithErrors}");
            Console.WriteLine($"     Outgoing packets Errors .............. : {stats.OutgoingPacketsWithErrors}");
            Console.WriteLine($"     Incoming Unknown Protocol Errors ..... : {stats.IncomingUnknownProtocolPackets}");
            Console.WriteLine($"     Speed ................................ : {adapter.Speed}");
            Console.WriteLine($"     Output queue length................... : {stats.OutputQueueLength}");
            Console.WriteLine();
        }
        //</Snippet11>
        //<Snippet12>
        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine($"Interface information for {computerProperties.HostName}.{computerProperties.DomainName}");
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            Console.WriteLine($"  Number of interfaces .................... : {nics.Length}");
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(string.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine($"  Interface type .......................... : {adapter.NetworkInterfaceType}");
                Console.WriteLine($"  Physical Address ........................ : {adapter.GetPhysicalAddress()}");
                Console.WriteLine($"  Operational status ...................... : {adapter.OperationalStatus}");
                string versions = string.Empty;

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions += "IPv4";
                }

                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    versions += " IPv6";
                }

                Console.WriteLine($"  IP version .............................. : {versions.Trim()}");
                ShowIPAddresses(properties);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }

                Console.WriteLine($"  DNS suffix .............................. : {properties.DnsSuffix}");

                //<Snippet13>
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    Console.WriteLine($"  MTU...................................... : {ipv4.Mtu}");
                    if (ipv4.UsesWins)
                    {

                        IPAddressCollection winsServers = properties.WinsServersAddresses;
                        if (winsServers.Count > 0)
                        {
                            string label = "  WINS Servers ............................ :";
                            ShowIPAddresses(label, winsServers);
                        }
                    }
                }
                //</Snippet13>

                Console.WriteLine($"  DNS enabled ............................. : {properties.IsDnsEnabled}");
                Console.WriteLine($"  Dynamically configured DNS .............. : {properties.IsDynamicDnsEnabled}");
                Console.WriteLine($"  Receive Only ............................ : {adapter.IsReceiveOnly}");
                Console.WriteLine($"  Multicast ............................... : {adapter.SupportsMulticast}");
                ShowInterfaceStatistics(adapter);

                Console.WriteLine();
            }
        }
        // The example displays the following output:
        // Interface information for andromeda.
        //   Number of interfaces.................... : 8
        //
        // Intel(R) I211 Gigabit Network Connection #2
        // ===========================================
        //   Interface type .......................... : Ethernet
        //   Physical Address ........................ : 18C04DA29FA7
        //   Operational status ...................... : Down
        //   IP version .............................. : IPv4 IPv6
        //   DNS Servers ............................. : 192.168.1.1
        //
        //   Multicast Address ....................... : ff01::1%13
        //   Multicast Address ....................... : ff02::1%13
        //   Multicast Address ....................... : ff02::1:ff2e:64d1%13
        //   Multicast Address ....................... : 224.0.0.1
        //
        //   Unicast Address ......................... : fe80::b19c:2968:d82e:64d1%13
        //      Prefix Origin ........................ : WellKnown
        //      Suffix Origin ........................ : LinkLayerAddress
        //      Duplicate Address Detection .......... : Deprecated
        //      Valid Life Time ...................... : Friday, November 04, 2157  02:18:41 AM
        //      Preferred life time .................. : Friday, November 04, 2157  02:18:41 AM
        //      DHCP Leased Life Time ................ : Tuesday, September 28, 2021  08:03:02 AM
        //   Unicast Address ......................... : 169.254.100.209
        //      Prefix Origin ........................ : WellKnown
        //      Suffix Origin ........................ : LinkLayerAddress
        //      Duplicate Address Detection .......... : Tentative
        //      Valid Life Time ...................... : Friday, November 04, 2157  02:18:41 AM
        //      Preferred life time .................. : Friday, November 04, 2157  02:18:41 AM
        //      DHCP Leased Life Time ................ : Tuesday, September 28, 2021  08:02:55 AM
        //
        //   DNS suffix .............................. : hsd1.ga.comcast.net
        //   MTU...................................... : 1500
        //   DNS enabled ............................. : False
        //   Dynamically configured DNS .............. : True
        //   Receive Only ............................ : False
        //   Multicast ............................... : True
        //
        //   Interface Statistics:
        //      Bytes sent ........................... : 0
        //      Bytes received ....................... : 0
        //      Unicast Packets Sent ................. : 0
        //      Unicast Packets Received ............. : 0
        //      Non Unicast Packets Sent ............. : 0
        //      Non Unicast Packets Received ......... : 0
        //      Incoming Packets Discarded ........... : 0
        //      Outgoing Packets Discarded ........... : 0
        //      Incoming Packets Errors .............. : 0
        //      Outgoing packets Errors .............. : 0
        //      Incoming Unknown Protocol Errors ..... : 0
        //      Speed ................................ : -1
        //      Output queue length................... : 0
        //</Snippet12>

        //<Snippet16>
        public static void ShowInterfaceSummary()
        {

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                Console.WriteLine($"Name: {adapter.Name}");
                Console.WriteLine(adapter.Description);
                Console.WriteLine(string.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine($"  Interface type .......................... : {adapter.NetworkInterfaceType}");
                Console.WriteLine($"  Operational status ...................... : {adapter.OperationalStatus}");
                string versions = string.Empty;

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions += "IPv4";
                }

                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    versions += " IPv6";
                }

                Console.WriteLine($"  IP version .............................. : {versions.Trim()}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // The example displays the following output:
        // Name: Ethernet 2
        // Intel(R) I211 Gigabit Network Connection #2
        // ===========================================
        //   Interface type .......................... : Ethernet
        //   Operational status ...................... : Down
        //   IP version .............................. : IPv4 IPv6
        //</Snippet16>

        //<Snippet17>
        public static void ShowActiveTcpConnections()
        {
            Console.WriteLine("Active TCP Connections");
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation c in connections)
            {
                Console.WriteLine($"{c.LocalEndPoint} <==> {c.RemoteEndPoint}");
            }
        }
        // The example displays the following output:
        // Active TCP Connections
        // 127.0.0.1:9010 <==> 127.0.0.1:49771
        // 127.0.0.1:9100 <==> 127.0.0.1:49768
        // 127.0.0.1:49768 <==> 127.0.0.1:9100
        // 127.0.0.1:49771 <==> 127.0.0.1:9010
        // 127.0.0.1:50387 <==> 127.0.0.1:50388
        // [...]
        //</Snippet17>

        //<Snippet18>
        public static void ShowActiveTcpListeners()
        {
            Console.WriteLine("Active TCP Listeners");
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] endPoints = properties.GetActiveTcpListeners();
            foreach (IPEndPoint e in endPoints)
            {
                Console.WriteLine(e.ToString());
            }
        }
        // The example displays the following output:
        // Active TCP Listeners
        // 0.0.0.0:135
        // 0.0.0.0:445
        // 0.0.0.0:5040
        // 0.0.0.0:5357
        // 0.0.0.0:27036
        // [...]
        //</Snippet18>

        //<Snippet19>
        public static void ShowActiveUdpListeners()
        {
            Console.WriteLine("Active UDP Listeners");
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] endPoints = properties.GetActiveUdpListeners();
            foreach (IPEndPoint e in endPoints)
            {
                Console.WriteLine(e.ToString());
            }
        }
        // The example displays the following output:
        // Active UDP Listeners
        // 0.0.0.0:500
        // 0.0.0.0:3702
        // 0.0.0.0:3702
        // 0.0.0.0:3702
        // 0.0.0.0:3702
        // [...]
        //</Snippet19>

        public static void Main()
        {
            //<Snippet15>
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine($"Computer name: {properties.HostName}");
            Console.WriteLine($"Domain name:   {properties.DomainName}");
            Console.WriteLine($"Node type:     {properties.NodeType}");
            Console.WriteLine($"DHCP scope:    {properties.DhcpScopeName}");
            Console.WriteLine($"WINS proxy?    {properties.IsWinsProxy}");
            // The example displays the following output:
            // Computer name: andromeda
            // Domain name:
            // Node type:     Hybrid
            // DHCP scope:
            // WINS proxy?    False
            //</Snippet15>

            ShowActiveTcpConnections();
            ShowActiveTcpListeners();
            ShowActiveUdpListeners();

            if (Socket.OSSupportsIPv4)
            {
                ShowIcmpV4Statistics();
                ShowIPStatistics(NetworkInterfaceComponent.IPv4);
                ShowTcpStatistics(NetworkInterfaceComponent.IPv4);
                ShowUdpStatistics(NetworkInterfaceComponent.IPv4);
                ShowEchoIcmpv4(properties.GetIcmpV4Statistics());
                ShowIcmpv4MessagesAndErrors(properties.GetIcmpV4Statistics());
            }

            Console.WriteLine();
            Console.WriteLine();

            if (Socket.OSSupportsIPv6)
            {
                ShowIcmpV6Statistics();
                ShowIPStatistics(NetworkInterfaceComponent.IPv6);
                ShowTcpStatistics(NetworkInterfaceComponent.IPv6);
                ShowUdpStatistics(NetworkInterfaceComponent.IPv6);
                ShowEchoIcmpv6(properties.GetIcmpV6Statistics());
                ShowIcmpv6MessagesAndErrors(properties.GetIcmpV6Statistics());
            }

            ShowNetworkInterfaces();
            ShowInterfaceSummary();
        }
    }
}
