using BanSach_BCWed;
using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach_BCWed.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        public ActionResult Index(int Id,Product product)
        {
            var objPR = onlineShopEntities.Products.Where(x => x.Id == Id).FirstOrDefault();
            var listCa = onlineShopEntities.Categories.ToList();
            var listPr = onlineShopEntities.Products.Where(x => x.Id == objPR.CategoryId).ToList();


               Productdetail s = new Productdetail();
            s.objpr = objPR;
            s.dsca = listCa;
            s.dsPr = listPr;
            return View(s);
        }
    }
}