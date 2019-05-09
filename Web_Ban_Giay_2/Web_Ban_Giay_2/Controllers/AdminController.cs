using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models.Entities;

namespace Web_Ban_Giay_2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpPost]
        public ActionResult Admin_page()
        {
            ShopModel db = new ShopModel();

            string us = Request.Form["us"];
            string mk = Request.Form["mk"];

            var lst = db.TaiKhoans.ToList();

            
                string u = "admin";
                string m = "123";

                if (u.Equals(us) && m.Equals(mk))
                {
                    //TempData["msg"] = "Dang nhap thanh cong";
                    Session["username"] = us;
                    return View();
                }
                else
                {
                    TempData["msg"] = "Tài khoản hoặc mật khẩu không chính xác !";
                    return View("~/Views/Home/Login.cshtml");

                }
            

            //return View();
        }

        //public ActionResult Admin_page(string us)
        //{
        //    if (Session["username"] == null)
        //        return View("~Views/Home/Login.cshtml");
        //    else
        //        return View();
        //}
    }
}