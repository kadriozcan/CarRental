using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var carDetails = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join col in context.Colors
                                 on c.ColorId equals col.Id
                                 select new CarDetailDto
                                 {
                                     BrandName = b.Name,
                                     ColorName = col.Name,
                                     DailyPrice = c.DailyPrice,
                                     Description = c.Description
                                 
                                 };

                return carDetails.ToList();
            }
        }

    }
}
