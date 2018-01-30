using CA1_MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CA1_MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string number)
        {
            SMS model = new SMS();
            // if number is passed, set it to model fields
            if (number != null)
            {
                model.AreaCode = number.Substring(0, 3);
                model.PhoneNumber = number.Substring(3);
                return View(model);
            }
            // otherwise return empty model
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult SendSMS(SMS sms)
        {
            if (!ModelState.IsValid)
            {
                return View(sms);
            }

             Person model = MockDB.getContacts()
                   .Where(p => p.AreaCode == sms.AreaCode && p.PhoneNumber == sms.PhoneNumber).FirstOrDefault();
            // if person is found in list, load Send message page
            if (model != null)
            {
                ViewBag.Message = sms.TextMessage;
                // writing message log
                Logger.Log(sms.TextMessage);
                return View(model);
            }
            // else: load error page
            else
                
                return RedirectToAction("Error");
        }

        public ActionResult Error()
        {
            return View();
        }

    }

    

}
    
