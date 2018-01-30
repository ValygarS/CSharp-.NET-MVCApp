using Microsoft.VisualStudio.TestTools.UnitTesting;
using CA1_MVCApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CA1_MVCApp.Models;

namespace CA1_MVCApp.Controllers.Tests
{
    [TestClass()]
    public class PersonControllerTests
    {
        [TestMethod()]
        public void ContactsTest()
        {
            var controller = new PersonController();
            var result = controller.Contacts() as ViewResult;
            var data = result.ViewData.Model;
            Assert.AreEqual(MockDB.getContacts(), data);
        }
    }
}