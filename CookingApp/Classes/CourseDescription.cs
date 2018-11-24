using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CookingCurriculum.Classes
{
    public class CourseDescription
    {
        public string m_title;
        public string m_description;
        public string m_author;

        //build course description collections with call to DB
        public ObservableCollection<CourseDescription> GetCourseDescription(string connectionString)
        {
            const string GetCousrseDescriptionQuery = "select, name, description, author from courses";

            var courses = new ObservableCollection<CourseDescription>();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetCousrseDescriptionQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var courseD = new CourseDescription();
                                    courseD.m_title = reader.GetString(0);
                                    courseD.m_description = reader.GetString(1);
                                    courseD.m_author = reader.GetString(2);
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
        /*old constructor
        public CourseDescription(string title, string description)
        {
            m_title = title;
            m_description = description;
        }
        */
    }
}
