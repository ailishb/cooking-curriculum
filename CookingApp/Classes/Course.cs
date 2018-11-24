using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookingCurriculum.Classes;

namespace CookingCurriculum
{
    public class Course
    {
        public string       courseName;
        public List<Recipe> courseRecipes;

        public Course(string name, List<Recipe> recipes)
        {
            courseName = name;
            courseRecipes = recipes;
        }
    }
}
