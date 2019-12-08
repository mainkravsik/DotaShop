using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Controllers;
using System.Web.Mvc;
using WebUI.Models;
using System;
using WebUI.HtmlHelpers;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item>
            {
                new Item { ItemId = 1, Name = "Item1"},
                new Item { ItemId = 2, Name = "Item2"},
                new Item { ItemId = 3, Name = "Item3"},
                new Item { ItemId = 4, Name = "Item4"},
                new Item { ItemId = 5, Name = "Item5"}
            });
            ItemController controller = new ItemController(mock.Object)
            {
                pageSize = 3
            };

            // Действие (act)
            ItemsListViewModel result = (ItemsListViewModel)controller.List(null, 2).Model;

            // Утверждение
            List<Item> Items = result.Items.ToList();
            Assert.IsTrue(Items.Count == 2);
            Assert.AreEqual(Items[0].Name, "Item4");
            Assert.AreEqual(Items[1].Name, "Item5");
        }
    }
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // ...
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item>
            {
                new Item { ItemId = 1, Name = "Item1"},
                new Item { ItemId = 2, Name = "Item2"},
                new Item { ItemId = 3, Name = "Item3"},
                new Item { ItemId = 4, Name = "Item4"},
                new Item { ItemId = 5, Name = "Item5"}
            });
            ItemController controller = new ItemController(mock.Object)
            {
                pageSize = 3
            };

            // Act
            ItemsListViewModel result
                = (ItemsListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
        [TestMethod]
        public void Can_Filter_Items()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item>
            {
                new Item { ItemId = 1, Name = "Item1", Category="Cat1"},
                new Item { ItemId = 2, Name = "Item2", Category="Cat2"},
                new Item { ItemId = 3, Name = "Item3", Category="Cat1"},
                new Item { ItemId = 4, Name = "Item4", Category="Cat2"},
                new Item { ItemId = 5, Name = "Item5", Category="Cat3"}
            });
            ItemController controller = new ItemController(mock.Object)
            {
                pageSize = 3
            };

            // Action
            List<Item> result = ((ItemsListViewModel)controller.List("Cat2", 1).Model)
                .Items.ToList();

            // Assert
            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Name == "Item2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "Item4" && result[1].Category == "Cat2");
        }
        [TestMethod]
        public void Can_Create_Categories()
        {
            // Организация - создание имитированного хранилища
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item>
            {
                new Item { ItemId = 1, Name = "Item1", Category="Carry"},
                new Item { ItemId = 2, Name = "Item2", Category="Support"},
                new Item { ItemId = 3, Name = "Item3", Category="Support"},
                new Item { ItemId = 4, Name = "Item4", Category="Carry"},
            });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Действие - получение набора категорий
            List<string> results = ((IEnumerable<string>)target.Menu().Model).ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0], "Carry");
            Assert.AreEqual(results[1], "Support");
            
        }
        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Организация - создание имитированного хранилища
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[] 
            {
                new Item { ItemId = 1, Name = "Item1", Category="Симулятор"},
                new Item { ItemId = 2, Name = "Item2", Category="Шутер"}
            });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Организация - определение выбранной категории
            string categoryToSelect = "Шутер";

            // Действие
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Утверждение
            Assert.AreEqual(categoryToSelect, result);
        }
        [TestMethod]
        public void Generate_Category_Specific_Item_Count()
        {
            /// Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item>
            {
                new Item { ItemId = 1, Name = "Item1", Category="Cat1"},
                new Item { ItemId = 2, Name = "Item2", Category="Cat2"},
                new Item { ItemId = 3, Name = "Item3", Category="Cat1"},
                new Item { ItemId = 4, Name = "Item4", Category="Cat2"},
                new Item { ItemId = 5, Name = "Item5", Category="Cat3"}
            });
            ItemController controller = new ItemController(mock.Object)
            {
                pageSize = 3
            };

            // Действие - тестирование счетчиков товаров для различных категорий
            int res1 = ((ItemsListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ItemsListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ItemsListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ItemsListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

            // Утверждение
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Организация - создание нескольких тестовых игр
            Item item1 = new Item { ItemId = 1, Name = "Item1" };
            Item item2 = new Item { ItemId = 2, Name = "Item2" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(item1, 1);
            cart.AddItem(item2, 1);
            List<CartLine> results = cart.Lines.ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Item, item1);
            Assert.AreEqual(results[1].Item, item2);
        }
        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Организация - создание нескольких тестовых игр
            Item Item1 = new Item { ItemId = 1, Name = "Item1" };
            Item Item2 = new Item { ItemId = 2, Name = "Item2" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(Item1, 1);
            cart.AddItem(Item2, 1);
            cart.AddItem(Item1, 5);
            List<CartLine> results = cart.Lines.OrderBy(c => c.Item.ItemId).ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantity, 6);    // 6 экземпляров добавлено в корзину
            Assert.AreEqual(results[1].Quantity, 1);
        }
        [TestMethod]
        public void Can_Remove_Line()
        {
            // Организация - создание нескольких тестовых игр
            Item Item1 = new Item { ItemId = 1, Name = "Item1" };
            Item Item2 = new Item { ItemId = 2, Name = "Item2" };
            Item Item3 = new Item { ItemId = 3, Name = "Item3" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Организация - добавление нескольких игр в корзину
            cart.AddItem(Item1, 1);
            cart.AddItem(Item2, 4);
            cart.AddItem(Item3, 2);
            cart.AddItem(Item2, 1);

            // Действие
            cart.RemoveLine(Item2);

            // Утверждение
            Assert.AreEqual(cart.Lines.Where(c => c.Item == Item2).Count(), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }
        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Организация - создание нескольких тестовых игр
            Item Item1 = new Item { ItemId = 1, Name = "Item1", Price = 100 };
            Item Item2 = new Item { ItemId = 2, Name = "Item2", Price = 55 };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(Item1, 1);
            cart.AddItem(Item2, 1);
            cart.AddItem(Item1, 5);
            decimal result = cart.ComputeTotalValue();

            // Утверждение
            Assert.AreEqual(result, 655);
        }
        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Организация - создание нескольких тестовых игр
            Item Item1 = new Item { ItemId = 1, Name = "Item1", Price = 100 };
            Item Item2 = new Item { ItemId = 2, Name = "Item2", Price = 55 };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(Item1, 1);
            cart.AddItem(Item2, 1);
            cart.AddItem(Item1, 5);
            cart.Clear();

            // Утверждение
            Assert.AreEqual(cart.Lines.Count(), 0);
        }
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Организация - создание имитированного хранилища
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item> {
            new Item {ItemId = 1, Name = "Игра1", Category = "Кат1"},
            }.AsQueryable());

            // Организация - создание корзины
            Cart cart = new Cart();

            // Организация - создание контроллера
            CartController controller = new CartController(mock.Object);

            // Действие - добавить игру в корзину
            controller.AddToCart(cart, 1, null);

            // Утверждение
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToList()[0].Item.ItemId, 1);
        }

        /// <summary>
        /// После добавления игры в корзину, должно быть перенаправление на страницу корзины
        /// </summary>
        [TestMethod]
        public void Adding_Item_To_Cart_Goes_To_Cart_Screen()
        {
            // Организация - создание имитированного хранилища
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new List<Item> 
{
            new Item {ItemId = 1, Name = "Игра1", Category = "Кат1"},
            }.AsQueryable());

            // Организация - создание корзины
            Cart cart = new Cart();

            // Организация - создание контроллера
            CartController controller = new CartController(mock.Object);

            // Действие - добавить игру в корзину
            RedirectToRouteResult result = controller.AddToCart(cart, 2, "myUrl");

            // Утверждение
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        // Проверяем URL
        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Организация - создание корзины
            Cart cart = new Cart();

            // Организация - создание контроллера
            CartController target = new CartController(null);

            // Действие - вызов метода действия Index()
            CartIndexViewModel result
                = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

            // Утверждение
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Организация - создание имитированного обработчика заказов
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            // Организация - создание пустой корзины
            Cart cart = new Cart();

            // Организация - создание деталей о доставке
            ShippingDetails shippingDetails = new ShippingDetails();

            // Организация - создание контроллера
            CartController controller = new CartController(null, mock.Object);

            // Действие
            ViewResult result = controller.Checkout(cart, shippingDetails);

            // Утверждение — проверка, что заказ не был передан обработчику 
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
                Times.Never());

            // Утверждение — проверка, что метод вернул стандартное представление 
            Assert.AreEqual("", result.ViewName);

            // Утверждение - проверка, что-представлению передана неверная модель
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }
        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            // Организация - создание имитированного обработчика заказов
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            // Организация — создание корзины с элементом
            Cart cart = new Cart();
            cart.AddItem(new Item(), 1);

            // Организация — создание контроллера
            CartController controller = new CartController(null, mock.Object);

            // Организация — добавление ошибки в модель
            controller.ModelState.AddModelError("error", "error");

            // Действие - попытка перехода к оплате
            ViewResult result = controller.Checkout(cart, new ShippingDetails());

            // Утверждение - проверка, что заказ не передается обработчику
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
                Times.Never());

            // Утверждение - проверка, что метод вернул стандартное представление
            Assert.AreEqual("", result.ViewName);

            // Утверждение - проверка, что-представлению передана неверная модель
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }
        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
            // Организация - создание имитированного обработчика заказов
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            // Организация — создание корзины с элементом
            Cart cart = new Cart();
            cart.AddItem(new Item(), 1);

            // Организация — создание контроллера
            CartController controller = new CartController(null, mock.Object);

            // Действие - попытка перехода к оплате
            ViewResult result = controller.Checkout(cart, new ShippingDetails());

            // Утверждение - проверка, что заказ передан обработчику
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
                Times.Once());

            // Утверждение - проверка, что метод возвращает представление 
            Assert.AreEqual("Completed", result.ViewName);

            // Утверждение - проверка, что представлению передается допустимая модель
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }

    }

}