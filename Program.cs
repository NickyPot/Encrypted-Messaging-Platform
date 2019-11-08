using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Threading;

namespace ServerTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Program main = new Program();
            main.server_start();
            Console.ReadLine();

            
        }

        TcpListener server = new TcpListener(IPAddress.Any, 9999);

        private void server_start()
        {
            server.Start();//starts the server
            accept_connection();  
        }

        private void accept_connection()
        {
            server.BeginAcceptTcpClient(handle_connection, server);  //starts listening for an incoming connection
        }

        private void handle_connection(IAsyncResult result) 
        {
            accept_connection();  //continues listening for a connection after the client has connected
            TcpClient client = server.EndAcceptTcpClient(result); //this accepts the connection

            NetworkStream ns = client.GetStream();//get the netstream from the client

            //this will be executed as long as the client is connected
            while (client.Connected)
            {
                try
                {
                    byte[] msg = new byte[1024];
                    ns.Read(msg, 0, msg.Length);
                    string hello = Encoding.Default.GetString(msg).Trim();
                    Console.WriteLine(hello);
                    byte[] message = new byte[1024];
                    ns.Write(message, 0, message.Length);

                }
                catch
                {

                    Console.WriteLine("disconnected");
                
                }
            }

        }

    }
}