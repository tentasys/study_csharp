﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_AccessModifier
{
    class WaterHeater
    {
        protected int temperature;    
        public void SetTemperature(int temperature)
        {
            if (temperature < -5 || temperature > 42)
                throw new Exception("Out of temperature range");
            this.temperature = temperature;
        }
        internal void TrunOnWater()
        {
            Console.WriteLine($"Trun on water : {temperature}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TrunOnWater();

                heater.SetTemperature(-2);
                heater.TrunOnWater();

                heater.SetTemperature(50);
                heater.TrunOnWater();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
