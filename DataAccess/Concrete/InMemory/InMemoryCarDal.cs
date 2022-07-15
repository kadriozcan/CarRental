using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 3, ModelYear = 2015, DailyPrice = 550, Description = "D segment" },
                new Car{Id = 2, BrandId = 3, ColorId = 5, ModelYear = 2019, DailyPrice = 880, Description = "E segment" }
            };
    
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToBeDeleted = _cars.FirstOrDefault(c => car.Id == c.Id);
            car = carToBeDeleted;
            _cars.Remove(car);

        }
        
        public void Update(Car car)
        {
            Car carToBeUpdated = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToBeUpdated.DailyPrice = car.DailyPrice;
            carToBeUpdated.ModelYear = car.ModelYear;
            carToBeUpdated.BrandId = car.BrandId;
            carToBeUpdated.ColorId = car.ColorId;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car car = _cars.FirstOrDefault(c=> c.Id == id);
            return car;
        }


    }
}
