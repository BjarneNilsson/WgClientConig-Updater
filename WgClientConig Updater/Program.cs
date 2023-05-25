


using System.Net;
using System.Net.NetworkInformation;

namespace WgClientConig_Updater
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string IPAddr="::1";
            NetworkInterface[] intf = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface device in intf)
            {
                if (device.Name == "comp1")
                {
                    IPAddr =device.GetIPProperties().UnicastAddresses[1].Address.ToString();
                }
            }
            IPNetwork ip = IPNetwork.Parse(IPAddr +"/56");
            String Pr = ip.Network.ToString();
            Pr = Pr.Remove(Pr.Length -4, 4)+"80";
            Console.WriteLine(Pr);
        }   
    }
}