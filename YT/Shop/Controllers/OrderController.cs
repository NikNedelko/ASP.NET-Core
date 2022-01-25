using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders,ShopCart shopCart){
            this.allOrders=allOrders;
            this.shopCart=shopCart;
        }
         //тут будет находиться форма для заполнения
         public IActionResult Checkout(){
             return View();
         }
         
         [HttpPost]
         public IActionResult Checkout(Order order){
             shopCart.listShopItems = shopCart.getShopItems();

             if(shopCart.listShopItems.Count==0){
                 ModelState.AddModelError("","empty bin");
             }
             if(ModelState.IsValid){
                 allOrders.createOrder(order);
                 return RedirectToAction("Complete");
             }
             return View(order);
         }
         public IActionResult Compleate(){
             ViewBag.Message ="Заказ успешно обработан"; 
             return View();
         }
    }
}