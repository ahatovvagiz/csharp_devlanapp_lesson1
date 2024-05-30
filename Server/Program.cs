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

            var listener = new TcpListener(IPAddress.Any, 12345);

            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {
                Console.WriteLine("Connected");

                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());

                var message = reader.ReadLine();

                Console.WriteLine(message);

                writer.WriteLine("Получено сообщение: "+ message);

                writer.Flush();

            }
        }
    }
}