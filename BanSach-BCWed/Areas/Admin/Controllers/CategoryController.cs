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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        public ActionResult Index(string tim , string seach)
        {
            if (tim == "Name")
                return View(onlineShopEntities.Categories.Where(s => s.Name.StartsWith(seach)).ToList());

            else

                return View(onlineShopEntities.Categories.ToList());
          
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(Category category)
        {
            try
            {
                onlineShopEntities.Categories.Add(category);
                onlineShopEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objds = onlineShopEntities.Categories.Where(x => x.Id == id).FirstOrDefault();
            return View(objds);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objds = onlineShopEntities.Categories.Where(x => x.Id == id).FirstOrDefault();
            return View(objds);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            var objds = onlineShopEntities.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
            onlineShopEntities.Categories.Remove(objds);
            onlineShopEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objds = onlineShopEntities.Categories.Where(x => x.Id == id).FirstOrDefault();
            return View(objds);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {

          
            onlineShopEntities.Entry(category).State = EntityState.Modified;
            onlineShopEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}