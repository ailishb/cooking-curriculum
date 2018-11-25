using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingCurriculum.Classes
{
    public class Ingredient
    {
        public string ingredientName;
        public double ingredientQuantity;
        public string ingredientMeasurementUnit;

        public Ingredient(string name, double quantity, string measurementUnit)
        {
            ingredientName = name;
            ingredientQuantity = quantity;
            ingredientMeasurementUnit = measurementUnit;
        }
    }
}
