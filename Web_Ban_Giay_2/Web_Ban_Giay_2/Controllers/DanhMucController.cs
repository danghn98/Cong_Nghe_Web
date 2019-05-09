using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models;

namespace Web_Ban_Giay_2.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
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