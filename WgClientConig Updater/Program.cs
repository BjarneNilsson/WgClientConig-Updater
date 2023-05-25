


using System.Net;

namespace WgClientConig_Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPNetwork ip = IPNetwork.Parse("2a01:799:ea9:4e01:4ecc:6aff:feb8:9270/56");
            String Pr = ip.Network.ToString();
            Pr = Pr.Remove(Pr.Length -4, 4)+"80";
            Console.WriteLine(Pr);
        }
    }
}