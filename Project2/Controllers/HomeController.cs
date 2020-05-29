using Project2.Context;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult Index()
        {
            ViewBag.Category = new SelectList(db.Category, "Id", "Name");
            List<Product> ListProducts = db.Product.ToList();

            return View(ListProducts);
        }

        [HttpPost]
        public ActionResult Index(string SearchTerm)
        {
            List<Product> Products;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Products = db.Product.ToList();
            }
            else
            {
                Products = db.Product.Include(c => c.Category).Where(a => a.Category.Name.ToLower().StartsWith(SearchTerm.ToLower())).ToList();
            }

            return View(Products);
        }




        public ActionResult Detail(int ID = 0)
        {
            Product pr = db.Product.Find(ID);
            return View(pr);
        }

        public ActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }



        public ActionResult UpdateProduct(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return new HttpNotFoundResult();

            }

            return View(product);
        }


        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(product);
        }


        public ActionResult AddToCart(Product product)
        {
            var addedProduct = new Cart { ProductId = product.Id, Added_At = DateTime.Now };
            db.Cart.Add(addedProduct);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



        public ActionResult RemoveFromCart(int id)
        {
            var cartItem = db.Cart.Find(id);
            db.Cart.Remove(cartItem);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }

}