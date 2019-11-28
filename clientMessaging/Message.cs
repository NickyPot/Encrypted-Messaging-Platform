using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;


namespace clientMessaging
{
    public class Message
    {
        private string _encryptedMessage;
        private string _decryptedMessage;
        private int _chatId;
        private ASCIIEncoding encoded = new ASCIIEncoding();
        private byte[] _message = new byte[2000];
        private int _important;




        public void EncryptString(string encryptionKey, string message)
        {
            byte[] inVector = new byte[16];
            byte[] array;

            using (Aes encrypt = Aes.Create())
            {
                encrypt.Key = Encoding.Default.GetBytes(encryptionKey);//gets the key for encryption
                encrypt.IV = inVector;
                ICryptoTransform encryptDevice = encrypt.CreateEncryptor(encrypt.Key, encrypt.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptDevice, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(message);
                        }

                        array = memoryStream.ToArray();
                    }
                }

            }


            _encryptedMessage = Convert.ToBase64String(array);

        }

        public string getEncryptedMessage()
        {
            return _encryptedMessage;
        
        }


        public void DecryptString(string encryptionKey, string encryptedString)
        {
            byte[] inVector = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedString);

            using (Aes encrypt = Aes.Create())
            {
                encrypt.Key = Encoding.UTF8.GetBytes(encryptionKey);
                encrypt.IV = inVector;
                ICryptoTransform decryptDevice = encrypt.CreateDecryptor(encrypt.Key, encrypt.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptDevice, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            _decryptedMessage = streamReader.ReadToEnd();
                        }
                    }
                }
            }


        }


        public string getDecryptedMessage()
        {
            return _decryptedMessage;

        }

        public void setChatId(int chatId)
        {
            _chatId = chatId;
            
        }

        public int getChatId()
        {
            return _chatId;
        
        }

        public void setImportant(int set)
        {
            _important = set;
        
        }

        public int getImportant()
        {
            return _important;
        
        }

        public void storeMessage(string message, int eno)
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
            importantParam.Value = _important;
            chatIdParam.Value = _chatId;
            enoParam.Value = eno;

            preppedCommand.Parameters.Add(msgParam);
            preppedCommand.Parameters.Add(importantParam);
            preppedCommand.Parameters.Add(chatIdParam);
            preppedCommand.Parameters.Add(enoParam);

            preppedCommand.Prepare();



            preppedCommand.ExecuteNonQuery();


            conn.Close();

        }



    }
}
