using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceDatabase;

namespace TestAuthorization
{
    [TestClass]
    public class UnitTestAuthorization
    {
        [TestMethod]
        public void TestAuthorization1()
        {
            string login = "admin";
            string password = "123";
            int expected = -1;
            int actual = 0;
            using (var db = new ResourceModel()) 
            {
                 actual= db.Authorization(login,password);
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
