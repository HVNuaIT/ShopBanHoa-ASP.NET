using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach_BCWed.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
        
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            } return cart;
        }
        public ActionResult AddtoCart(int Id/*, int quanlity*/)
        {
            var pro = onlineShopEntities.Products.SingleOrDefault(s => s.Id == Id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
             return RedirectToAction("ShowToCart", "Cart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            
                return RedirectToAction("ShowToCart", "Cart");
                Cart cart = Session["Cart"] as Cart;


            return View(cart);
        }
        public ActionResult Update(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int idPro =int.Parse( form["IDPro"]);
            int quality = int.Parse(form["Qualty"]);
            cart.Update(idPro, quality);
            return RedirectToAction("ShowToCart", "Cart");
        }
       public ActionResult Remove (int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Xoa(id);
            return RedirectToAction("ShowToCart", "Cart");
        }
    }
}