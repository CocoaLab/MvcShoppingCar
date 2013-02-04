using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShoppingCar.Models;

namespace MvcShoppingCar.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var data = new List<ProductCategory>()
            { 
            
                new ProductCategory(){Id = 1,Name = "文具"},
                new ProductCategory(){Id = 2,Name = "禮品"},
                new ProductCategory(){Id = 3,Name = "書藉"},
                new ProductCategory(){Id = 4,Name = "文具"}
            
            };


            return View(data);
        }

        //商品列表
        public ActionResult ProductList(int _id) 
        {
            return View();
        }

        //商品明細
        public ActionResult ProdctDetail(int _id)
        {
            return View();
        }
    }
}
