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
                    SqlConnection conn = connection.startConn();


                    //here will be the prepared statement

                    conn.Open();

                    SqlCommand preppedCommand = new SqlCommand(null, conn);
                    preppedCommand.CommandText = "SELECT * FROM users WHERE eno = @eno AND pass = @password";
                    SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter
                    SqlParameter passParam = new SqlParameter("@password", SqlDbType.VarChar, 300);//password parameter

                    enoParam.Value = enoTextBox.Text;
                    passParam.Value = passwordTextBox.Text;

                    preppedCommand.Parameters.Add(enoParam);
                    preppedCommand.Parameters.Add(passParam);

                    preppedCommand.Prepare();

                    SqlDataReader users = preppedCommand.ExecuteReader();


                    if (users.Read())
                    {


                        chatForm chatForm = new chatForm(enoTextBox.Text);
                        chatForm.Show();
                        conn.Close();
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
