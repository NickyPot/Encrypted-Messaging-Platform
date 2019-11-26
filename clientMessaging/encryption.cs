using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace clientMessaging
{
    public static class encryption
    {

        public static string EncryptString(string encryptionKey, string message)
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


            return Convert.ToBase64String(array);

        }


        public static string DecryptString(string encryptionKey, string encryptedString)
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
                            return streamReader.ReadToEnd();
                        }
                    }
                }
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


    }
     

    
}
