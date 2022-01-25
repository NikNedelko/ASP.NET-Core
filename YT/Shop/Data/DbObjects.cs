using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(content => content.Value));

            if (!content.Category.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla Model S",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Красивый, быстрый и очень тихиц автомобиль Теслы",
                        img = "/img/35a8fa2163d04f4503a77a8ef2d7b5483737259a.jpg.webp",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = category["Электромобили"]
                    },

                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "тихий и спокойный ",
                        longDesc = "Умный автомобиль для городской жизни",
                        img = "/img/cattouchret.jpeg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = category["Классические автомобили"]
                    },

                    new Car
                    {
                        name = "BMW M3",
                        shortDesc = "Дерзкий и стильный ",
                        longDesc = "Умный автомобиль для городской жизни",
                        img = "/img/bmw-3-series-sedan-m-automobiles-sp-desktop.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = category["Классические автомобили"]
                    },

                    new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/backgroundimage.MQ6.12.20210630223843.jpeg",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = category["Классические автомобили"]
                    },

                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Бесшумный и экономный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/nissan_leaf_877464.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = category["Электромобили"]
                    }
                );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]{
                        new Category{categoryName="Электромобили", desc="Современый вид транспорта"},
                        new Category{categoryName="Классические автомобили", desc="Автомобили с двигателем внутреннего згорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}