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

        public PartialViewResult Menu(string category = null, bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Items
                .Select(game => game.Category)
                .Distinct()
                .OrderBy(x => x);

            string viewName = horizontalNav ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, categories);
        }
    }
}