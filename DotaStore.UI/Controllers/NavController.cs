using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DotaStore.Domain.Abstract;

namespace DotaStore.UI.Controllers
{
    public class NavController : Controller
    {
        private IRepository _repo;

        public NavController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            var categories = _repo.Items
                .Select(x => x.Cathegory)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
        
    }
}