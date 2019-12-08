using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IItemRepository repository;

        public NavController(IItemRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Items
                .Select(item => item.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}