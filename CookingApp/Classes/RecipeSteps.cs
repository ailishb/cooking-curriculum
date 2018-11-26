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
               // img_url = RecipeImg_URL;          <-- Temporary Fix, see below


               // temporary Image Paths
                switch(stepNumber)
                {
                    case 1:
                        img_url = "Images/crackingegg.jpg";
                        break;

                    case 2:
                        img_url = "Images/turnonstove.jpg";
                        break;

                    case 3:
                        img_url = "Images/eggsonplate.jpg";
                        break;

                    default:
                        img_url = "";
                        break;
                }
          }
     }
}
