using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DisplayBootstrapPage1.Models
{
    public class Review
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A username is required.")]
        //[StringLength(160)]
        [DisplayName("Username")]
        public string UserName { get; set; }
        //[DisplayName("Text")]
        public string Text { get; set; }

        ////[DisplayName("Stars 1 .. 5")]
        //[Range(1, 5, ErrorMessage = "Can only be between 1 .. 5")]
        //public int GradeInt { get; set; }

        [Required(ErrorMessage = "A rating between 1 and 5 is required.")]
        [DisplayName("Rating 1 .. 5")]
        public string Grade { get; set; }

        public DateTime PublishDate { get; set; }
    }
}