using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using CookingCurriculum.Classes;
using CookingCurriculum.DataBase;
using System.Collections.ObjectModel;

namespace CookingCurriculum
{
    public sealed partial class ViewRecipesPage : Page
    {
        // hold recipe descriptions for the list view
        public ObservableCollection<RecipeDescription> recipeDescriptions;
        public int currentRecipe;

        // public Recipe recipe;

        public ViewRecipesPage()
        {
            this.InitializeComponent();

            // allocate memory for the recipes
            recipeDescriptions = new ObservableCollection<RecipeDescription>();

            // allocate memory for the recipe
            // recipe = new Recipe();

            //dummy course ID, need to pass in
            var courseID = 1;

            // Retrieve the recipe data from the database
            var recipeList = DBConnection.GetRecipeDescriptions(courseID);
            foreach (var item in recipeList)
            {
                recipeDescriptions.Add(item); // must add the item so the change registers with the system
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // get the course name that was passed as a parameter
            // how to pass recipe ID instead?
            var courseName = (string)e.Parameter;
            //var courseID = 1;
            // make a call to a database to populate the recipe contents
            // EDIT - for now just populate with test data
            // populateRecipeData(courseID);

            CourseName.Text = courseName;
        }

        //changed to just a list view instead of carosel for recipes
        /*
        private void populateRecipeData(int courseID)
        {
            recipeDescriptions.Add(new RecipeDescription(1, "Recipe 1", "Description for Recipe 1", 1, "Someone"));
            currentRecipe = 1;
        }

        private void LastRecipeInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentRecipe > 1)
            {
                --currentRecipe;
                recipeDescriptions.Clear();
                recipeDescriptions.Add(new RecipeDescription(1, String.Format("Recipe {0}", currentRecipe),
                                                             String.Format("Description for Recipe {0}", currentRecipe),
                                                             1, String.Format("Someone")));
            }
        }

        private void NextRecipeInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe < 5)
            {
                ++currentRecipe;
                recipeDescriptions.Clear();
                recipeDescriptions.Add(new RecipeDescription(1, String.Format("Recipe {0}", currentRecipe),
                                                             String.Format("Description for Recipe {0}", currentRecipe),
                                                             1, String.Format("Someone")));
            }
        }
        */

        private void BackToCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ViewCoursesPage));
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            // Need to implement preview function
        }

        private void StartRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // get the course name
            string courseName = CourseName.Text;

            // get the recipe name in the course
            string recipeName = recipeDescriptions[0].m_name;

            // create a List to send to the Active Recipes page
            List<string> sendData = new List<string>();

            sendData.Add(courseName);
            sendData.Add(recipeName);

            // navigate to the new page and send the course and recipe data
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ActiveRecipePage), sendData);
        }
    }
}
