using System;

namespace _08_MultiInterfaceInheritance
{
    interface IRunnable
    {
        void Run();
    }
    interface IFlyable
    {
        void Fly();
    }
    class Plane : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("날아라아");
        }
    }
    class Car
    {
        public void Run()
        {
            Console.WriteLine("달려라아");
        }
    }
    class FlyingCar : IRunnable, IFlyable
    {
        public void Run()
        {
            Console.WriteLine("Run! Run!");
        }
        public void Fly()
        {
            Console.WriteLine("Fly! Fly!");
        }
    }
    class MyVehicle
    {
        public Car car;
        public Plane plane;
        public MyVehicle()
        {
            car = new Car();
            plane = new Plane();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            IRunnable runnable = car as IRunnable;
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();

            MyVehicle myVehicle = new MyVehicle();
            myVehicle.car.Run();
            myVehicle.plane.Fly();
        }
    }
}
