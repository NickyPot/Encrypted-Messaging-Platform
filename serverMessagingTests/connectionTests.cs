using Microsoft.VisualStudio.TestTools.UnitTesting;
using serverMessaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace serverMessaging.Tests
{
    [TestClass()]
    public class connectionTests
    {
        [TestMethod()]
        public void getChatIdTest()
        {
            //arrange
            int eno1 = 1;
            int eno2 = 2;


            //act and assert
            connection.getChatId(eno1, eno2);
        }

        [TestMethod()]
        public void deleteArchiveTest()
        {
           
            //act and assert
            connection.deleteArchive();
        }

        [TestMethod()]
        public void setOnlineStatusTest()
        {
            //arrange
            int eno = 1;
            int status = 0;

            //act and assert
            connection.setOnlineStatus(eno, status);
          
        }

    }
}