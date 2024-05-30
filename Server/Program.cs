using System.Net;
using System.Net.Sockets;

namespace Server;

class Program
{
    static void Main(string[] args)
    {
        using (Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            //var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            var localEndPoint = new IPEndPoint(IPAddress.Any, 12345);
            listener.Blocking = true;
            listener.Bind(localEndPoint);
            Console.WriteLine("Socket bound " + listener.IsBound);
            listener.Listen(100);
            Console.WriteLine("Waiting for connection...");
            //var socket = listener.Accept();
            
            //listener.Close();
            Socket? socket = null;
            do 
            {
                try
                {
                    socket = listener.Accept();
                    Console.WriteLine("Connected!");
                }
                catch   
                {
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                }
                 
            }
            while (socket != null);
        }
    }

}