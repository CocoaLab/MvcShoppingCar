using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShoppingCar.Controllers
{
    public class CartController : Controller
    {
       //加入產品項目到購物車，如果沒有傳入amount參數則預設為1
        [HttpPost]
        public ActionResult AddToCart(int ProductId, int Amount = 1) 
        {
            return View();
        }

        // 顯示目前的購物車項目
        public ActionResult Index() 
        {
            return View();
        }

        //移除購物車項目
        [HttpPost]
        public ActionResult Remove(int ProductId) 
        {
            return View();
        }

        //更新購物車中特定項目的數量
        [HttpPost]
        public ActionResult UpdateAmount(int ProductId, int NewAmount) 
        {
            return View();
        }

    }
}
