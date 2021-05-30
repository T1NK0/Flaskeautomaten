using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Consumer
    {
        public Consumer()
        {

        }

        public void ConsumeSoda()
        {
            while (Thread.CurrentThread.IsAlive) //If a thread is running (alive)
            {
                Drink drink = Buffer.GetDrink(Buffer.SodaBuffer, true);
                if (drink != null)
                {
                    Console.WriteLine(drink.DrinkType + ", " + drink.DrinkSerial + " er blevet pantet.");
                }

                Thread.Sleep(100);
            }
        }

        public void ConsumeBeer()
        {
            while (Thread.CurrentThread.IsAlive) //If a thread is running (alive)
            {
                Drink drink = Buffer.GetDrink(Buffer.BeerBuffer, true);
                if (drink != null)
                {
                    Console.WriteLine(drink.DrinkType + ", " + drink.DrinkSerial + " er blevet pantet.");
                }

                Thread.Sleep(100);
            }
        }
    }
}
