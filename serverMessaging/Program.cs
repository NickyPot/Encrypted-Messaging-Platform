using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Threading;

namespace serverMessaging
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
            string chatId;
            ASCIIEncoding encoded = new ASCIIEncoding();

            /* This section will take in the employe number that the client application sends 
            * and create an entry in the user dictionairy that is used to map all the connected clients
           */

            byte[] enoByte = new byte[1024];//byte where the eno of the user using the client,  will be stored. (in byte form)
            ns.Read(enoByte, 0, enoByte.Length);//store the eno
            
            eno = Int32.Parse(Encoding.Default.GetString(enoByte).Trim());//put the employee number in the temp val
            userDictionary.Add(eno, ns);// add the client details (eno and netstream) to the dictionairy


            //this will be executed as long as the client is connected
            while (client.Connected)
            {
                try
                {
                    byte[] enoToConnectByte = new byte[1024];//the byte that contains the eno number the user wants to talk to, is stored here
                    ns.Read(enoToConnectByte, 0, enoToConnectByte.Length);//read the netstream for the eno
                    int enoToConnect = Int32.Parse(Encoding.Default.GetString(enoToConnectByte).Trim());//convert the byte to int to be used in the dictionairy
                    byte[] disconnectTest = new byte[1024];//this byte is used to check if the connection is still live 




                    if (userDictionary.ContainsKey(enoToConnect))
                    {

                        //get the chat ID and send it to both clients
                        chatId = connection.getChatId(eno, enoToConnect) + "Lfb1ORIdltExQTB6";
                        byte[] chatIdbyte = encoded.GetBytes(chatId);
                        
                       // ns.Write(chatIdbyte, 0, chatIdbyte.Length);
                        userDictionary[enoToConnect].Write(chatIdbyte, 0, chatIdbyte.Length);
                       





                        //here the server will try to get the message from the client and write it into the netstream of the client the user wants to talk to
                        while (true)
                        {

                            try
                            {
                                
                                byte[] msg = new byte[1024];//this byte will take the message that the client wants to exchange
                                ns.Read(msg, 0, msg.Length);//read the byte
                                
                                string serverLog = Encoding.Default.GetString(msg).Trim();//convert to string (for debugging purposes)
                                Console.WriteLine(serverLog + " from client with eno " + eno);//write the message to the server console
                                
                                string stringMsg = serverLog.Insert(0, "from client with eno " + eno);//this includes who sent the message
                               // msg = encoded.GetBytes(stringMsg);
                                userDictionary[enoToConnect].Write(msg, 0, msg.Length);//write the messsage to the desired client stream

                                ns.Write(disconnectTest, 0, disconnectTest.Length);//check if the connection is still alive
                            }
                            catch
                            {
                                Console.WriteLine("user is no longer online");
                                break;


                            }


                        }



                    }

                    else
                    {
                        
                        byte[] userNot = encoded.GetBytes("User is not connected");

                        ns.Write(userNot, 0, userNot.Length);

                    }

                    
                    
                    ns.Write(disconnectTest, 0, disconnectTest.Length);//check if the connection is still alive

                }
                catch
                {

                    Console.WriteLine("client with eno " + eno +" disconnected");
                    userDictionary.Remove(eno);
                    break;
                
                }
            }

        }

    }
}