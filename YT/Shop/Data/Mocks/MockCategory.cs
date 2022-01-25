using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
namespace Shop.Data.Mocks
{
     class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>{
                    new Category{categoryName="Электромобили", desc="Современый вид транспорта"},
                    new Category{categoryName="Классические автомобили", desc="Автомобили с двигателем внутреннего згорания"}

                };
            }
        }
    }
}