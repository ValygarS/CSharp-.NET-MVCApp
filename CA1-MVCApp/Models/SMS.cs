using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA1_MVCApp.Models
{
    public class SMS
    {

        [Required]
        [Display(Name ="Area Code")]
        [StringLength(3, MinimumLength = 3, ErrorMessage ="Area Code should have 3 digits.")]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage ="Only digits 0-9 allowed")]
        public string AreaCode { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Phone number should have 7 digits.")]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Only digits 0-9 allowed")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name ="Enter your message:")]
        [StringLength(140, ErrorMessage ="Message can contain up to 140 characters.")]
        public string TextMessage { get; set; }


    }
}