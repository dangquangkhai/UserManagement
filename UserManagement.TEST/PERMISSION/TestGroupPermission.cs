using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement.PERMISSON.Model;
using UserManagement.PERMISSON.Provider;

namespace UserManagement.TEST.PERMISSION
{
    [TestClass]
    public class TestGroupPermission
    {
        PGroupProvider _provider;

        [TestInitialize]
        public void SetUp()
        {
            _provider = new PGroupProvider();
        }

        [TestMethod]
        public void TcGetAllGroup()
        {
            Assert.IsNotNull(_provider.getAllGroup());
        }

        [TestMethod]
        public void TcCreateGroup()
        {
            Group newGroup = new Group();
            newGroup.Name = "TEST";
            newGroup.Descriptions = "Group Test for Test Case";
            newGroup.Created = DateTime.Now;
            Assert.AreEqual(_provider.createGroup(newGroup), true);
        }

        [TestMethod]
        public void TcEditGroup()
        {
            Group editGroup = new Group();
            editGroup.Name = "BODYGUARD";
            editGroup.Descriptions = "Group bảo vệ chỉnh sửa";
            editGroup.Modified = DateTime.Now;
            Assert.AreEqual(_provider.editGroup(6, editGroup), true);
        }

        [TestMethod]
        public void TcDeleteGroup()
        {
            Assert.AreEqual(_provider.deleteGroup("TEST"), true);
        }

        [TestMethod]
        public void TcGetAllRoleOfGroupByID()
        {
            Assert.IsNotNull(_provider.GetAllRoleOfGroupByID(1));
            Assert.IsNull(_provider.GetAllRoleOfGroupByID(1000));
        }

        [TestMethod]
        public void TcGetAllUserOfGroupByID()
        {
            Assert.IsNotNull(_provider.GetAllUserOfGroupByID(1));
            Assert.IsNull(_provider.GetAllUserOfGroupByID(1000));
        }

        [TestMethod]
        public void TcUpdatePGroupRole()
        {
            List<Role> listRole = _provider.getAllRole();
            List<Role> role = new List<Role>();
            listRole[0].Checked = true;
            listRole[1].Checked = true;
            role.Add(listRole[0]);
            role.Add(listRole[1]);
            Assert.AreEqual(_provider.updatePGroupRole(4, role.ToArray()), true);
            Assert.AreEqual(_provider.updatePGroupRole(1000, role.ToArray()), false);
        }

        [TestMethod]
        public void TcUpdatePGroupUser()
        {
            List<User> listUser = _provider.getAllUser();
            List<User> user = new List<User>();
            listUser[0].Checked = true;
            listUser[1].Checked = true;
            user.Add(listUser[0]);
            user.Add(listUser[1]);
            Assert.AreEqual(_provider.updatePGroupUser(4, user.ToArray()), true);
            Assert.AreEqual(_provider.updatePGroupUser(1000, user.ToArray()), false);
        }

    }
}
