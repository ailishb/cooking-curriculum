﻿using System;
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
        public int m_courseID;

        public CourseDescription(string title = "", string description = "", string author = "", int courseID = 0)
        {
            m_title = title;
            m_description = description;
            m_author = author;
            m_courseID = courseID;
        }
        
    }
}
