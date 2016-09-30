using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayBootstrapPage1.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public DateTime PublishDate { get; set; }
        public string PictureLinkLarge { get; set; }
        public string PictureLinkSmall { get; set; }
        public string InStock { get; set; }

        public string AverageReview { get; set; }
        public int NumberReviews { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public Product()
        {
            this.Reviews = new List<Review>();
        }
    }
}