using System;
using System.Net;
using System.Threading.Channels;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace SubnetCalculator
{
    class CustomIPAddress
    {
        public string Address { get; private set; }
        public string SubnetMask { get; private set; }
        public string Broadcast { get; private set; }
        public string NetworkID { get; private set; }

        public CustomIPAddress(string ipAndPrefix)
        {
            string[] parts = ipAndPrefix.Split('/');
            Address = parts[0];
            int prefixLength = int.Parse(parts[1]);

            SubnetMask = CalculateSubnetMask(prefixLength);
            NetworkID = CalculateNetworkID(SubnetMask, Address);
            Broadcast = CalculateBroadcast(NetworkID, SubnetMask);
        }

        public string CalculateSubnetMask(int prefixLength)
        {
            int maskBinary = (int)(0xFFFFFFFF << (32 - prefixLength));
            byte[] maskBytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                maskBytes[3 - i] = (byte)(maskBinary >> (i * 8) & 0xFF);
            }
            return string.Join(".", maskBytes);
        }
        public byte[] ParseSubnet(string SubnetMask)
        {
            string[] split = SubnetMask.Split('.');
            byte[] result = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                result[i] = Convert.ToByte(split[i], 2);
            }
            return result;
        }

        public string CalculateNetworkID(string SubnetMask, string Address)
        {
            string[] addressParts = Address.Split(".");
            string[] maskParts = SubnetMask.Split(".");
            string[] networkIDParts = new string[4];

            for (int i = 0; i < 4; i++)
            {
                networkIDParts[i] = (int.Parse(addressParts[i]) & int.Parse(maskParts[i])).ToString();
            }

            return string.Join('.', networkIDParts);
        }

        public string CalculateBroadcast(string networkID, string subnetMask)
        {
            string[] networkIDParts = networkID.Split('.');
            string[] maskParts = subnetMask.Split('.');
            string[] broadcastParts = new string[4];

            for (int i = 0; i < 4; i++)
            {
                broadcastParts[i] = (int.Parse(networkIDParts[i]) | ~int.Parse(maskParts[i]) & 0xFF).ToString();
            }
            return string.Join('.', broadcastParts);
        }

        public bool IsSameNetwork(CustomIPAddress check)
        {
            if (this.NetworkID == check.NetworkID)
            {
                Console.Clear();
                Console.WriteLine("The provided addresses are in the same network.");
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The provided addresses are NOT in the same network.");
                return false;
            }
        }
        static void ExitAnimation()
        {
            int totalIterations = 42;
            for (int i = 0; i < totalIterations; i++)
            {
                Console.SetCursorPosition(0, 0);

                Console.Write("       . . . . o o o o o o");
                for (int s = 0; s < i / 2; s++)
                {
                    Console.Write(" o");
                }
                Console.WriteLine();

                var margin = "".PadLeft(i);
                Console.WriteLine(margin + "                _____      o");
                Console.WriteLine(margin + "       ____====  ]OO|_n_n__][.");
                Console.WriteLine(margin + "      [________]_|__|________)< ");
                Console.WriteLine(margin + "       oo    oo  'oo OOOO-| oo\\_");
                Console.WriteLine("   +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+");

                Thread.Sleep(25);
            }
        }

        internal static class Program
        {
            private static string GetLocalIPAddress()
            {
                string localIP = "";
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }

                return localIP;
            }
            private static bool IsValidInput(string input)
            {
                string pattern = @"^(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})/(\d{1,2})$";
                var match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    return false;
                }
                string ipAddress = match.Groups[1].Value;
                string[] octets = ipAddress.Split('.');
                foreach (string octet in octets)
                {
                    int number = int.Parse(octet);
                    if (number < 0 || number > 255)
                    {
                        return false;
                    }
                }
                int prefix = int.Parse(match.Groups[2].Value);
                if (prefix < 0 || prefix > 32)
                {
                    return false;
                }

                return true;
            }

            public static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Enter a number corresponding to the command that you would like to run:\n '1' - Find Network Address\n '2' - Find Subnet Mask\n '3' - Find Network ID\n '4' - Find Broadcast\n '5' - Find Range\n '6' - Display All\n '7' - Determine if IPs are in the same network\n '8' - Get My Local IPV4 Address\n '0' - EXIT\n");
                    string userCommand = Console.ReadLine();
                    switch (userCommand)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Please enter the IP address and prefix. i.e. '123.123.123.123/24'");
                            string findAddressInput = Console.ReadLine();
                            if (!IsValidInput(findAddressInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress findAddressIP = new CustomIPAddress(findAddressInput);
                            Console.WriteLine($"\nAddress: {findAddressIP.Address}\n");
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Please enter the IP address and prefix. i.e. '123.123.123.123/24'");
                            string findSubnetMaskInput = Console.ReadLine();
                            if (!IsValidInput(findSubnetMaskInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress findSubnetMaskIP = new CustomIPAddress(findSubnetMaskInput);
                            Console.WriteLine($"Subnet Mask: {findSubnetMaskIP.SubnetMask}\n");
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("Please enter the IP address and prefix. i.e. '123.123.123.123/24'");
                            string findNetworkIDInput = Console.ReadLine();
                            if (!IsValidInput(findNetworkIDInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress findNetworkIDIP = new CustomIPAddress(findNetworkIDInput);
                            Console.WriteLine($"Network ID: {findNetworkIDIP.NetworkID}\n");
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Please enter the IP address and prefix. i.e. '123.123.123.123/24'");
                            string findBroadcastInput = Console.ReadLine();
                            if (!IsValidInput(findBroadcastInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress findBroadcastIP = new CustomIPAddress(findBroadcastInput);
                            Console.WriteLine($"Broadcast: {findBroadcastIP.Broadcast}\n");
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Please enter the IP address and prefix. i.e. '123.123.123.123/24'");
                            string findRangeInput = Console.ReadLine();
                            if (!IsValidInput(findRangeInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress findRangeIP = new CustomIPAddress(findRangeInput);
                            Console.WriteLine($"Network Range: {findRangeIP.NetworkID} - {findRangeIP.Broadcast}\n");
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine("\n\nPlease enter the next IP address and prefix. i.e. '123.123.123.123/24'");
                            string findAllInput = Console.ReadLine();
                            if (!IsValidInput(findAllInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress findAllIP = new CustomIPAddress(findAllInput);
                            Console.WriteLine($"\nAddress: {findAllIP.Address}");
                            Console.WriteLine($"Subnet Mask: {findAllIP.SubnetMask}");
                            Console.WriteLine($"Network ID: {findAllIP.NetworkID}");
                            Console.WriteLine($"Broadcast: {findAllIP.Broadcast}");
                            Console.WriteLine($"Network Range: {findAllIP.NetworkID} - {findAllIP.Broadcast}\n");
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine("\n\nPlease enter the first IP address and prefix. i.e. '123.123.123.123/24'");
                            string firstInput = Console.ReadLine();
                            if (!IsValidInput(firstInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress firstIP = new CustomIPAddress(firstInput);

                            Console.WriteLine("\n\nPlease enter the second IP address and prefix. i.e. '123.123.123.123/24'");
                            string secondInput = Console.ReadLine();
                            if (!IsValidInput(secondInput))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a valid IP address and prefix.\n");
                                break;
                            }
                            CustomIPAddress secondIP = new CustomIPAddress(secondInput);

                            bool areInSameNetwork = firstIP.IsSameNetwork(secondIP);
                            break;
                        case "8":
                            Console.Clear();
                            string myIP = GetLocalIPAddress();
                            Console.WriteLine($"Local IP: {myIP}\n\n");
                            break;
                        case "0":
                            Console.Clear();
                            ExitAnimation();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a recognized command:");
                            break;
                    }
                }
            }
        }
    }
}
