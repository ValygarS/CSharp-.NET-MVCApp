using CA1_MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA1_MVCApp.Controllers
{
    public class PersonController : Controller
    {
        // GET: Display list of contacts
        public ActionResult Contacts()
        {
            var plist = MockDB.getContacts();
            return View(plist);
        }

        // Send SMS from Contacts screen: passing phone number to another action
        [HttpPost]
        public ActionResult SendText(string PhoneNumber)
        {
            return RedirectToAction("Index", "Home", new { number=PhoneNumber });
        }

        
    }
}
