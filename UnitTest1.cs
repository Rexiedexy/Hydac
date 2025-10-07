using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hydac;

namespace Hydac.Tests
{
    [TestClass]
    public class AdminTests
    {
        private Admin _admin;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            var logger = new Logger();

            // Act
            _admin = new Admin(logger);
            _admin.AdminInit();

        }

        [TestMethod]
        public void AdminInit_AddAdmins()
        {
            // Arrange
            var userId = "A27";
            var password = "admin123";

            // Act
            var admin = _admin.LogIn(userId, password);

            // Assert
            Assert.IsNotNull(admin);
            Assert.IsTrue(admin.IsLoggedIn);
            Assert.AreEqual("Jacob", admin.Name);
        }

        [TestMethod]
        public void AdminInit_WrongLogin()
        {
            // Arrange
            var userId = "A99";
            var password = "wrongpass";

            // Act
            var result = _admin.LogIn(userId, password);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddGuest_Valid()
        {
            // Arrange
            var guestId = "G1";
            var guestName = "Alice";
            var company = "Hydac";

            // Act
            _admin.AddGuest(guestId, guestName, company);
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                _admin.ShowGuests();
                var output = sw.ToString();

                // Assert
                StringAssert.Contains(output, "Alice");
                StringAssert.Contains(output, "Hydac");
            }
        }

        [TestMethod]
        public void AddGuest_Invalid()
        {
            // Arrange
            var guestId = "G2";
            var guestName = "Alic3"; // invalid name (contains digit)
            var company = "Hydac";

            // Act
            _admin.AddGuest(guestId, guestName, company);
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                _admin.ShowGuests();
                var output = sw.ToString();

                // Assert
                StringAssert.Contains(output, "No Guests members available");
            }
        }

        [TestMethod]
        public void RemoveGuest_Existing()
        {
            // Arrange
            _admin.AddGuest("G3", "Bob", "Hydac");

            // Act
            var removed = _admin.RemoveGuest("G3");

            // Assert
            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void RemoveGuest_NotFound()
        {
            // Arrange
            var guestId = "NOPE";

            // Act
            var removed = _admin.RemoveGuest(guestId);

            // Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void AddStaff_Valid()
        {
            // Arrange
            var staffName = "Staff1";
            var staffId = 101;
            var password = "staffpass";

            // Act
            var result = _admin.AddStaff(staffName, staffId, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveStaff_Valid()
        {
            // Arrange
            _admin.AddStaff("Staff2", 202, "abc123");

            // Act
            var result = _admin.RemoveStaff("Staff2", 202, "abc123");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveStaff_WrongPass()
        {
            // Arrange
            _admin.AddStaff("Staff3", 303, "correct");

            // Act
            var result = _admin.RemoveStaff("Staff3", 303, "wrong");

            // Assert
            Assert.IsNull(result);
        }
    }
}

