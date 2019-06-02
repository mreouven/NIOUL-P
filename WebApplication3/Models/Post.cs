using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Post
    {
        [Key]
        [Required]
        public string name { get; set; }


        [Required]
        public string post { get; set; }
    

    }
}