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



        //Show product details
        public ActionResult Detail(int ID = 0)
        {
            Product pr = db.Product.Find(ID);
            return View(pr);
        }


        //Adding product
        public ActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase image)
        {
            String photoName = "";
            photoName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image.FileName);
            string photoPath = Server.MapPath("~/Content/Images/" + photoName);
            image.SaveAs(photoPath);
            product.Image = photoName;


            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Removing Product
        public ActionResult DeleteProduct(int id)
        {
            var product = db.Product.FirstOrDefault(p => p.Id == id);
            db.Product.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        //Updating Product
        public ActionResult UpdateProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return new HttpNotFoundResult();

            }

            return View(product);
        }


        [HttpPost]
        public ActionResult UpdateProduct(Product product, HttpPostedFileBase image)
        {
            Product updatedProduct = db.Product.FirstOrDefault(p=> p.Id == product.Id);
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            updatedProduct.Description = product.Description;
            updatedProduct.CategoryId = product.CategoryId;
            String photoName = "";
            if (image != null)
            {
                photoName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image.FileName);
                string photoPath = Server.MapPath("~/Content/Images/" + photoName);
                image.SaveAs(photoPath);
                updatedProduct.Image = photoName;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }




        //Cart Functions
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