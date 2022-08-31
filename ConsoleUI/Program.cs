using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();

            //BrandDetails();

            //ColorDetails();

            //User user1 = new User { FirstName = "Ali", LastName = "Veli", Email = "aveli@gmail.com", Password = "aveli123" };
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(user1);

            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            ////customerManager.Add(new Customer { CompanyName = "Kardesler AS", UserId = 2 });
            //customerManager.Delete(new Customer { Id = 1002 });


            Rental rental1 = new Rental { CarId = 1, CustomerId=1, RentDate=DateTime.Now };

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental1);

            

        }

        private static void ColorDetails()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var i in colorManager.GetAll().Data)
            {
                Console.WriteLine(i.Name);
            }
        }

        private static void BrandDetails()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var v in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(v.BrandName +  v.ColorName+ v.DailyPrice);
            }
        }
    }
}

