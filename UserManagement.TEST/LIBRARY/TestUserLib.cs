using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement.LIBRARY.RDBMProviders;
using UserManagement.LIBRARY.RDBMModels;
using System.Linq;

namespace UserManagement.TEST.LIBRARY
{
    [TestClass]
    public class TestUserLib
    {
        private UserProvider _provider = new UserProvider();
        private RDBMDBContext db = new RDBMDBContext();
        [TestInitialize]
        public void SetUp()
        {
            this._provider = new UserProvider();
        }

        [TestMethod]
        public void TestGetAllUserData()
        {
            Assert.IsNotNull(_provider.GetAllListUser());
        }

        [TestMethod]
        public void TcIsCreateIfUserExist()
        {
            User newUser = new User();
            newUser.Email = "dangquangkhai@gmail.com";
            newUser.Password = new SecureCipher().Encrypt("123");
            newUser.Firstname = "Khải";
            newUser.Lastname = "Đặng";
            Assert.AreNotEqual(_provider.createUser(newUser), "true");
        }

        [TestMethod]

        public void TcEditUser()
        {
            User editUser = db.Users.Where(u => u.ID == 4).FirstOrDefault();
            editUser.Lastname = "Duong Vinh";
            Assert.AreEqual(_provider.editUser(4, editUser), true);
            Assert.AreEqual(_provider.editUser(100, editUser), false);

        }

        [TestMethod]
        public void TcUserCounted()
        {
            //Assert.AreEqual(_provider.isCount(1), true);
            Assert.AreEqual(_provider.isCount(1), false);
        }

        [TestMethod]
        public void TcIsMonthlyScheduleSet()
        {
            Assert.AreEqual(_provider.isMonthlyScheduleSet(1), true);
            Assert.AreEqual(_provider.isMonthlyScheduleSet(8), false);
        }

        [TestMethod]
        public void TcSaveMonthlyScheduleSet()
        {
            Assert.AreEqual(_provider.saveMonthlySchedule(2, new DateTime(2018, 11, 1), new DateTime(2018, 11, 30)), true);
            Assert.AreEqual(_provider.saveMonthlySchedule(1000, new DateTime(2018, 11, 1), new DateTime(2018, 11, 30)),false);
        }

        [TestMethod]

        public void TcGetSalaryOfUserByID()
        {
            Assert.IsNotNull(_provider.getSalaryOfUserByID(1));
            Assert.IsNull(_provider.getSalaryOfUserByID(1000));
        }

        [TestMethod]

        public void TcGetPaymentOfUserByID()
        {
            Assert.IsNotNull(_provider.getPaymentOfUserById(1));
            Assert.IsNotNull(_provider.getPaymentOfUserById(1000));
        }


    }
}
