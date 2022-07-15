using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach(var v in carManager.GetAll())
            {
                Console.WriteLine(v.Description);
            }

        }
    }
}

