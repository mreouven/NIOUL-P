using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public string id { get; set; }


        [Required]
        public string idReceips { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public DateTime date { get; set; }

    }
}