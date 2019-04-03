using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Users
    {
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }

        [Key]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Phone_Number { get; set; }


        [RegularExpression("^[0-3]{1}$")]
        public string type { get; set; }



        
    }
}