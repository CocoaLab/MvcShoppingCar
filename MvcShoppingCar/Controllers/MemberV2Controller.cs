using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShoppingCar.Models;
using System.Web.Security.Cryptography;
using System.Web.Security;

namespace MvcShoppingCar.Controllers
{
    public class MemberV2Controller : Controller
    {
        private string pwSalt = "aAPa435KMKojzvk309u0uadsifjakd23kxAFDGSnjvlk";
        private MemberContext db = new MemberContext();

        //
        // GET: /MemberV2/

        public ActionResult Index()
        {
            return View(db.Members.ToList());
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
                else
                {

                    return Redirect(retureUrl);

                }

            }
            ModelState.AddModelError("", "你輸入的帳號密碼錯誤");
            return View();

        }

        /// <summary>
        /// 驗證使用者是否通過驗證
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidateUser(string email, string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt+password,"SHA1");
            var member = (from p in db.Members
                          where p.email == email && p.password == hash_pw
                          select p).FirstOrDefault();

            if (member != null)
            {
                if (member.authcode == null)
                {
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "您尚未通過會員驗證，請收信並點會員驗證連結");
                    return false;
                }
            }
            else
            {
                ModelState.AddModelError("", "您輸入帳號或密碼錯誤");
                return false;
            }
        }

        //執行登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }


        /// <summary>
        /// 使用者註冊
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        //寫入會員資料
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn,authcode")] Member member)
        {
            var chk_member = db.Members.Where(p => p.email == member.email).FirstOrDefault();
            if (chk_member != null) {

                ModelState.AddModelError("Email", "你輸入的mail已經有人註冊了");
            }

            if (ModelState.IsValid)
            {
                member.password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.password, "SHA1");
                member.RegisterOn = DateTime.Now;
                member.authcode = Guid.NewGuid().ToString();
                db.Members.Add(member);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

            
        }


        public ActionResult ValidateRegister(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            var member = db.Members.Where(p => p.authcode == id).FirstOrDefault();

            if (member != null)
            {
                TempData["LastTempMessage"] = "會員驗證成功，您現可以登入網站了";
                //驗證成功後把auth code清空
                member.authcode = null;
                db.SaveChanges();

            }
            else
            {
                TempData["LastTempMessage"] = "查無此會員驗證碼，您可能已經驗證過了";
            }
            return RedirectToAction("Login", "Member");

        }


        //
        // GET: /MemberV2/Details/5

        public ActionResult Details(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // GET: /MemberV2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MemberV2/Create

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //
        // GET: /MemberV2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /MemberV2/Edit/5

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // GET: /MemberV2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /MemberV2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}