using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientDetail.Models
{
    public class CustomerInformation
    {
        [Display(Name = "Customer ID")]
        public int CustID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name should be less than 50 charachter")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name should be less than 50 charachter")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Email address should be less than 50 charachter")]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please enter mobile number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please enter 10 digit mobile number")]
        //[Range(0, 10, ErrorMessage = "Please enter 10 digit mobile number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Active/Inactive")]
        public bool Status { get; set; }
    }
}