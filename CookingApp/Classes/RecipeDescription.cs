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

        // temporary image path
        public string m_imagePath;


        public RecipeDescription(int recipeID, string name, string description, int difficultyLevel, string author)
        {
            m_recipeID = recipeID;
            m_name = name;
            m_description = description;
            m_difficultyLevel = difficultyLevel;
            m_author = author;

            // assign appropriate image path
            switch(m_name.ToLower())
            {
                case "deviled eggs":
                    m_imagePath = "Images/deviledeggs.jpeg";
                    break;

                case "poached eggs":
                    m_imagePath = "Images/poachedeggs.jpg";
                    break;

                case "scottish eggs":
                    m_imagePath = "Images/scottisheggs.jpg";
                    break;

                case "scrambled eggs":
                    m_imagePath = "Images/scrambledeggs.jpg";
                    break;

                default:
                    m_imagePath = "Images/scrambledeggs.jpg";
                    break;
            }
        }
    }
}
