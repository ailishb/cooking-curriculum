using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookingCurriculum.Classes;

namespace CookingCurriculum
{
    public static class User
    {
        public static string name;
        // can also later add email, skills, preferences, etc

        public static List<string> startedCoursesTitles;

        // call this function from App.xaml.cs when the app first starts
        // --- EDIT THIS ---  check if the user exists in the database
        public static void generateUser()
        {
            startedCoursesTitles = new List<string>();
        }
    }
}
