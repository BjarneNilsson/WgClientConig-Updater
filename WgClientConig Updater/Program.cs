using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using CommandLine;

namespace WgClientConig_Updater
{
    internal class Program
    {
        public class Options
        {
            [Option('i', "interface", Required = true)]
            public string I { get; set; }
        }
        static void Main(string[] args)
        {

            string Face = "";
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {

                      Face = o.I;
                   });
            
            string IPp = GetIP(Face);
            IPNetwork ip = IPNetwork.Parse(IPp + "/56");
            String Pr = ip.Network.ToString();
            if (Pr.Length >= 5) Pr = Pr.Remove(Pr.Length - 4, 4) + "80";
            Console.WriteLine(Pr);
        }
        private static string GetIP(String I)
        {

            NetworkInterface[] intf = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface device in intf)
            {
                if (device.Name.ToString() == I)
                {
                    
                    //return device.GetIPProperties().UnicastAddresses[P].Address.ToString();
                    UnicastIPAddressInformationCollection ip = device.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation addr in ip)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            return addr.Address.ToString();
                        }
                       
                    }
                    
                }
                
            }
            return "::1";
        }
    }
}
