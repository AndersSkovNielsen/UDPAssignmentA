using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PlainUDPReceiver
{
    internal class UDPReceiver
    {
        private readonly int port;

        List<string> navneListe = new List<string>();

        public UDPReceiver(int PORT)
        {
            port = PORT;
        }

        public void Start()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 11001);

            using (UdpClient receiverSock = new UdpClient(port)) //Lytter på port
            {
                while (true)
                {
                    HandleOneRequest(receiverSock, remoteEP);
                }
            }
        }

        private void HandleOneRequest(UdpClient receiverSock, IPEndPoint remoteEP)
        {
            byte[] data = receiverSock.Receive(ref remoteEP);
            string inStr = Encoding.ASCII.GetString(data);
            
            if (!navneListe.Contains(inStr))
            {
                navneListe.Add(inStr);

                Console.WriteLine("Modtaget: " + inStr);
                Console.WriteLine("Sender ip = " + remoteEP.Address + " port= " + remoteEP.Port);
            }
            
            byte[] outData = Encoding.ASCII.GetBytes(inStr.ToUpper());
            receiverSock.Send(outData, outData.Length, remoteEP);
        }
    }
}