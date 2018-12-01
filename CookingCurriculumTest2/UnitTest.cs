
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookingCurriculum;

namespace CookingCurriculumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetCourseDescriptions()
        {
            var testCourseList = CookingCurriculum.DataBase.DBConnection.GetCourseDescriptions();
            CollectionAssert.AllItemsAreNotNull(testCourseList);
        }

        [TestMethod]
        public void TestGetRecipeDescriptions()
        {
            var testRecipeList = CookingCurriculum.DataBase.DBConnection.GetRecipeDescriptions(1);
            CollectionAssert.AllItemsAreNotNull(testRecipeList);
        }

        [TestMethod]
        public void TestGetIngredientsByRecipeID()
        {
            var testIngredientList = CookingCurriculum.DataBase.DBConnection.GetIngredientsByRecipeID(1);
            CollectionAssert.AllItemsAreNotNull(testIngredientList);
        }

        [TestMethod]
        public void TestGetRecipeSteps()
        {
            var testStepList = CookingCurriculum.DataBase.DBConnection.GetRecipeSteps(1);
            CollectionAssert.AllItemsAreNotNull(testStepList);
        }

        [TestMethod]
        //Debug test; throwing error
        public void TestGetRecipeIDFromName()
        {
            var methodValue = CookingCurriculum.DataBase.DBConnection.GetRecipeIDFromName("Poached Eggs");
            var testRecipeID = 2;
            Assert.Equals(methodValue, testRecipeID);
        }

    }
}

