using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach_BCWed.Controllers
{
    public class ContactController : Controller
    {
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        // GET: Contact
        public ActionResult Index()
        {
            
            return View();
        }
    }
}