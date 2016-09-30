using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayBootstrapPage1.DAL;
using DisplayBootstrapPage1.Models;
using System.Diagnostics;


namespace DisplayBootstrapPage1.Controllers
{
    public class ShopController : Controller
    {
        private ShopContext db = new ShopContext();

        // Initialzie an example shopping cart as the program starts
        static List<Purchase> Shoppingcart = new List<Purchase>()
        {
            new Purchase() { ProductID = 1, Quantity = 3 },
            new Purchase() { ProductID = 5, Quantity = 1 },
            new Purchase() { ProductID = 7, Quantity = 2 },
            new Purchase() { ProductID = 15, Quantity = 2 }
        };

        public ActionResult Index(string cat, string brand)
        {
            var lp = new List<Product>();
            if (cat != null)
            {
                if (cat == "all")
                {
                    lp = db.Products.OrderBy(item => item.Category).ThenBy(item => item.Manufacturer).ToList();
                }
                else
                {
                    lp = db.Products.Where(item => (item.Category == cat)).OrderBy(item => item.Manufacturer).ToList();
                }
            }
            else if (brand != null)
            {
                if (brand == "all")
                {
                    lp = db.Products.OrderBy(item => item.Manufacturer).ThenBy(item => item.Category).ToList();
                }
                else
                {
                    lp = db.Products.Where(item => (item.Manufacturer == brand)).OrderBy(item => item.Category).ToList();
                }
            }
            else
            {
                lp = db.Products.OrderBy(item => item.Manufacturer).ThenBy(item => item.Category).ToList();
            }
            return View(lp);
        }

        public ActionResult IndexAjax(string cat, string brand)
        {
            var lp = new List<Product>();
            if (cat != null)
            {
                if (cat == "all")
                {
                    lp = db.Products.OrderBy(item => item.Category).ThenBy(item => item.Manufacturer).ToList();
                }
                else
                {
                    lp = db.Products.Where(item => (item.Category == cat)).OrderBy(item => item.Manufacturer).ToList();
                }
            }
            else // if (brand != null)
            {
                if (brand == "all")
                {
                    lp = db.Products.OrderBy(item => item.Manufacturer).ThenBy(item => item.Category).ToList();
                }
                else
                {
                    lp = db.Products.Where(item => (item.Manufacturer == brand)).OrderBy(item => item.Category).ToList();
                }
            }
            return PartialView(viewName: "_IndexAjax", model: lp);
        }

        // Called from Index View only, always uses Ajax
        public ActionResult IndexFilterPartial()
        {
            ViewData["Categories"] = db.Products.Select(item => item.Category).Distinct().OrderBy(item => item).ToList();
            ViewData["Brands"] = db.Products.Select(item => item.Manufacturer).Distinct().OrderBy(item => item).ToList();
            return PartialView(viewName: "_IndexFilterPartial");
        }

        // Called from Product View only, no use of Ajax
        public ActionResult ProductFilterPartial()
        {
            ViewData["Categories"] = db.Products.Select(item => item.Category).Distinct().OrderBy(item => item).ToList();
            ViewData["Brands"] = db.Products.Select(item => item.Manufacturer).Distinct().OrderBy(item => item).ToList();
            return PartialView(viewName: "_ProductFilterPartial");
        }

        // Shows one product
        // Used by: 
        // 1. pratial view _ProductTile
        // 2. RedirectToAction after review entry using CreateReview/POST
        // 3. partial view _ShoppingCart
        public ActionResult ShowProduct(int? Product_ID)  // Product_ID will never be null
        {
            Product product;

            if (Product_ID != null)
            {
                product = db.Products.Where(item => (item.ID == Product_ID)).First();
            }
            else
            {
                product = db.Products.First();
            }

            // Also pull previously entered number for shopping cart Quantity if any.
            if (Shoppingcart.Any(item => (item.ProductID == Product_ID)))
                ViewBag.Quantity = Shoppingcart.Where(item => (item.ProductID == Product_ID)).First().Quantity;
            else
                ViewBag.Quantity = 0;

            return View(product);
        }

        [HttpGet]   // Called from Product view -- shows the review entry form CreateReview
        public ActionResult CreateReview(int Product_ID)  // Product_ID never null, is an existing and displayed product
        {
            ViewBag.Product_ID = Product_ID;
            return View();
        }

