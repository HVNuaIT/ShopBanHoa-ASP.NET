using BanSach_BCWed.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BanSach_BCWed.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        // GET: Admin/Product
        public ActionResult Index(string tim , string search)
        {
            if (tim == "NameProduct")
                return View(onlineShopEntities.Products.Where(s => s.Name.StartsWith(search)).ToList());
          
            else

            return View(onlineShopEntities.Products.ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View ();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (product.ImageUpload != null)
                {
                    String fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    String extension = Path.GetExtension(product.ImageUpload.FileName);
                    fileName = fileName + extension /*+ "-" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))*/;
                    product.Avartar = fileName;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"),fileName));
                }
                onlineShopEntities.Products.Add(product);
                onlineShopEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception )
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objds = onlineShopEntities.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(objds);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objds = onlineShopEntities.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(objds);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var objds = onlineShopEntities.Products.Where(x => x.Id ==product.Id).FirstOrDefault();
            onlineShopEntities.Products.Remove(objds);
            onlineShopEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objds = onlineShopEntities.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(objds);
        }
        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
           
                if (product.ImageUpload != null)
                {
                    String fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    String extension = Path.GetExtension(product.ImageUpload.FileName);
                    fileName = fileName + extension /*+ "-" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))*/;
                    product.Avartar = fileName;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                }
            onlineShopEntities.Entry(product).State = EntityState.Modified;
                onlineShopEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}