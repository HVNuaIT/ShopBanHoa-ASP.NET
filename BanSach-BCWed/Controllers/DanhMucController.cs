using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach_BCWed.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        public ActionResult Index()
        {
            var listCA = onlineShopEntities.Categories.ToList();
            return View(listCA);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listPro = onlineShopEntities.Products.Where(n => n.CategoryId == Id).ToList();


            return View(listPro);
        }
    }
}