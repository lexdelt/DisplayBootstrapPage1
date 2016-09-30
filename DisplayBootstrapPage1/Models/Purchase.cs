using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayBootstrapPage1.Models
{
    // Shopping cart item
    public class Purchase
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }

    // Extended shopping cart item for display in the view
    public class PurchaseEx
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Total { get; set; }       // Quantity * Price
        public string Status { get; set; }      // "In Stock", "Out of Stock" etc.
    }

    public class OrderViewModel
    {
        public List<PurchaseEx> PurchaseEx = new List<PurchaseEx>();
        public string Total;
        public string ShippingCost;
        public string GrandTotal;
    }
}