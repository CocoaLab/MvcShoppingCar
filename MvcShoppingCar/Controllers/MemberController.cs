using MvcShoppingCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcShoppingCar.Controllers
{
    public class MemberController : Controller
    {
        private string pwSalt = "aAPa435KMKojzvk309u0uadsifjakd23kxAFDGSnjvlk";
        //
        // GET: /Member/
        //註冊頁面
        public ActionResult Register()
        {
            return View();
        }

        //寫入會員資料
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn,authcode")] Member member)
        {
            //var chk_member = 
            return View();
        }

      //會員登入畫面
        public ActionResult Login(string retureUrl) 
        {
            ViewBag.RetureUrl = retureUrl;
            return View();
        }

        //執行會員登入
        [HttpPost]
        public ActionResult Login(string email, string password, string retureUrl) 
        {
            if (ValidateUser(email, password)) 
            {
                FormsAuthentication.SetAuthCookie(email, false);
                if (string.IsNullOrEmpty(retureUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else {

                    return Redirect(retureUrl);
                
                }

            }
            ModelState.AddModelError("", "你輸入的帳號密碼錯誤");
            return View();
        
        }

        private bool ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        //執行登出
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        
        }

    }
}
