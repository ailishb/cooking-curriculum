﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookingCurriculum.Classes;

namespace CookingCurriculum.Classes
{
    public class Recipe
    {
        public string           recipeName;
        public List<Ingredient> recipeIngredients;
        public List<RecipeStep>   recipeInstructions;

        public Recipe()
        {
        }

        public Recipe(string name, List<Ingredient> ingredients, List<RecipeStep> instructions)
        {
            recipeName = name;
            recipeIngredients = ingredients;
            recipeInstructions = instructions;
        }
    }
}
