﻿using System;
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
                    conn.Close();
                    return encryptionKey;

                }
                else
                {
                    conn.Close();
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
                    conn.Close();

                    return enoToTalkTo;
                }
                else
                {
                    conn.Close();
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


            conn.Close();


        }

        public static string getEName(int eno)
        {
            string name;

            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "SELECT EName FROM users WHERE eno = @eno";
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter


            enoParam.Value = eno;


            preppedCommand.Parameters.Add(enoParam);

            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                if (reader.Read())
                {

                    name = reader[0].ToString();
                    conn.Close();

                    return name;
                }
                else
                {
                    conn.Close();
                    return "";
                }


            }





            
        
        }

        public static List<int> getAvailableUsers()
        {

            int it = 0;
            List<int> availableUsers = new List<int>();
            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "select eno from users where Online = 1";
            
        
            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    availableUsers.Add(Convert.ToInt32(reader[it])); 
                
                }

                conn.Close();
                return availableUsers;
            }



        }

        public static bool checkUserExists(int eno, string password)
        {

            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);
            preppedCommand.CommandText = "SELECT * FROM users WHERE eno = @eno AND pass = @password";
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter
            SqlParameter passParam = new SqlParameter("@password", SqlDbType.VarChar, 300);//password parameter

            enoParam.Value = eno;
            passParam.Value = password;

            preppedCommand.Parameters.Add(enoParam);
            preppedCommand.Parameters.Add(passParam);

            preppedCommand.Prepare();

            SqlDataReader users = preppedCommand.ExecuteReader();


            if (users.Read())
            {


                return true;

            }

            else
            {
                return false;
            }

        }




    }
}
