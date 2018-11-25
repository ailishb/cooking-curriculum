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
        public static string server   = "db-instance.cr14309hoksh.us-east-2.rds.amazonaws.com";
        public static string database = "cookingcurriculum";
        public static string username = "admin";
        public static string password = "tinykittens";
        public static string connectionString = String.Format("Server={0}; database={1}; user={2}; password={3}", server, database, username, password);

        // method to return all course descriptions
        public static List<CourseDescription> GetCourseDescriptions()
        {
            const string query = "select name, description, author from course;";

            var courses = new List<CourseDescription>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    courses.Add(new CourseDescription(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
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
    }
}
