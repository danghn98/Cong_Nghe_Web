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
    public class HomeController : Controller
    {
        ShopModel db = new ShopModel();
        public ActionResult Index()
        {

            return View(db.Giays.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult List_SanPham(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).ToList();

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 9;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ChiTiet_SP(int? id)
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
    }
}