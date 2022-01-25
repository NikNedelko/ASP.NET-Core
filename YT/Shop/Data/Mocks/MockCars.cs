using System.Collections.Generic;
using System.Linq;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks
{
     class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();// указание категории для объекта
        public IEnumerable<Car> Cars { 
            get
            {
                return new List<Car>//делаем список из всех товаров/ каждый элемент имеет тип данных Car
                {
                    new Car{name = "Tesla Model S",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Красивый, быстрый и очень тихиц автомобиль Теслы",
                        img="/img/35a8fa2163d04f4503a77a8ef2d7b5483737259a.jpg.webp",
                        price=45000,
                        isFavourite=true,
                        available=true,
                        Category =_categoryCars.AllCategories.First()},

                    new Car{name = "Ford Fiesta",
                        shortDesc = "тихий и спокойный ",
                        longDesc = "Умный автомобиль для городской жизни",
                        img="/img/cattouchret.jpeg",
                        price=11000,
                        isFavourite=false,
                        available=true,
                        Category =_categoryCars.AllCategories.Last()},

                    new Car{name = "BMW M3",
                        shortDesc = "Дерзкий и стильный ",
                        longDesc = "Умный автомобиль для городской жизни",
                        img="/img/bmw-3-series-sedan-m-automobiles-sp-desktop.jpg",
                        price=65000,
                        isFavourite=true,
                        available=true,
                        Category =_categoryCars.AllCategories.Last()},

                    new Car{name = "Mercedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img="/img/backgroundimage.MQ6.12.20210630223843.jpeg",
                        price=40000,
                        isFavourite=false,
                        available=false,
                        Category =_categoryCars.AllCategories.Last()},

                    new Car{name = "Nissan Leaf",
                        shortDesc = "Бесшумный и экономный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img="/img/nissan_leaf_877464.jpg",
                        price=14000,
                        isFavourite=true,
                        available=true,
                        Category =_categoryCars.AllCategories.First()}
                };
            }
        }
        public IEnumerable<Car> getFavCars { get ; set ; }

        public Car getObjectCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}