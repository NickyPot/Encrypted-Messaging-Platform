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
    public class UserTests
    {
      

        [TestMethod()]
        public void setEnoSqlTest()
        {
            //arrange
            Message msg = new Message();
            msg.setChatId(90);
            User test = new User();
            int expected = 1;

            //act
            test.setEnoSql(msg.getChatId());
            //act and assert
            Assert.AreEqual(expected, test.getEno());
        }

     

        [TestMethod()]
        public void getNameTest()
        {
            //arrange
            User test = new User();
            test.setEno(1);
            string expected = "Nick Potiriadis";
            //act
            test.setName();
            //assert
            Assert.AreEqual(expected, test.getName());
        }



        [TestMethod()]
        public void getEncryptionKeyTest()
        {
            //arrange
            User test = new User();
            test.setEno(1);
            string expected = "b14ca5898a4e4133bbce2ea2315a1916";
            
            //act
            test.setEncryptionKey();

            //assert
            Assert.AreEqual(expected, test.getEncryptionKey());
        }

        [TestMethod()]
        public void checkUserExistsTest()
        {
            //arrange
            User test = new User();
            test.setEno(1);
            test.setEncryptionKey();
            test.setPassword("hello");

            
            // act and assert 
            Assert.IsTrue(test.checkUserExists());
        }


  

        [TestMethod()]
        public void getAvailableUsersTest()
        {
            //arrange
            List<int> users;

            //act
            users = User.getAvailableUsers();
            //assert
            Assert.IsTrue(!users.Any());
        }
    }
}