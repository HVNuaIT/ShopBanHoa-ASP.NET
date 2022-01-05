using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanSach_BCWed.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        public int Quatity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product pro , int quatity = 1)
        {
            var item = items.FirstOrDefault(s => s.product.Id == pro.Id); 
            if (item == null)
            {
                items.Add(new CartItem
                {
                    product = pro,
                    Quatity = quatity
                })  
                ;


            }
            else
            {
                item.Quatity += quatity;
            }
        }
        public void Update(int id ,int qualiti)
        {
            var item = items.Find(s => s.product.Id == id);
            if (item != null)
            {
                item.Quatity = qualiti;
            }
        }
        public double TongTien()
        {
            var tien = items.Sum(s => s.product.Price * s.Quatity);
            return (double)tien;
        }
        public void Xoa(int id)
        {
            items.RemoveAll(s => s.product.Id == id);
        }
    }
}