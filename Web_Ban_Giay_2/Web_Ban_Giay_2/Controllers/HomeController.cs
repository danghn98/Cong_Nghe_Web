using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models;

namespace Web_Ban_Giay_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_page()
        {
            string us = Request.Form["us"]; 
            string mk = Request.Form["mk"];

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
                return RedirectToAction("/Login");

            }

            //return View();
        }

        public ActionResult San_Pham()
        {
            List<San_Pham> list = new List<San_Pham>();
            for (int i = 0; i < 10; i++)
            {
                San_Pham sp = new San_Pham();
                sp.Id = i;
                sp.TenGiay = "San pham " + i;
                sp.GiaBan = 123 + i;
                sp.Size = 39;
                sp.Mau = "Đen";
                sp.ThuongHieu = "Adidas";
                list.Add(sp);
            }
            return View(list);
        }

        public ActionResult Create_SP()
        {
            return View();
        }

        public ActionResult Edit_SP(int id)
        {
            // truy van user theo id
            San_Pham sp = new San_Pham();
            sp.Id = id;
            sp.TenGiay = "San pham ";
            sp.GiaBan = 123;
            sp.Size = 39;
            sp.Mau = "Đen";
            sp.ThuongHieu = "Adidas";
            return View(sp);
        }

        [HttpPost]
        public ActionResult Edit_SP()
        {
            return View();
            
        }

        public ActionResult Details_SP(int id)
        {
            // truy van user theo id
            San_Pham sp = new San_Pham();
            sp.Id = id;
            sp.TenGiay = "San pham ";
            sp.GiaBan = 123;
            sp.Size = 39;
            sp.Mau = "Đen";
            sp.ThuongHieu = "Adidas";
            return View(sp);
        }

        [HttpPost]
        public ActionResult Details_SP()
        {
            return View();
        }

        public ActionResult Delete_SP(int id)
        {
            // truy van user theo id
            San_Pham sp = new San_Pham();
            sp.Id = id;
            sp.TenGiay = "San pham ";
            sp.GiaBan = 123;
            sp.Size = 39;
            sp.Mau = "Đen";
            sp.ThuongHieu = "Adidas";
            return View(sp);
        }

        public ActionResult Tai_Khoan()
        {
            List<Tai_Khoan> list = new List<Tai_Khoan>();
            for (int i = 0; i < 10; i++)
            {
                Tai_Khoan tk = new Tai_Khoan();
                tk.name = "Tai Khoan " + i;
                tk.pass = "123" + i;
                list.Add(tk);
            }
            return View(list);
        }

        public ActionResult Create_TK()
        {
            return View();
        }

        public ActionResult Edit_TK(int id)
        {
            // truy van user theo id
            Tai_Khoan tk = new Tai_Khoan();
            tk.name = "Tai Khoan";
            tk.pass = "123";
            tk.id = id;
            return View(tk);
        }

        public ActionResult Details_TK(int id)
        {
            // truy van user theo id
            Tai_Khoan tk = new Tai_Khoan();
            tk.name = "Tai Khoan";
            tk.pass = "123";
            tk.id = id;
            return View(tk);
        }

        public ActionResult Delete_TK(int id)
        {
            // truy van user theo id
            Tai_Khoan tk = new Tai_Khoan();
            tk.name = "Tai Khoan";
            tk.pass = "123";
            tk.id = id;
            return View(tk);
        }

        public ActionResult Danh_Muc()
        {
            // truy van user theo id
            List<Danh_Muc> list = new List<Danh_Muc>();
            for (int i = 0; i < 10; i++)
            {
                Danh_Muc dm = new Danh_Muc();
                dm.Id = i;
                dm.TenDanhMuc = "Danh mục " + i;
                dm.MoTa = "Mô tả " + i;
                list.Add(dm);
            }
            return View(list);
        }

        public ActionResult Edit_DM(int id)
        {
            // truy van user theo id
            Danh_Muc dm = new Danh_Muc();
            dm.Id = id;
            dm.TenDanhMuc = "Danh muc";
            dm.MoTa = "Mô tả";
            return View(dm);
        }
    }
}