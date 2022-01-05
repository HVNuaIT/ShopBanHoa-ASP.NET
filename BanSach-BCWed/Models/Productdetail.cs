using BanSach_BCWed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanSach_BCWed.Models
{
    public class Productdetail
    {
        public Product objpr { get; set; }
        public List<Category> dsca { get; set; }

        public List<Product> dsPr { get; set; }
    }
}