using System;

namespace PlainUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiver receiver = new UDPReceiver(11001);

            receiver.Start();

            Console.ReadLine();
        }
    }
}
