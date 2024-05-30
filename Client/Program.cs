using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client;

class Program
{
    static void Main(string[] args)
    {
        using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            //var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            var remoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.114"), 12345); 
            Console.WriteLine("Connecting...");

            try
            {
                client.Connect(remoteEndPoint);
            }
            catch
            {

                
            }
            
            if (client.Connected) 
            {
                Console.WriteLine($"RemoteEndPoint = {client.RemoteEndPoint}");
                Console.WriteLine($"LocalEndPoint = {client.LocalEndPoint}");
                Console.WriteLine("Connected!");
            }
            else 
            {
                Console.WriteLine("Connection problem!");
            }

            byte[] bytes = Encoding.UTF8.GetBytes(Console.ReadLine());

            Console.WriteLine();

            int count = client.Send(bytes);

            if (count == bytes.Length) 
            {
                Console.WriteLine("Message Send!");
            }
            else 
            {
                Console.WriteLine("Потрачено!");
            }
        }
    }

}