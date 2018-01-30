using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA1_MVCApp.Models
{
    public class Person
    {
        [Display (Name ="Forename")]
        public string FirstName { get; set; }

        [Display (Name ="Surname")]
        public string LastName { get; set; }

        public string AreaCode { get; set; }

        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }


    }

    
}