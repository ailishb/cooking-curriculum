
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookingCurriculum;

namespace CookingCurriculumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testCourseList = CookingCurriculum.DataBase.DBConnection.GetCourseDescriptions();
            CollectionAssert.AllItemsAreNotNull(testCourseList);
        }
    }
}

