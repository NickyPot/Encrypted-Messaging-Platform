using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;

namespace serverMessaging
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

        public static string getChatId(int eno1, int eno2)
        {
            string chatId;//var where the chat id will be stored

            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            //insert into the chats table the employee number of the two employees that are trying to talk
            //get the last inserted id (it is given to the two clients in order to archibe their chats)
            preppedCommand.CommandText = "INSERT INTO Chats (Eno1, Eno2) VALUES (@eno1, @eno2); SELECT scope_identity(); ";
            SqlParameter eno1Param = new SqlParameter("@eno1", SqlDbType.Int);//employee number parameter
            SqlParameter eno2Param = new SqlParameter("@eno2", SqlDbType.Int);//employee number parameter

            eno1Param.Value = eno1;
            eno2Param.Value = eno2;

            preppedCommand.Parameters.Add(eno1Param);
            preppedCommand.Parameters.Add(eno2Param);

            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                if (reader.Read())
                {

                    chatId = reader[0].ToString();
                    
                    return chatId;

                }
                else
                {

                    return "setting chat Id failed";
                }


            }




        }

        public static void deleteArchive()
        {
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "delete from ChatLine where Important = 0;update ChatLine set ChatID = null where Important = 1; delete from Chats where 1 = 1; ";

            preppedCommand.Prepare();

            preppedCommand.ExecuteNonQuery();
        }


    }
}
