using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent appDbContent;
        public CarRepository(AppDbContent appDbContent)=>this.appDbContent=appDbContent;
        public IEnumerable<Car> Cars => appDbContent.Car.Include(c=>c.Category);

        public IEnumerable<Car> getFavCars => appDbContent.Car.Where(p=>p.isFavourite).Include(c=>c.Category);
        public Car getObjectCar(int carId) => appDbContent.Car.FirstOrDefault(p=>p.id==carId);
    }
}