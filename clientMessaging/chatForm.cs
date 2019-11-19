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

namespace clientMessaging
{
    public partial class chatForm : Form
    {

        NetworkStream netstream;
        string serverMessage = "";
        string enoOfClient;

        public chatForm(string eno)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            enoOfClient = eno;


        }

        private void startBackground()
        {
            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync();

        }


        private NetworkStream startConn()
        {

            TcpClient client = new TcpClient();

            chatList.Items.Add("Connecting to server");
            client.Connect("192.168.0.13", 9999);//connect to server ip
            chatList.Items.Insert(0, "Connected and ready to send");
            netstream = client.GetStream();//get server stream

            return netstream;
        }


        private void connectToUserBtn_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoded = new ASCIIEncoding();
            byte[] byteArray = encoded.GetBytes(enoOfClient);
            netstream = startConn();
            netstream.Write(byteArray, 0, byteArray.Length);
            Thread.Sleep(500);
            byte[] enoToTalkTo = encoded.GetBytes(enoTextBox.Text);
            netstream.Write(enoToTalkTo, 0, enoToTalkTo.Length);

            startBackground();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void enoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendBtn_Click(object sender, EventArgs e)
        {

            ASCIIEncoding encoded = new ASCIIEncoding();
            byte[] byteArray = encoded.GetBytes(chatTextBox.Text);
            netstream.Write(byteArray, 0, byteArray.Length);


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

                worker.ReportProgress(1);



            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            chatList.Items.Add(serverMessage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
