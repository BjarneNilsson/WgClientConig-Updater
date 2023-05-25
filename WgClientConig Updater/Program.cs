using System.Net;
using System.Net.NetworkInformation;
using CommandLine;

namespace WgClientConig_Updater
{
    internal class Program
    {
        public class Options
        {
            [Option('p', "position", Required = false,Default =0)]
            public int P { get; set; }
            [Option('i', "interface", Required = true)]
            public string I { get; set; }
        }
        static void Main(string[] args)
        {
         int P = 0;
        string I = "";
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       P = o.P;
                       I = o.I;
                   });
            IPNetwork ip = IPNetwork.Parse(GetIP(I,P) + "/56");
            String Pr = ip.Network.ToString();
            if (Pr.Length >=5) Pr = Pr.Remove(Pr.Length - 4, 4) + "80";
            Console.WriteLine(Pr);
        }
        private static string GetIP(String Interface, int P)
        {

            NetworkInterface[] intf = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface device in intf)
            {
                if (device.Name == Interface)
                {
                    return device.GetIPProperties().UnicastAddresses[P].Address.ToString();
                }

            }
            return "::";
        }
    }
}