using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement.PERMISSON.Model;
using UserManagement.PERMISSON.Provider;

namespace UserManagement.TEST.PERMISSION
{


    [TestClass]
    public class TestRolePermission
    {
        PRoleProvider _provider; //= new PRoleProvider();
        [TestInitialize]
        public void SetUp()
        {
            _provider = new PRoleProvider();
        }

        [TestMethod]
        public void TcGetListRole()
        {
            Assert.IsNotNull(_provider.getAllRoles());
        }

        [TestMethod]

        public void TcIsCreateRoleIfExist()
        {
            Role newRole = new Role();
            newRole.Name = "TEST";
            newRole.Descriptions = "Test Role Create";
            newRole.Created = DateTime.Now;
            Assert.AreEqual(_provider.createRole(newRole), true);
        }

        [TestMethod]

        public void TcEditRole()
        {
            Role editRole = new Role();
            editRole.Name = "SYSTEMBODYNIGGA";
            editRole.Descriptions = "Test Role EDIT";
            editRole.Modified = DateTime.Now;
            Assert.AreEqual(_provider.editRole(5,editRole),true);
        }

        [TestMethod]
        public void TcDeleteRole()
        {
            Assert.AreEqual(_provider.deleteRole("TEST"), true);
        }

        [TestMethod]
        public void TcGetAllPermissionsOfRoleByID()
        {
            Assert.IsNotNull(_provider.GetAllPermissionsOfRoleByID(1));
            Assert.IsNull(_provider.GetAllPermissionsOfRoleByID(1000));
        }

        [TestMethod]
        public void TcUpdatePRolePermission()
        {
            List<Permission> listPermission = _provider.getAllPermission();
            List<Permission> permission = new List<Permission>();
            permission.Add(listPermission[0]);
            permission.Add(listPermission[1]);
            Assert.AreEqual(_provider.updatePRolePermission(2, permission.ToArray()), true);
            Assert.AreEqual(_provider.updatePRolePermission(1000, permission.ToArray()), false);
        }

    }
}
