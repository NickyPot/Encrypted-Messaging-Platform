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
    public class encryptionTests
    {
        [TestMethod()]
        public void EncryptStringTest()
        {
            //arrange
            string expected = "AGgmltmcfUesIsJeKKY9VA==";
            string message = "hello";
            string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";
            string actual;

            //act
            actual = encryption.EncryptString(encryptionKey, message);

            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]
        public void DecryptStringTest()
        {
            //arrange
            string expected = "hello";
            string message = "AGgmltmcfUesIsJeKKY9VA==";
            string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";
            string actual;

            //act
            actual = encryption.DecryptString(encryptionKey, message);

            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]
        public void getShaTest()
        {
            //arrange
            string password = "hello";
            string expected = "9B71D224BD62F3785D96D46AD3EA3D73319BFBC2890CAADAE2DFF72519673CA72323C3D99BA5C11D7C7ACC6E14B8C5DA0C4663475C2E5C3ADEF46F73BCDEC043";
            string actual;

            //act
            actual = encryption.getSha(password);

            Assert.AreEqual(expected, actual);


        }
    }
}