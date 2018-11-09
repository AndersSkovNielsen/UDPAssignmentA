using System;

namespace PlainUDPSender
{
    class Program
    {
        private const int port = 11001;
        static void Main(string[] args)
        {
            UDPSender sender = new UDPSender(port);
            sender.Start();

            Console.ReadLine();

        }
    }
}
