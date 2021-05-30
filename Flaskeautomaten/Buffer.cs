using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    static class Buffer
    {
        static Drink[] splitterBuffer = new Drink[5]; //Private by default
        static public Drink[] SplitterBuffer
        {
            get { return splitterBuffer; }
            set { splitterBuffer = value; }
        }

        static Drink[] sodaBuffer = new Drink[5]; //Private by default
        static public Drink[] SodaBuffer
        {
            get { return sodaBuffer; }
            set { sodaBuffer = value; }
        }

        static Drink[] beerBuffer = new Drink[5]; //Private by default
        static public Drink[] BeerBuffer
        {
            get { return beerBuffer; }
            set { beerBuffer = value; }
        }

        public static int AmountInArray(Drink[] drinks)
        {
            int AmountInArray = 0;
            for (int i = 0; i < drinks.Length; i++)
            {
                if (drinks[i] != null)
                {
                    AmountInArray += 1;
                }
            }
            return AmountInArray;
        }

        public static Drink GetDrink(Drink[] drinks, bool delete)
        {
            if (Monitor.TryEnter(drinks))
            {
                for (int i = 0; i < drinks.Length; i++)
                {
                    if (drinks[i] != null)
                    {
                        Drink d = drinks[i];
                        if (delete == true) //Bool value set to true if we want to delete the item, and set to false if we want to check if there is an item in the array.
                        {   //Since we are consuming the item se set it to true, so we set the i of drinks to null.
                            drinks[i] = null;
                            Monitor.Pulse(drinks);
                        }
                        Monitor.Exit(drinks);
                        return d; //Returns the drink we have "found" in our splitter array.
                    }
                }
                Monitor.Exit(drinks);
            }
            return null; //Returns nothing since we have nothing in the array. Error message in splitter.
        }

        public static bool AddDrink(Drink[] drinks, Drink drink)
        {
            if (Monitor.TryEnter(drinks))
            {
                for (int i = 0; i < drinks.Length; i++)
                {
                    if (drinks[i] == null)
                    {
                        drinks[i] = drink; //We get our drink from our "Get Drink".

                        Monitor.Pulse(drinks);
                        Monitor.Exit(drinks); //If we dont have exit here, we wont be able to exit if it has an empty spot..
                        return true; //Returns true if we have added a drink (hence the bool)
                    }
                }
                Monitor.Exit(drinks);
            }
            return false; //Returns false, if we have not added a drink.
        }
    }
}
