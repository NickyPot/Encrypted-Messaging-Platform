using Microsoft.VisualStudio.TestTools.UnitTesting;
using clientMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientMessaging.Tests
{
    [TestClass()]
    public class MessageTests
    {
        [TestMethod()]
        public void EncryptStringTest()
        {
            Message msg = new Message();
            string expected = "AGgmltmcfUesIsJeKKY9VA==";
            string message = "hello";
            string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";
            

            //act
            msg.EncryptString(encryptionKey, message);

            Assert.AreEqual(expected, msg.getEncryptedMessage());

        }


        [TestMethod()]
        public void DecryptStringTest()
        {
            Message msg = new Message();
            string expected = "hello";
            string message = "AGgmltmcfUesIsJeKKY9VA==";
            string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";


            //act
            msg.DecryptString(encryptionKey, message);

            Assert.AreEqual(expected, msg.getDecryptedMessage());
        }

        [TestMethod()]
        public void storeMessageTest()
        {
            //arrange
            string message = "asdf";
            int important = 1;
            int chatId = 90;
            int eno = 1;
            Message msg = new Message();
            msg.setImportant(important);
            msg.setChatId(chatId);
            


            //act and assert
            msg.storeMessage(message, eno);
        }

    }
}