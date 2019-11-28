using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace clientMessaging
{
    public partial class chatForm : Form
    {
        Message incoming = new Message();
        Message outgoing = new Message();
        NetworkStream netstream;
        string serverMessage = "";
        string enoOfClient;
        string importantIsSet;//used when the user wants to send an important message, used string because it is easier to convert to bytes and conevert back
        bool incomingImportant;//used the user has an incoming important message 
        ASCIIEncoding encoded = new ASCIIEncoding();
       
        string enoTotalkToKey = "";//this is where the encryption key, of the client the user is talking to, is stored
        int enoToTalkToId;//this where the id, of the user that the current user wants to talk to, is stored
        string eName;//the name of the person that the current user is talking to (used to display it in the message)
        string currentEnoKey;//the encryption key of the current user. Used to encrypt out going messages
        string decryptedMsg;//this is where the decrypted incoming message is stored
        TcpClient client = new TcpClient();


        public chatForm(string eno)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            enoOfClient = eno;
            currentEnoKey = connection.getEncryptionKey(Convert.ToInt32(enoOfClient));
            
            byte[] byteArray = encoded.GetBytes(enoOfClient);//write to the server what the eno of the user currently using the client is
            netstream = startConn();
            netstream.Write(byteArray, 0, byteArray.Length);
            startBackground();

            sendBtn.Enabled = false;//disabled since the user isnt connected to anyone
            connectToUserBtn.Enabled = false;// disabled before the user picks a user to connect to
            disconnectBtn.Enabled = false;//disabled since the user is not connected to anyone


        }

        private void startBackground()
        {

            if (backgroundWorker1.IsBusy != true)
            {

                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();

            }
           

        }


        private NetworkStream startConn()
        {
            try
            {
                chatList.Items.Add("Connecting to server");
                string ipAddress ="";
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipAddress = ip.ToString();
                    }
                }
                client.Connect(ipAddress, 9999);//connect to server ip
                chatList.Items.Add("Connected and ready to send");
                netstream = client.GetStream();//get server stream

               

            }

            catch
            {
                DialogResult ok = MessageBox.Show("The server is offline! The application will now close", "Error!", MessageBoxButtons.OK);

                if (ok == DialogResult.OK)
                {
                    Application.Exit();

                }
            }


            return netstream;

        }


        private void connectToUserBtn_Click(object sender, EventArgs e)
        {

            enoToTalkToId = Convert.ToInt32(availableUsersBox.SelectedItem.ToString());
            enoTotalkToKey = connection.getEncryptionKey(enoToTalkToId);//get the encryption key of the user the current user is talking to
            eName = connection.getEName(enoToTalkToId);//get name of the user that the current user wants to talk to

            Thread.Sleep(500);
            byte[] enoToTalkTo = encoded.GetBytes(availableUsersBox.SelectedItem.ToString());//get the eno of the user the current user wants to talk to from the drop down menu
            netstream.Write(enoToTalkTo, 0, enoToTalkTo.Length);//send to server


            sendBtn.Enabled = true;//enable since the user is now connected with someone
            connectToUserBtn.Enabled = false;//disable since the user is now connected with someone
            availableUsersBox.Enabled = false;//disable combo box since the user is connected
            disconnectBtn.Enabled = true;//enabled since the user is  connected to someone


        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
       

        private void enoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendBtn_Click(object sender, EventArgs e)
        {

            outgoing.EncryptString(currentEnoKey, chatTextBox.Text);

            ASCIIEncoding encoded = new ASCIIEncoding();
            byte[] byteArray = encoded.GetBytes(outgoing.getEncryptedMessage());
            netstream.Write(byteArray, 0, byteArray.Length);//send the message to the server
            if (importantCheck.Checked)
            {
                importantCheck.Checked = false;
            }

            chatList.Items.Add("You: " + chatTextBox.Text);//add the message to the chatlist


        }

        private void chatList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chatTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {



                byte[] messageByte = new byte[2000];
                netstream.Read(messageByte, 0, 2000);


                serverMessage = Encoding.Default.GetString(messageByte).Trim();
                serverMessage = serverMessage.Replace("\0", string.Empty);

               
               

                worker.ReportProgress(1);
                



            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //this will get the chat id in the beginning of the chat
            if (serverMessage.Contains("Lfb1ORIdltExQTB6"))
            {
                serverMessage = serverMessage.Replace("Lfb1ORIdltExQTB6", string.Empty);
                incoming.setChatId(Convert.ToInt32(serverMessage));
                outgoing.setChatId(Convert.ToInt32(serverMessage));
                MessageBox.Show("Connecting with user", "Connection Request");

                sendBtn.Enabled = true;//enable since the user is now connected with someone
                connectToUserBtn.Enabled = false;//disable since the user is now connected with someone
                availableUsersBox.Enabled = false;
                disconnectBtn.Enabled = true;//enabled since the user is  connected to someone

            }

            //if the client the current user is talking to, has ticked the important checkBox
            else if (serverMessage.Contains("pne8Aj+g`E;fPeKu{nKV&,#ZZ.wm&aczfR#A?-v4=*@V]W@[Xv4`HJ8#r}s^*},"))// used this string to make sure it isnt accidentally included in the message by the user
            {
                incomingImportant = true;

            }


            else if (serverMessage != "" && serverMessage.Contains("pne8Aj+g`E;fPeKu{nKV&,#ZZ.wm&aczfR#A?-v4=*@V]W@[Xv4`HJ8#r}s^*},") == false) 
            {

                //this will only happen when the user currently using the application did not start the chat with the other client
                if (enoTotalkToKey == "")
                {
                    //get the employee number of the user that is trying to talk to the current user
                    enoToTalkToId = connection.getEnoToTalkTo(Convert.ToInt32(enoOfClient), incoming.getChatId());
                    //get the name of the user that is trying to talk to the current user
                    eName = connection.getEName(enoToTalkToId);
                    //get their encryption key
                    enoTotalkToKey = connection.getEncryptionKey(enoToTalkToId);

                    //give the server which employee number the current user is talking to
                    byte[] enoToTalkTo = encoded.GetBytes(enoToTalkToId.ToString());
                    netstream.Write(enoToTalkTo, 0, enoToTalkTo.Length);

                }


                incoming.DecryptString(enoTotalkToKey, serverMessage);//decrypts message using the key of the other user

              
                // add the name of the user to the chatline
                decryptedMsg = eName + ": " + incoming.getDecryptedMessage();

                if (incomingImportant)//if the incoming message is important
                {
                    //add IMPORTANT to string message
                    decryptedMsg = decryptedMsg + " [IMPORTANT]";

                    //play sound
                    System.Media.SystemSounds.Beep.Play();

                    //reset incomingImportant bool
                    incomingImportant = false;

                }


                //this will store the incoming message in db
                chatList.Items.Add(decryptedMsg);

                int important;
                if (decryptedMsg.Contains("[IMPORTANT]"))
                {
                    important = 1;

                }
                else
                {
                    important = 0;
                }
                //MessageBox.Show(chatLine.ToString());

                connection.storeMessage(serverMessage, important, incoming.getChatId(), enoToTalkToId);
                //this is where the storage of the message ends

            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void importantCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (importantCheck.Checked)
            {
                importantIsSet = "pne8Aj+g`E;fPeKu{nKV&,#ZZ.wm&aczfR#A?-v4=*@V]W@[Xv4`HJ8#r}s^*},";
                //send to the other client that an important message is coming
                byte[] important = encoded.GetBytes(importantIsSet);
                netstream.Write(important, 0, important.Length);
            }

            else 
            {
                importantIsSet = "";
            }
        }

        private void chatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            netstream.Close();
            client.Close();
            Application.Exit();
        }

        private void availableUsersBox_DropDown(object sender, EventArgs e)
        {
            availableUsersBox.Items.Clear();
            List<int> availableUsers = connection.getAvailableUsers();
            foreach (int user in availableUsers)
            {
                if (user != Convert.ToInt32(enoOfClient))
                {
                    availableUsersBox.Items.Add(user);

                }
                
            
            }
        }

        private void availableUsersBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            connectToUserBtn.Enabled = true;
           
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            netstream.Close();
            client.Close();
            
            Application.Exit();
        }
    }
}
