﻿using System;
using System.Linq;

namespace _15_Ex2
{
    class Car
    {
        public int Cost { get; set; }
        public int MaxSpeed { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars =
            {
                new Car(){Cost = 56, MaxSpeed = 120},
                new Car(){Cost = 70, MaxSpeed = 150},
                new Car(){Cost = 45, MaxSpeed = 180},
                new Car(){Cost = 32, MaxSpeed = 200},
                new Car(){Cost = 82, MaxSpeed = 280}
            };

            var selected = from car in cars
                           where car.Cost < 60
                           orderby car.Cost
                           select car;

            foreach(var car in selected)
            {
                Console.WriteLine($"Cost : {car.Cost}, MaxSpeed : {car.MaxSpeed}");
            }
        }
    }
}
