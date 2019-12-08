using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IItemRepository repository;

        public AdminController(IItemRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Items);
        }
        
        public ViewResult Edit(int itemId)
        {
            Item item = repository.Items
                .FirstOrDefault(g => g.ItemId == itemId);
            return View(item);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Item item, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    item.ImageMimeType = image.ContentType;
                    item.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(item.ImageData, 0, image.ContentLength);
                }
                repository.SaveItem(item);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", item.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(item);
            }
        }
        [HttpPost]
        public ActionResult Delete(int itemId)
        {
            Item deletedItem = repository.DeleteItem(itemId);
            if (deletedItem != null)
            {
                TempData["message"] = string.Format("Предмет \"{0}\" был удален",
                    deletedItem.Name);
            }
            return RedirectToAction("Index");
        }
        public ViewResult Create()
        {
            return View("Edit", new Item());
        }
    }
}