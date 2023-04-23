using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.MaxPrice = 5000;
            Car[] cars = new Car[]
            {
                new Car{ Brand="Audi", Model="A5", Price=15_000 },
                new Car{ Brand="BMW", Model="X3", Price=4_000 },
                new Car{ Brand="Opel", Model="Astra", Price=3_000 },
            };
            Predicate<Car> myPredicateDelegate = car.ReturnCheaperCar;
            Car foundCar = Array.Find(cars, myPredicateDelegate);
            if (foundCar!=null)
            {
                Console.WriteLine($"{foundCar.Brand}, {foundCar.Model}, {foundCar.Price}");
            }


        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public Car()
        {

        }

        public double MaxPrice { get; set; }

        public bool ReturnCheaperCar(Car car)
        {
            return car.Price < MaxPrice;
        }

        public int CompareNames(Car car1, Car car2)
        {
            string s1 = $"{car1.Brand}{car1.Model}";
            string s2 = $"{car2.Brand}{car2.Model}";
            return s1.CompareTo(s2);
        }
    }

}
