using Project2.Context;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
    }
}