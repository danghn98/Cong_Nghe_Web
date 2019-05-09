using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models;
using Web_Ban_Giay_2.Models.Entities;

namespace Web_Ban_Giay_2.Controllers
{
    public class SanPhamController : Controller
    {
        ShopModel db = new ShopModel();
        // GET: SanPham
        public ActionResult San_Pham()
        {
            
            //var lst = db.Giays.SqlQuery("Select Tengiay, Soluong, Maloaigiay from Giay").ToList<Giay>();
            return View(db.Giays.ToList());
        }

        public ActionResult Create_SP()
        {
            return View();
        }

        //public ActionResult Edit_SP(int id)
        //{
        //    // truy van user theo id
        //    San_Pham sp = new San_Pham();
        //    sp.Id = id;
        //    sp.TenGiay = "San pham ";
        //    sp.GiaBan = 123;
        //    sp.Size = 39;
        //    sp.Mau = "Đen";
        //    sp.ThuongHieu = "Adidas";
        //    return View(sp);
        //}

        //[HttpPost]
        //public ActionResult Edit_SP()
        //{
        //    return View();

        //}

        public ActionResult Edit_SP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maloaigiay = new SelectList(db.LoaiGiays, "Maloaigiay", "Tenloaigiay", giay.Maloaigiay);
            ViewBag.Manhacc = new SelectList(db.NhaCungCaps, "Manhacc", "Tennhacc", giay.Manhacc);
            ViewBag.Manhasx = new SelectList(db.NhaSanXuats, "Manhasx", "Tennhasx", giay.Manhasx);
            return View(giay);
        }

        // POST: Giays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_SP([Bind(Include = "Magiay,Manhacc,Manhasx,Maloaigiay,Tengiay,Soluongton,Giaban,Hinhanh")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("San_Pham");
            }
            ViewBag.Maloaigiay = new SelectList(db.LoaiGiays, "Maloaigiay", "Tenloaigiay", giay.Maloaigiay);
            ViewBag.Manhacc = new SelectList(db.NhaCungCaps, "Manhacc", "Tennhacc", giay.Manhacc);
            ViewBag.Manhasx = new SelectList(db.NhaSanXuats, "Manhasx", "Tennhasx", giay.Manhasx);
            return View(giay);
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
    }
}