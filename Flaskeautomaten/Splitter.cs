using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Splitter
    {
        public Splitter()
        {

        }

        public void SplitDrinks()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Monitor.Enter(Buffer.SplitterBuffer);
                while (Buffer.AmountInArray(Buffer.SplitterBuffer) == 0)
                {
                    Monitor.Wait(Buffer.SplitterBuffer);
                }
                Monitor.Exit(Buffer.SplitterBuffer);

                Drink drink = Buffer.GetDrink(Buffer.SplitterBuffer, true); //This is the drink we have gotten from GetDrink in buffer. Can work with whatever buffer we want to get Drink from.
                if (drink != null) //Check if we have gotten a drink, else it has no drinks left in the buffer (on the conveyor belt)
                {
                    if (drink.DrinkType == Drink.TypeOfDrink.Soda) //If the drink is a soda, check if theres room in soda buffer.
                    {
                        if (Buffer.AddDrink(Buffer.SodaBuffer, drink) == false) //If false, no room. If true there is room for sodas and add the drink to the buffer.
                        {
                            //if false (no room) writes out "No more space".
                            Buffer.AddDrink(Buffer.SplitterBuffer, drink); //Adds the soda in the buffer if there is no space for sodas, since we otherwise would delete the item.
                        }
                        else
                        {
                            Console.WriteLine(drink.DrinkType + ", " + drink.DrinkSerial + " added to sodabuffer.");
                        }
                    }
                    else if (drink.DrinkType == Drink.TypeOfDrink.Beer) //Else if it is beer, check if theres room in beer buffer.
                    {
                        if (Buffer.AddDrink(Buffer.BeerBuffer, drink) == false) //IF false, no room. If true there is room for beers and add the drink to the buffer.
                        {
                            Buffer.AddDrink(Buffer.SplitterBuffer, drink); //Adds the beers in the buffer if there is no space for beers, since we otherwise would delete the item.
                        }
                        else
                        {
                            Console.WriteLine(drink.DrinkType + ", " + drink.DrinkSerial + " added to BeerBuffer.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no more drinks in splitterbuffer");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
