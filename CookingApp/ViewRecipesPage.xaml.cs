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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // get the course name that was passed as a parameter
            var courseName = (string)e.Parameter;

            // make a call to a database to populate the recipe contents
            // EDIT - for now just populate with test data
            populateRecipeData();

            CourseName.Text = courseName;
        }

        private void populateRecipeData()
        {
            recipeDescriptions.Add(new RecipeDescription("Recipe 1", "", "Description for Recipe 1"));
            currentRecipe = 1;
        }

        private void LastRecipeInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentRecipe > 1)
            {
                --currentRecipe;
                recipeDescriptions.Clear();
                recipeDescriptions.Add(new RecipeDescription(String.Format("Recipe {0}", currentRecipe),
                                                             "",
                                                             String.Format("Description for Recipe {0}", currentRecipe)));
            }
        }

        private void NextRecipeInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe < 5)
            {
                ++currentRecipe;
                recipeDescriptions.Clear();
                recipeDescriptions.Add(new RecipeDescription(String.Format("Recipe {0}", currentRecipe),
                                                             "",
                                                             String.Format("Description for Recipe {0}", currentRecipe)));
            }
        }

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
            string recipeName = recipeDescriptions[0].m_title;

            // create a List to send to the Activ Recipes page
            List<string> sendData = new List<string>();

            sendData.Add(courseName);
            sendData.Add(recipeName);

            // navigate to the new page and send the course and recipe data
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ActiveRecipePage), sendData);
        }
    }
}
