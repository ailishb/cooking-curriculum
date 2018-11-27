using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookingCurriculum.Classes;
using MySql.Data.MySqlClient;

namespace CookingCurriculum.DataBase
{
    public static class DBConnection
    {
        /// creating database connection string
        public static string server = "db-instance.cr14309hoksh.us-east-2.rds.amazonaws.com";
        public static string database = "cookingcurriculum";
        public static string username = "admin";
        public static string password = "tinykittens";
        public static string connectionString = String.Format("Server={0}; database={1}; user={2}; password={3}", server, database, username, password);

        // method to return all course descriptions
        public static List<CourseDescription> GetCourseDescriptions()
        {
            const string query = "select name, description, author, courseID from course;";

            var courses = new List<CourseDescription>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    courses.Add(new CourseDescription(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                                }
                            }
                        }
                    }
                }
                return courses;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        // method to return all recipe descriptions in a specified course
        public static List<RecipeDescription> GetRecipeDescriptions(int courseID)
        {
            const string query = "select recipeID, name, description, difficultylevel, author from recipe;";

            var courses = new List<RecipeDescription>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    courses.Add(new RecipeDescription(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4)));
                                }
                            }
                        }
                    }
                }
                return courses;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        public static List<Ingredient> GetIngredientsByRecipeID(int recipeID)
        {
            string query = String.Format("select description, amount, unit from recipeIngredients where recipeID = {0};", recipeID);
            var res = new List<Ingredient>();
            try
            {
                // send query
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    res.Add(new Ingredient(reader.GetString(0), (double)reader.GetInt32(1), reader.GetString(2)));
                                }
                            }
                        }
                    }
                }
                return res;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        // Returns a List of type Recipe Steps
        public static List<RecipeStep> GetRecipeSteps(int recipeID)
        {
            string query = String.Format("select stepOrder, name, instructions, img_url  from recipeSteps where recipeID = {0};", recipeID);

            var recipeSteps = new List<RecipeStep>();
            try
            {
                // send query
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recipeSteps.Add(new RecipeStep(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                                }
                            }
                        }
                    }
                }
                return recipeSteps;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        public static int GetRecipeIDFromName(string recipeName)
        {
            string query = String.Format("select recipeID from recipe where name = \"{0}\";", recipeName);
            try
            {
                // send query
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    return reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return -1;
        }

        //query to enroll a user in a selected course
        public static int EnrollUserInCourse(string uName, string cName)
        {   //get userID and courseID from names
            int userID = GetUserIDFromName(uName);
            int courseID = GetCourseIDFromName(cName);

            if (userID >= 0 && courseID >= 0)
            {
                //enroll user in course (what is 'status' column for?)
                string query = String.Format("INSERT INTO userCourseEnrollment (userID, courseID, status) VALUES (\'{0}\', \'{0}\', 'started');", userID, courseID);
                try
                {
                    // send query
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                return 0;

                            }
                        }
                    }
                }
                catch (Exception eSql)
                {
                    Debug.WriteLine("Exception: " + eSql.Message);
                }
                return -1;
            }
            else
            {
                Debug.WriteLine("Error: bad data returned for " + uName, " or ", cName);
                return -1;
            }
        }

        private static int GetUserIDFromName(string courseName)
        {
            string query = String.Format("select courseID from course where name = \"{0}\";", courseName);
            try
            {
                // send query
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    return reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return -1;
        }
        private static int GetCourseIDFromName(string userName)
        {
            string query = String.Format("select userID from users where name = \"{0}\";", userName);
            try
            {
                // send query
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    return reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return -1;
        }
    }
}

    
