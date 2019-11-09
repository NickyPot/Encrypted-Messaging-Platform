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


        IDictionary<int, NetworkStream> userDictionary = new Dictionary<int, NetworkStream>();//this will store the netstream of the employee that is connected and the key-value will be his/ her employee number
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
            int eno;//this will be used to temp store the employee number of the user that has connected to the server 

            /* This section will take in the employe number that the client application sends 
            * and create an entry in the user dictionairy that is used to map all the connected clients
           */

            byte[] enoByte = new byte[1024];//byte where the eno in byte form will be stored
            ns.Read(enoByte, 0, enoByte.Length);//store the eno
            eno = Int32.Parse(Encoding.Default.GetString(enoByte).Trim());//put the employee number in the temp val
            userDictionary.Add(eno, ns);// add the client details (eno and netstream) to the dictionairy


            //this will be executed as long as the client is connected
            while (client.Connected)
            {
                try
                {
                    byte[] msg = new byte[1024];
                    ns.Read(msg, 0, msg.Length);
                    string hello = Encoding.Default.GetString(msg).Trim();
                    Console.WriteLine(hello + " from client with eno " + eno);
                    byte[] message = new byte[1024];
                    ns.Write(message, 0, message.Length);

                }
                catch
                {

                    Console.WriteLine("client with eno " + eno +" disconnected");
                
                }
            }

        }

    }
}