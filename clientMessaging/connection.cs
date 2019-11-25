using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace clientMessaging
{
    class connection
    {

        public static SqlConnection startConn()
        {

            SqlConnection conn;
            string connectionString = "Data Source =tolmount.abertay.ac.uk; Initial Catalog =sql1704807; User ID = sql1704807; Password =HwaXA9jPKd";
            conn = new SqlConnection(connectionString);
            return conn;


        }


        public static string getEncryptionKey(int eno)
        {
            string encryptionKey;//var where the encryption key will be stored

            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "SELECT userKey FROM users WHERE eno = @eno";
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter
           

            enoParam.Value = eno;
           

            preppedCommand.Parameters.Add(enoParam);
           
            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                if (reader.Read())
                {

                    encryptionKey = reader[0].ToString();
                    encryptionKey = encryptionKey.Replace("\r\n", string.Empty);
                    return encryptionKey;

                }
                else
                {

                    return "failed";
                }

                
            }


                
        
        }

        public static int getEnoToTalkTo(int currentEno, int chatId)
        {
            int enoToTalkTo;

            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "SELECT Eno1 FROM Chats WHERE ChatId = @chatId";
            SqlParameter chatIdParam = new SqlParameter("@chatId", SqlDbType.Int);//employee number parameter


            chatIdParam.Value = chatId;


            preppedCommand.Parameters.Add(chatIdParam);

            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                if (reader.Read())
                {

                    enoToTalkTo = Convert.ToInt32(reader[0]);

                    return enoToTalkTo;
                }
                else
                {

                    return 0;
                }


            }



            
        }

        public static void storeMessage(string message, int important, int chatId, int eno)
        {

            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            //insert into the chats table the employee number of the two employees that are trying to talk
            //get the last inserted id (it is given to the two clients in order to archibe their chats)
            preppedCommand.CommandText = "insert into chatline (ChatLine, Important, ChatId, Eno) values (@message, @important, @chatId, @eno); ";
            SqlParameter msgParam = new SqlParameter("@message", SqlDbType.VarChar);//employee number parameter
            SqlParameter importantParam = new SqlParameter("@important", SqlDbType.Bit);//employee number parameter
            SqlParameter chatIdParam = new SqlParameter("@chatId", SqlDbType.Int);//employee number parameter
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter

            msgParam.Value = message;
            msgParam.Size = 400;
            importantParam.Value = important;
            chatIdParam.Value = chatId;
            enoParam.Value = eno;

            preppedCommand.Parameters.Add(msgParam);
            preppedCommand.Parameters.Add(importantParam);
            preppedCommand.Parameters.Add(chatIdParam);
            preppedCommand.Parameters.Add(enoParam);

            preppedCommand.Prepare();



            preppedCommand.ExecuteNonQuery();





        }




    }
}
