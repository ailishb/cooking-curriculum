using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingCurriculum.Classes
{
     public class RecipeStep
     {
          public int stepNumber;
          public string name;
          public string instructions;
          public string img_url;

          public RecipeStep(int RecipeStepNumber, string RecipeName, string RecipeInstructions, string RecipeImg_URL)
          {
               stepNumber = RecipeStepNumber;
               name = RecipeName;
               instructions = RecipeInstructions;
               img_url = RecipeImg_URL;
          }
     }
}
