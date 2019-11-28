using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Security.Cryptography;

namespace clientMessaging
{
    public class User
    {
        private int _eno;
        private string _name;
        private string _encryptionKey;
        private string _password;


        public void setEno(int eno)
        {
            _eno = eno;
        
        }

        public void setEnoSql(int chatId)
        {
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

                    _eno = Convert.ToInt32(reader[0]);
                    conn.Close();

                    
                }
               

            }



        }

        public int getEno()
        {
            return _eno;
                
        }


        public void setName()
        {

            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "SELECT EName FROM users WHERE eno = @eno";
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter


            enoParam.Value = _eno;


            preppedCommand.Parameters.Add(enoParam);

            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                if (reader.Read())
                {

                    _name = reader[0].ToString();
                    conn.Close();

                    
                }
               

            }




        }

        public string getName()
        {
            return _name;
        }


        public void setEncryptionKey()
        {
            //open sql connection
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);

            preppedCommand.CommandText = "SELECT userKey FROM users WHERE eno = @eno";
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter


            enoParam.Value = _eno;


            preppedCommand.Parameters.Add(enoParam);

            preppedCommand.Prepare();



            using (var reader = preppedCommand.ExecuteReader())
            {
                if (reader.Read())
                {

                    _encryptionKey = reader[0].ToString();
                    _encryptionKey = _encryptionKey.Replace("\r\n", string.Empty);
                    conn.Close();
                   

                }
               

            }



        }

        public string getEncryptionKey()
        {
            return _encryptionKey;
        
        
        }

        public bool checkUserExists()
        {
            
            SqlConnection conn = connection.startConn();
            conn.Open();

            SqlCommand preppedCommand = new SqlCommand(null, conn);
            preppedCommand.CommandText = "SELECT * FROM users WHERE eno = @eno AND pass = @password";
            SqlParameter enoParam = new SqlParameter("@eno", SqlDbType.Int);//employee number parameter
            SqlParameter passParam = new SqlParameter("@password", SqlDbType.VarChar, 300);//password parameter

            enoParam.Value = _eno;
            passParam.Value = _password;

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
        public static string getSha(string password)
        {


            SHA512 sha = new SHA512Managed();
            byte[] bytes = Encoding.Default.GetBytes(password);
            byte[] hash = sha.ComputeHash(bytes);


            return hashToString(hash);
        }

        private static string hashToString(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }


        public void setPassword(string originalPass)
        {
            originalPass = originalPass + getEncryptionKey();

            _password = getSha(originalPass);
        
        }

        public string getPassword()
        {
            return _password;
        
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


    }
}
