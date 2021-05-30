using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Producer
    {
        Random random = new Random();
        public Producer()
        {

        }

        public void CreateDrink()
        {
            int createRandomDrinkType;
            int drinkSerialNumber = 0;

            while (Thread.CurrentThread.IsAlive) //If a thread is running (alive)
            {
                Monitor.Enter(Buffer.SplitterBuffer);
                while (Buffer.AmountInArray(Buffer.SplitterBuffer) == 5)
                {
                    Monitor.Wait(Buffer.SplitterBuffer);
                }
                Monitor.Exit(Buffer.SplitterBuffer);
                
                //while (Buffer.GetDrink(Buffer.SplitterBuffer, false) == null) //Checks if it has an empty item, and says we don't want to delete the item (false)
                //{
                createRandomDrinkType = random.Next(0, 2);
                if (createRandomDrinkType == 0)
                {
                    Drink drink = new Drink(Drink.TypeOfDrink.Soda, drinkSerialNumber); //Creates our drink
                    drinkSerialNumber += 1;
                    if (Buffer.AddDrink(Buffer.SplitterBuffer, drink)) //Adds our soda to our sodabuffer
                    {
                        Console.WriteLine("Drink:" + drink.DrinkType + ", " + drink.DrinkSerial + " has been inserted into the machine");
                    }
                }
                else if (createRandomDrinkType == 1)
                {
                    Drink drink = new Drink(Drink.TypeOfDrink.Beer, drinkSerialNumber);
                    drinkSerialNumber += 1;
                    if (Buffer.AddDrink(Buffer.SplitterBuffer, drink)) //Adds our soda to our sodabuffer
                    {
                        Console.WriteLine("Drink:" + drink.DrinkType + ", " + drink.DrinkSerial + " has been inserted into the machine");
                    }
                }
                //}
            }
        }
    }
}
