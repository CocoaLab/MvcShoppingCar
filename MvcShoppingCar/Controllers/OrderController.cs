using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShoppingCar.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        //完成訂單的頁面
        public ActionResult Complete()
        {
            return View();
        }

        //將訂單寫資入資料庫
        [HttpPost]
        public ActionResult Complete(FormCollection form) 
        {
        //TODO: 將訂單資料與購物車寫入資料庫
        //TODO: 訂單完成後須清空購物車資料
            return RedirectToAction("Index", "Home");
        }



    }
}
