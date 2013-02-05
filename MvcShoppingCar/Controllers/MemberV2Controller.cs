﻿using System;
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