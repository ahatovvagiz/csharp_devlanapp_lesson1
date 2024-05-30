using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345); Console.WriteLine("Connecting...");


                try
                {
                    client.Connect(remoteEndPoint);
                }
                catch
                {
                    Console.WriteLine("Connection problem!");
                    return;
                }

                if (client.Connected)
                {
                    Console.WriteLine($"RemoteEndPoint = {client.RemoteEndPoint}");
                    Console.WriteLine($"LocalEndPoint = {client.LocalEndPoint}");
                    Console.WriteLine("Connected!");
                }

                while (true)
                {
                    Console.Write("Enter a message to send: ");
                    string message = Console.ReadLine();
                    byte[] bytes = Encoding.UTF8.GetBytes(message);

                    try
                    {
                        int count = client.Send(bytes);

                        if (count == bytes.Length)
                        {
                            Console.WriteLine("Message Sent!");

                            // Receive acknowledgment from server
                            byte[] buffer = new byte[1024];
                            int received = client.Receive(buffer);
                            string response = Encoding.UTF8.GetString(buffer, 0, received);
                            Console.WriteLine("Server acknowledgment: " + response);
                        }
                        else
                        {
                            Console.WriteLine("Message not fully sent!");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error sending message!");
                        break;
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}