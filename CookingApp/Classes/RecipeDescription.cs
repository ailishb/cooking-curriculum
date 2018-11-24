using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingCurriculum.Classes
{
    public class RecipeDescription
    {
        public string m_title;
        public string m_image;
        public string m_recipeDescription;

        public RecipeDescription(string title, string image, string description)
        {
            m_title = title;
            m_image = image;
            m_recipeDescription = description;
        }
    }
}
