using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace WebApplication3.Models
{
    public class Recipes
    {

        [Required]
        [Key]
        public string Id { get; set; }
        [Required]

        public string user { get; set; }

        [Required]

        public string Name { get; set; }
        [Required]

        public string types { get; set; }
        [Required]

        public string tempsdepreparation { get; set; }
        [Required]

        public string tempsdecuisson { get; set; }
        [Required]

        public string difficulty { get; set; }
        [Required]

        public string nombrePers { get; set; }
        [Required]

        public string ingredients { get; set; } //List
        [Required]

        public string explication { get; set; } //List


    }
}