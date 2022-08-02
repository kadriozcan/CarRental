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
            CarDetails();

            //BrandDetails();

            //ColorDetails();

        }

        private static void ColorDetails()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var i in colorManager.GetAll())
            {
                Console.WriteLine(i.Name);
            }
        }

        private static void BrandDetails()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var v in carManager.GetCarDetails())
            {
                Console.WriteLine(v.BrandName +  v.ColorName+ v.DailyPrice);
            }
        }
    }
}

