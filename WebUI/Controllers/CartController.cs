using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using WebUI.Models;
using Domain.Abstract;

namespace WebUI.Controllers
{
    
    public class CartController : Controller
    {
        private IItemRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IItemRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }




        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int itemId, string returnUrl)
        {
            Item item = repository.Items
                .FirstOrDefault(g => g.ItemId == itemId);

            if (item != null)
            {
                cart.AddItem(item, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int itemId, string returnUrl)
        {
            Item item = repository.Items
                .FirstOrDefault(g => g.ItemId == itemId);

            if (item != null)
            {
                cart.RemoveLine(item);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        
    }
}