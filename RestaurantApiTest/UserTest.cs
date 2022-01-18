using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApi.Business;
using RestaurantApi.Model;
using System;


namespace RestaurantApiTest
{
    [TestClass]
    public class UserTest
    {

        [TestMethod]
        [DataRow("correo@correo.com", "Password1@", "Luis Mendoza", "cl 12 12 12")]
        public void TestCreateUser(string email, string password, string name, string address)
        {
            var res = UserBusiness.Create(new UserModel()
            {
                Address = address,
                Email = email,
                Name = name,
                Password = password
            });
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsTrue(res.Success, "User created");
            Assert.IsNull(res.Message);
        }

        [TestMethod]
        [DataRow("correo@correo", "Password1@", "Luis Mendoza", "cl 12 12 12")]
        public void TestCreateUserCorreoIncorrecto(string email, string password, string name, string address)
        {
            var res = UserBusiness.Create(new UserModel()
            {
                Address = address,
                Email = email,
                Name = name,
                Password = password
            });
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsFalse(res.Success, "User Not created");
            Assert.IsNotNull(res.Message, "Exists response message: " + res.Message);
        }

        [TestMethod]
        [DataRow("correo@correo.com", "password", "Luis Mendoza", "cl 12 12 12")]
        public void TestCreateUserPasswordIncorrecto(string email, string password, string name, string address)
        {
            var res = UserBusiness.Create(new UserModel()
            {
                Address = address,
                Email = email,
                Name = name,
                Password = password
            });
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsFalse(res.Success, "User not created");
            Assert.IsNotNull(res.Message, "Exists response message: " + res.Message);
        }

        [TestMethod]
        [DataRow("raulforero@hotmail.com", "Password1@", "Luis Mendoza", "cl 12 12 12")]
        public void TestCreateUserExistingEmail(string email, string password, string name, string address)
        {
            var res = UserBusiness.Create(new UserModel()
            {
                Address = address,
                Email = email,
                Name = name,
                Password = password
            });
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsFalse(res.Success, "User not created");
            Assert.AreEqual("The email address is already registered", res.Message, "User email already exists");
        }

        [TestMethod]
        [DataRow("raulforero@hotmail.com", "Taminango1@")]
        public void TestLogin(string email, string password)
        {
            var res = UserBusiness.Login(email, password);
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsTrue(res.Success, "User not created");
        }

        [TestMethod]
        [DataRow("correo@correo1.com", "Password1@")]
        public void TestLoginEmailIncorrecto(string email, string password)
        {
            var res = UserBusiness.Login(email, password);
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsFalse(res.Success, "User not logged");
        }

        [TestMethod]
        [DataRow("raulforero@hotmail.com", "Password1@s")]
        public void TestLoginPasswordIncorrecto(string email, string password)
        {
            var res = UserBusiness.Login(email, password);
            Assert.IsNotNull(res, "Method executed correctly");
            Assert.IsFalse(res.Success, "User not logged");
        }
    }
}
