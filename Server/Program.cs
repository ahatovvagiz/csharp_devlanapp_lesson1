using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var localEndPoint = new IPEndPoint(IPAddress.Any, 12345); 
                
                listener.Blocking = true; 
                listener.Bind(localEndPoint); 
                Console.WriteLine("Socket bound " + listener.IsBound); 
                listener.Listen(100); 
                Console.WriteLine("Waiting for connection...");


                Socket clientSocket = listener.Accept();
                Console.WriteLine("Connected to client!");

                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesReceived = clientSocket.Receive(buffer);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                    Console.WriteLine("Client: " + message);

                    Console.Write("Enter message to send to client: ");
                    string replyMessage = Console.ReadLine();
                    byte[] replyBuffer = Encoding.ASCII.GetBytes(replyMessage);
                    clientSocket.Send(replyBuffer);

                    Console.WriteLine("Message sent to client");
                }
            }
        }
    }
}