using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent appDbContent;
        public ShopCart(AppDbContent appDbContent) => this.appDbContent = appDbContent;
        public string ShopCartId { get; set; }

        public List<ShopCartItems> listShopItems { get; set; }  
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;//создание объекта новой сессии
            var context = services.GetRequiredService<AppDbContent>();
            string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", ShopCartId);
            return new ShopCart(context) { ShopCartId = ShopCartId };
        }
        public void AddToCart(Car car){
            appDbContent.ShopCartItems.Add(new ShopCartItems{
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
                
            });
            appDbContent.SaveChanges();
        }
        public List<ShopCartItems> getShopItems(){
            return appDbContent.ShopCartItems.Where(c=>c.ShopCartId==ShopCartId).Include(s=>s.car).ToList();
        }
    }
}