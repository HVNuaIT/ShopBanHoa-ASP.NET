using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach_BCWed.Controllers
{
    public class AboutController : Controller
    {
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        // GET: About
        public ActionResult Index()
        {
            var ds = onlineShopEntities.Abouts.ToList();
            return View(ds);
        }
    }
}