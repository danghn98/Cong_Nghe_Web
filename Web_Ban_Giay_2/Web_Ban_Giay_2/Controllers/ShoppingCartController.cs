using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ban_Giay_2.Models.Entities;

namespace Web_Ban_Giay_2.Controllers
{
    public class ShoppingCartController : Controller
    {
        [HttpPost]
        // GET: ShoppingCart
        public ActionResult Add(int id, string mau, int size, int amount)
        {
            Shopping_Cart cart = (Shopping_Cart)Session["cart"];
            if (cart == null)
            {
                cart = new Shopping_Cart();
            }

            ShopModel db = new ShopModel();
            Giay g = db.Giays.Find(id);
            if (g != null)
            {
                cart.InsertItem(g.Magiay, g.Tengiay, (double)g.Giaban, mau/*g.ChiTietMaus.Select(x => x.Mau.Tenmau).ToList()*/, size/*g.ChiTietSizes.Select(y => y.Size.Sosize).ToList()*/, amount);
            }

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Remove(int id)
        {
            Shopping_Cart cart = (Shopping_Cart)Session["cart"];
            if (cart == null)
            {
                cart = new Shopping_Cart();
            }

            cart.RemoveItem(id);

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Update(int id, int amount)
        {
            Shopping_Cart cart = (Shopping_Cart)Session["cart"];
            if (cart == null)
            {
                cart = new Shopping_Cart();
            }

            cart.UpdateAmount(id, amount);

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Cart()
        {
            return View();
        }
    }
}