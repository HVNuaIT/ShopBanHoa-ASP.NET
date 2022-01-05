using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach_BCWed.Controllers
{
    public class NewsController : Controller
    {
        // GET: News

        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        public ActionResult Index()
            
       
        {
            var list  =onlineShopEntities.News.ToList();
            
            return View(list);
        }
    }
}