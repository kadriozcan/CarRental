using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);

        List<CarDetailDto> GetCarDetails();

        List<Car> GetCarsByBrandId(int brandId);

        List<Car> GetCarsByColorId(int colorId);
    }
}
