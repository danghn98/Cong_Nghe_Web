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

        

        public ActionResult Filter(int? page, string thuonghieu, string loaigiay, int firstP, int finalP)
        {
            
            if (page == null) page = 1;
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var lst = db.Giays.ToList();

            if (thuonghieu == "0" && loaigiay == "0" && firstP == 0 && finalP == 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).ToList();
            }
            else if (thuonghieu != "0" && loaigiay == "0" && firstP == 0 && finalP == 0)
            {
                
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).ToList();
            }
            else if (thuonghieu != "0" && loaigiay != "0" && firstP == 0 && finalP == 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).Where(lg=>lg.LoaiGiay.Tenloaigiay == loaigiay).ToList();
            }
            else if (thuonghieu != "0" && loaigiay != "0" && firstP == 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).Where(lg=>lg.LoaiGiay.Tenloaigiay == loaigiay).Where(gb=>gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu != "0" && loaigiay != "0" && firstP != 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).Where(lg => lg.LoaiGiay.Tenloaigiay == loaigiay).Where(gb => gb.Giaban >= firstP && gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu != "0" && loaigiay == "0" && firstP == 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).Where(gb => gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu != "0" && loaigiay == "0" && firstP != 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).Where(gb => gb.Giaban >= firstP && gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu == "0" && loaigiay != "0" && firstP == 0 && finalP == 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(lg => lg.LoaiGiay.Tenloaigiay == loaigiay).ToList();
            }
            else if (thuonghieu == "0" && loaigiay != "0" && firstP == 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(lg => lg.LoaiGiay.Tenloaigiay == loaigiay).Where(gb=>gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu == "0" && loaigiay != "0" && firstP != 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(lg => lg.LoaiGiay.Tenloaigiay == loaigiay).Where(gb => gb.Giaban>=firstP && gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu == "0" && loaigiay == "0" && firstP == 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(gb => gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu == "0" && loaigiay == "0" && firstP != 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(gb => gb.Giaban >= firstP && gb.Giaban <= finalP).ToList();
            }
            else if (thuonghieu != "0" && loaigiay != "0" && firstP != 0 && finalP != 0)
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(x => x.LoaiGiay.Tenloaigiay == loaigiay).Where(th => th.NhaSanXuat.Tennhasx == thuonghieu).Where(gb=>gb.Giaban >= firstP && gb.Giaban <= finalP).ToList();
            }
            else
            {
                lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(x => x.LoaiGiay.Tenloaigiay == "0").ToList();
            }

            return View("List_SanPham",lst.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Search(int? page, string search)
        {
            if (page == null) page = 1;
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var lst = db.Giays.Include(x => x.ChiTietSizes.Select(y => y.Size)).Include(x => x.ChiTietMaus.Select(y => y.Mau)).Include(lg => lg.LoaiGiay).Include(nsx => nsx.NhaSanXuat).Where(tg=>tg.Tengiay.Contains(search)).ToList();

            return View("List_SanPham", lst.ToPagedList(pageNumber, pageSize));
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

        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult ThanhToan()
        {
            return View();
        }

    }
}