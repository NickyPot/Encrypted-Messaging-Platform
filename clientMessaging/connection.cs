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

    }
}
