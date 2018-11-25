using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingCurriculum.Classes
{
    public class RecipeDescription
    {
        public int m_recipeID;
        public string m_name;
        public string m_description;
        public int m_difficultyLevel;
        public string m_author;


        public RecipeDescription(int recipeID, string name, string description, int difficultyLevel, string author)
        {
            m_recipeID = recipeID;
            m_name = name;
            m_description = description;
            m_difficultyLevel = difficultyLevel;
            m_author = author;
        }
    }
}
