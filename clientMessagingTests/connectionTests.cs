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
    public class connectionTests
    {
        [TestMethod()]
        public void getEncryptionKeyTest()
        {
            //arrange
            string expected = "b14ca5898a4e4133bbce2ea2315a1916";
            int eno = 1;
            string actual;

            //act
            actual = connection.getEncryptionKey(eno);
            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void storeMessageTest()
        {
            //arrange
            string message = "asdf";
            int important = 1;
            int chatId = 90;
            int eno = 1;

            //act and assert
            connection.storeMessage(message, important, chatId, eno);
            
            

        }

        [TestMethod()]
        public void getENameTest()
        {
            //arrange
            string expected = "Nick Potiriadis";
            int eno = 1;
            string actual;

            //act
            actual = connection.getEName(eno);

            //assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]
        public void getAvailableUsersTest()
        {
            //arrange
            List<int> users;

            //act
            users = connection.getAvailableUsers();
            //assert
            Assert.IsTrue(!users.Any());


        }

        [TestMethod()]
        public void checkUserExistsTest()
        {
            //arrange
            int eno = 1;
            string password = "5105CD0CDCDB1626FCC6DA988B0D14226077E82B106F6E20430ECC5C074BAE3E734D86E0B4493EE2773358ECD6AC3058FC50D99F800C5123C885C23A3258B3C0";

            //act and assert
            Assert.IsTrue(connection.checkUserExists(eno, password));


        }
    }
}