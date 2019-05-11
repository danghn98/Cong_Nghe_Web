using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models.Entities;
using PagedList;

namespace Web_Ban_Giay_2.Controllers
{
    public class SanPhamController : Controller
    {
        private ShopModel db = new ShopModel();

        // GET: SanPham
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).ToList();

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 10;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));

            //var lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).ToList();
            //return View(lst.ToList());
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int? id)
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
            return View(giay);
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            ViewBag.Maloaigiay = new SelectList(db.LoaiGiays, "Maloaigiay", "Tenloaigiay");
            ViewBag.Manhacc = new SelectList(db.NhaCungCaps, "Manhacc", "Tennhacc");
            ViewBag.Manhasx = new SelectList(db.NhaSanXuats, "Manhasx", "Tennhasx");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magiay,Manhacc,Manhasx,Maloaigiay,Tengiay,Soluongton,Giaban,Hinhanh,Mota")] Giay giay, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if (UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/jpeg")

                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Content/img_product/" + UploadImage.FileName);
                        giay.Hinhanh = UploadImage.FileName;
                    }

                    else return View();
                }
                else
                    return View();
                db.Giays.Add(giay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Maloaigiay = new SelectList(db.LoaiGiays, "Maloaigiay", "Tenloaigiay", giay.Maloaigiay);
            ViewBag.Manhacc = new SelectList(db.NhaCungCaps, "Manhacc", "Tennhacc", giay.Manhacc);
            ViewBag.Manhasx = new SelectList(db.NhaSanXuats, "Manhasx", "Tennhasx", giay.Manhasx);
            return View(giay);
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magiay,Manhacc,Manhasx,Maloaigiay,Tengiay,Soluongton,Giaban,Hinhanh,Mota")] Giay giay, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if (UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/jpeg")

                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Content/img_product/" + UploadImage.FileName);
                        giay.Hinhanh = UploadImage.FileName;
                    }

                    else return View();
                }
                else
                    return View();
                db.Entry(giay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maloaigiay = new SelectList(db.LoaiGiays, "Maloaigiay", "Tenloaigiay", giay.Maloaigiay);
            ViewBag.Manhacc = new SelectList(db.NhaCungCaps, "Manhacc", "Tennhacc", giay.Manhacc);
            ViewBag.Manhasx = new SelectList(db.NhaSanXuats, "Manhasx", "Tennhasx", giay.Manhasx);
            return View(giay);
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int? id)
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
            return View(giay);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giay giay = db.Giays.Find(id);
            db.Giays.Remove(giay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
