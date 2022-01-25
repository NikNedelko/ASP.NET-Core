using System;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach (var elem in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = elem.car.id,
                    orderID = order.id,
                    price = elem.car.price
                };
                appDbContent.OrderDetail.Add(orderDetail);

            }
            appDbContent.SaveChanges();
        }
    }
}