using System;
using System.Collections.Generic;
using System.Text;

namespace Flaskeautomaten
{
    class Drink
    {
        public enum TypeOfDrink 
        {
            Soda,
            Beer
        };

        private TypeOfDrink drinkType;

        public TypeOfDrink DrinkType
        {
            get { return drinkType; }
            set { drinkType = value; }
        }

        private int drinkSerial;

        public int DrinkSerial
        {
            get { return drinkSerial; }
            set { drinkSerial = value; }
        }


        public Drink()
        {

        }

        public Drink(TypeOfDrink drinkType, int drinkSerial)
        {
            this.DrinkType = drinkType;
            this.DrinkSerial = drinkSerial;
        }
    }
}
