using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ModelLib;

namespace PlainUDPSender
{
    internal class UDPSender
    {
        private readonly int port;

        public UDPSender(int PORT)
        {
            port = PORT;
        }

        public void Start()
        {
            Car c1 = new Car("Tesla", "Red", "EL23400");

            byte[] data = Encoding.ASCII.GetBytes(c1.ToString());
            //IPEndPoint receiverEP = new IPEndPoint(IPAddress.Loopback, port); //Localhost, personlig/privat arbejde
            IPEndPoint receiverEP = new IPEndPoint(IPAddress.Broadcast, port); //Broadcast, forbindelse udtil

            using (UdpClient senderSock = new UdpClient()) //ingen port# = lytter ikke
            {
                senderSock.EnableBroadcast = true;

                senderSock.Send(data, data.Length, receiverEP);

                IPEndPoint FromReceiverEP = new IPEndPoint(IPAddress.Any, 11001);
                byte[] inData = senderSock.Receive(ref FromReceiverEP);

                string inStr = Encoding.ASCII.GetString(inData);

                Console.WriteLine("Modtaget = " + inStr);
            }
        }
    }
}