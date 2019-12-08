using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ItemController : Controller
    {
        private IItemRepository repository;
        public int pageSize = 4;

        public ItemController(IItemRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            ItemsListViewModel model = new ItemsListViewModel
            {
                Items = repository.Items
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(item => item.ItemId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                repository.Items.Count() :
                repository.Items.Where(item => item.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int itemId)
        {
            Item item = repository.Items
                .FirstOrDefault(g => g.ItemId == itemId);

            if (item != null)
            {
                return File(item.ImageData, item.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}