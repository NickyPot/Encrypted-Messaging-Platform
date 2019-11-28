using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace clientMessaging
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (enoTextBox.Text != string.Empty && passwordTextBox.Text != string.Empty)
            {

                if (Int32.TryParse(enoTextBox.Text, out int result))
                {
                    string password = passwordTextBox.Text + connection.getEncryptionKey(Convert.ToInt32(enoTextBox.Text));//salt the password with the users encryption key

                    password = encryption.getSha(password);
                    if (connection.checkUserExists(Convert.ToInt32(enoTextBox.Text), password))
                    {
                        chatForm chatForm = new chatForm(enoTextBox.Text);
                        chatForm.Show();
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("We were not able to find a user with those credentials!", "No user Found");

                    }


                }

                else 
                {
                    MessageBox.Show("The employee number field only takes numbers", "Error!");
                    enoTextBox.Text = "For Example: 2";
                
                }

            }


        }

        private void enoTextBox_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void enoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
    }
}