        [HttpPost]   // Call back from the Review form, form posts back to the same url
        public ActionResult CreateReview([Bind(Exclude = "PublishDate")] Review review, int Product_ID)  // Product_ID never null  
        {
            if (ModelState.IsValid)
            {
                // get product reference back, using id
                Product product = db.Products.First(item => (item.ID == Product_ID));
                review.PublishDate = DateTime.Now;                  // user does not enter time
                product.Reviews.Add(review);
                product.NumberReviews = product.Reviews.Count;      // get number of children from db (just added one), store at parent
                double sum = 0;
                foreach (var item in product.Reviews)
                {
                    sum += int.Parse(item.Grade);
                }
                product.AverageReview = Convert.ToInt32(sum / product.NumberReviews).ToString();
                db.SaveChanges();
            }
            return RedirectToAction("ShowProduct", new { Product_ID = Product_ID });
        }

        // Note: actual purchase is not implemented, "InStock" will never be reduced
        // Called from: 
        // 1. ShowProduct View buy entry form button
        // 2. ShoppingCart partial View (red button), using Quantity set to zero
        // Product_ID comes from DB and should always be valid
        // putting letters for Quantity make input for Quantity = null
        public ActionResult ShoppingCart(int? Quantity, int? Product_ID)
        {
            if (Quantity != null && Product_ID != null)
            // if no form entry - don't modify shopping cart list, still show the current cart,
            // should never happen unless manually typing shopping shopping cart url
            {
                if (Quantity < 0)
                    Quantity = 0;       // don't allow negative numbers to be entered

                if (Shoppingcart.Any(item => (item.ProductID == Product_ID)))   // product already in shopping cart
                {
                    var ShoppingCartItem = Shoppingcart.Where(item => (item.ProductID == Product_ID)).First();

                    // update shopping cart with new quantity
                    ShoppingCartItem.Quantity = (int)Quantity;

                    if (ShoppingCartItem.Quantity == 0)
                        Shoppingcart.Remove(ShoppingCartItem);
                }
                else  // a completely new product is added to shopping cart, if Quantity > 0
                {
                    //if (int.Parse(product.InStock) >= 1 && Quantity > 0)                                                              
                    if (Quantity > 0)
                    {
                        // make new shopping cart item
                        Shoppingcart.Add(new Purchase()
                        { ProductID = (int)Product_ID, Quantity = (int)Quantity });
                    }
                }
            }
            return RedirectToAction("Order");
        }


        // Prepares the View Model used to display the shopping cart
        // Complements Shopping cart numbers with product DB data and total amounts to be payed
        // Called only from ActionResult ShoppingCart when pressing buy buttom
        // Shopping cart numbers are adjusted not max current InStock values
        public ActionResult Order()
        {
            OrderViewModel OrderVM = new OrderViewModel();

            string Status;
            int ShippingCost;
            int ToPay = 0;
            int Quantity;

            // Summing amounts to be payed and making a new shopping cart 
            // containing more information for View
            // the purchase for any product will not be larger than what's in stock
            foreach (var Purchase in Shoppingcart)
            {
                var Product = db.Products.Where(item => (item.ID == Purchase.ProductID)).First();

                if (int.Parse(Product.InStock) == 0)
                {
                    Quantity = 0;
                    Status = "Out of Stock";
                }
                else if (int.Parse(Product.InStock) >= Purchase.Quantity)
                {
                    Quantity = Purchase.Quantity;
                    Status = "In Stock";
                }
                else
                {
                    Quantity = int.Parse(Product.InStock);
                    Status = "Order partly filled - out of stock";
                }

                ToPay += int.Parse(Product.Price) * Quantity;

                OrderVM.PurchaseEx.Add(
                    new PurchaseEx()
                    {
                        Product = Product,

                        Quantity = Quantity,
                        Total = (int.Parse(Product.Price) * Quantity).ToString(),
                        Status = Status,
                    });
            }

            if (ToPay > 0)
                ShippingCost = 50;          // hard coded for now
            else
                ShippingCost = 0;           // only disply shipping cost when buying something

            OrderVM.Total = ToPay.ToString();
            OrderVM.GrandTotal = (ToPay + ShippingCost).ToString();
            OrderVM.ShippingCost = ShippingCost.ToString();

            return View(OrderVM);
        }
    }
}




//#####################
//Debug.WriteLine("My debug string here");
//#####################

