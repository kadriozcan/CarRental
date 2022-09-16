using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var rentalDetails = from r in context.Rentals
                                    join c in context.Cars
                                    on r.CarId equals c.Id
                                    join b in context.Brands
                                    on c.BrandId equals b.Id
                                    join cus in context.Customers
                                    on r.CustomerId equals cus.Id
                                    join u in context.Users
                                    on cus.UserId equals u.Id
                                    select new RentalDetailDto
                                    {
                                        BrandName = b.Name,
                                        FirstName = u.FirstName,
                                        LastName = u.LastName
                                    };

                return rentalDetails.ToList();
            }
            
        }
    }
}
