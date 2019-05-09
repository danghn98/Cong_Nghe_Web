using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models;

namespace Web_Ban_Giay_2.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
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
    }
}