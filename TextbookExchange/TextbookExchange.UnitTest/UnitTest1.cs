using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookExchange;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace TextbookExchange.UnitTest
{
    [TestClass]
    public class AccessUserDatabaseTest
    {
        [TestMethod]
        public void InccorectCredentials()
        {
            //Arrange
            User user = new User();
            //Credentails matching ones that are stored on the databse
            user.Email = "axel@couldrey.com";
            user.Password = "letmein";
            LoginPage log = new LoginPage();

            //Act
            bool check = log.AreCredentialsCorrect(user);

            //Assert
            Assert.IsTrue(check);
        }
    }
}
