using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CA1_MVCApp.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CA1_MVCApp.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTestPassingStringAreaCode()
        {
            var controller = new HomeController();
            var number = controller.Index("0871527812") as ViewResult;
            SMS sms = (SMS)number.ViewData.Model;
            Assert.AreEqual("087", sms.AreaCode);
        }
        [TestMethod()]
        public void IndexTestPassingStringNumber()
        {
            var controller = new HomeController();
            var number = controller.Index("0871527812") as ViewResult;
            SMS sms = (SMS)number.ViewData.Model;
            Assert.AreEqual("1527812", sms.PhoneNumber);
        }

        [TestMethod()]
        // Testing if valid sms model passed to controller, data will be successfully passed to another View
        public void SendSMSTest()
        {
            var controller = new HomeController();
            SMS sms = new SMS { AreaCode = "085", PhoneNumber = "1315508", TextMessage = "Hello World!" };

            ActionResult result = controller.SendSMS(sms);
            var data = ((ViewResult)result).ViewData["Message"];
            Assert.AreEqual(sms.TextMessage, data);
        }

        [TestMethod()]
        // test if model attributes are valid, validation passes successfully
        public void ValidTest()
        {
            SMS model = new SMS { AreaCode = "085", PhoneNumber = "1315508", TextMessage = "Hello World!" };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod()]
        // Validation fails if AreaCode (or any other field) is missing)
        public void AreaCodeRequired()
        {
            SMS model = new SMS { PhoneNumber = "1315508", TextMessage = "Hello World!" };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            
        }

        [TestMethod()]
        // Validation fails if AreaCode or PhoneNumber doesn't contain digits)
        public void isNumber()
        {
            SMS sms1 = new SMS { AreaCode="abc", PhoneNumber = "1315508", TextMessage = "Hello World!" };
            SMS sms2 = new SMS { AreaCode = "056", PhoneNumber = "abcdgrf", TextMessage = "Hello World!" };
            List<SMS> smsList = new List<SMS>() { sms1, sms2};
            foreach (SMS sms in smsList)
            {
                var model = sms;
                var context = new ValidationContext(model, null, null);
                var result = new List<ValidationResult>();
                var valid = Validator.TryValidateObject(model, context, result, true);

                Assert.IsFalse(valid);
            }
   
        }

        [TestMethod()]
        // Validation fails if message contains more than 140 characters or AreaCode doesn't contain 3 digits
        // or PhoneNumber doesn't contain 7 digits
        public void message_too_long()
        {
            SMS sms1 = new SMS { AreaCode = "123", PhoneNumber = "1315508",
                TextMessage = new string('c',150) };
            SMS sms2 = new SMS { AreaCode = "1234", PhoneNumber = "1315508",
                TextMessage = "Hello World!" };
            SMS sms3 = new SMS { AreaCode = "123", PhoneNumber = "131550800",
                TextMessage = "Hello World!" };
            List<SMS> smsList = new List<SMS>() { sms1, sms2, sms3 };
            foreach (SMS sms in smsList)
            {
                var model = sms;
                var context = new ValidationContext(model, null, null);
                var result = new List<ValidationResult>();
                var valid = Validator.TryValidateObject(model, context, result, true);

                Assert.IsFalse(valid);
            }

            
        }
    }
}