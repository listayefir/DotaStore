using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotaStore.Domain.Abstract;
using DotaStore.UI.Models;

namespace DotaStore.UI.Controllers
{
    public class ItemsController : Controller
    {
        private IRepository _repo;
        public int PageSize = 3;

        public ItemsController(IRepository productRepository)
        {
            _repo = productRepository;
        }
        // GET: Items
        public ViewResult List(string category, int page=1)
        {
            var viewModel = new ItemsViewModel()
            {
                Items = _repo.Items
                .Where(x=>x.Cathegory==category|| category==null)
                    .OrderBy(i => i.Name)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category==null
                                    ? _repo.Items.Count()
                                    :_repo.Items
                                    .Count(x => x.Cathegory==category)
                },
                CurrentCategory=category
            };

            return View(viewModel);
        }
    }
}