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
            using (TcpClient client = new TcpClient())
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 12345);

                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());

                writer.WriteLine("Привет!");
                writer.Flush();

                Console.WriteLine(reader.ReadLine());
                    
            }
        }
    }
}