using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement.PERMISSON.Model;
using UserManagement.PERMISSON.Provider;
namespace UserManagement.TEST.PERMISSION
{
    [TestClass]
    public class TestLogin
    {
        UserProvider _provider;

        [TestInitialize]
        public void SetUp()
        {
            _provider = new UserProvider();
        }

        [TestMethod]
        public void TcLogin()
        {
            Assert.IsNotNull(_provider.GetByEmailAndPassword("admin@gmail.com","123"));
        }
    }
}
