using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotaStore.Domain.Abstract;
using DotaStore.Domain.Entities;
using DotaStore.UI.Models;

namespace DotaStore.UI.Controllers
{
    public class CartController : Controller
    {
        private IRepository _repository;

        public CartController(IRepository repository)
        {
            _repository = repository;
        }

        public RedirectToRouteResult AddToCart(Guid Id, string returnUrl)
        {
            var item = _repository.Items
                .FirstOrDefault(i => i.ID==Id);

            if (item != null)
            {
                GetCart().AddItem(item,1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Guid Id, string returnUrl)
        {
            var item = _repository.Items
                .FirstOrDefault(i => i.ID == Id);

            if (item != null)
            {
                GetCart().RemoveLine(item);
            }
            return RedirectToAction("Index", new { returnUrl });

        }
        // GET: Cart
        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            
            });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}