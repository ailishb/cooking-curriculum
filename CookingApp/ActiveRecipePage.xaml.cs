﻿using CookingCurriculum.Classes;
using CookingCurriculum.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CookingCurriculum
{
    public sealed partial class ActiveRecipePage : Page
    {
        // hold data for the grid view
        public ObservableCollection<Ingredient> ingredients;
        public ObservableCollection<RecipeStep> instructions;
        public Recipe recipe;
        public string courseName;
        public string recipeName;

        public ActiveRecipePage()
        {
            this.InitializeComponent();

            ingredients = new ObservableCollection<Ingredient>();
            instructions = new ObservableCollection<RecipeStep>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // get out the course and recipe names
            var data = e.Parameter as List<string>;

            courseName = data[0];
            recipeName = data[1];

            // set the recipe name on the page
            RecipeName.Text = recipeName;

            // get all recipe data
            GetRecipeData(courseName, recipeName);
        }

        private void GetRecipeData(string courseName, string recipeName)
        {


            // This should makes calls to the DB - for now, just generate random data
            int recipeID = DBConnection.GetRecipeIDFromName(recipeName);
            List<Ingredient> ingredientsListBuffer = DBConnection.GetIngredientsByRecipeID(recipeID);
            List<Ingredient> ingredientsList = new List<Ingredient>();
            foreach (var item in ingredientsListBuffer)
            {
                 ingredientsList.Add(item);
            }

            List<RecipeStep> instructionsListBuffer = DBConnection.GetRecipeSteps(recipeID);
            List<RecipeStep> instructionsList = new List<RecipeStep>();
            foreach (var item in instructionsListBuffer)
            {
                 instructionsList.Add(item);
            }

            recipe = new Recipe(recipeName, ingredientsList, instructionsList);

            // add the list of ingredients to the observable collection
            foreach(var item in recipe.recipeIngredients)
            {
                 ingredients.Add(item);
            }

            // add the list of instructions to the observation collection
            foreach (var item in recipe.recipeInstructions)
            {
                 instructions.Add(item);
            }

            ExperienceLevelTextBlock.Text = " Beginner";
        }

        private void IngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsDropDown.Visibility == Visibility.Visible)
                IngredientsDropDown.Visibility = Visibility.Collapsed;
            else
            {
                IngredientsDropDown.Visibility = Visibility.Visible;
                ToolsDropDown.Visibility = Visibility.Collapsed;
                TimeToCookDropDown.Visibility = Visibility.Collapsed;
                InstructionsDropDown.Visibility = Visibility.Collapsed;
            }
        }

        private void ToolsButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToolsDropDown.Visibility == Visibility.Visible)
                ToolsDropDown.Visibility = Visibility.Collapsed;
            else
            {
                IngredientsDropDown.Visibility = Visibility.Collapsed;
                ToolsDropDown.Visibility = Visibility.Visible;
                TimeToCookDropDown.Visibility = Visibility.Collapsed;
                InstructionsDropDown.Visibility = Visibility.Collapsed;
            }
        }

        private void TimeToCookButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimeToCookDropDown.Visibility == Visibility.Visible)
                TimeToCookDropDown.Visibility = Visibility.Collapsed;
            else
            {
                IngredientsDropDown.Visibility = Visibility.Collapsed;
                ToolsDropDown.Visibility = Visibility.Collapsed;
                TimeToCookDropDown.Visibility = Visibility.Visible;
                InstructionsDropDown.Visibility = Visibility.Collapsed;
            }
        }

        private void InstructionsButton_Click(object sender, RoutedEventArgs e)
        {
            if (InstructionsDropDown.Visibility == Visibility.Visible)
                InstructionsDropDown.Visibility = Visibility.Collapsed;
            else
            {
                 IngredientsDropDown.Visibility = Visibility.Collapsed;
                 ToolsDropDown.Visibility = Visibility.Collapsed;
                 TimeToCookDropDown.Visibility = Visibility.Collapsed;
                 InstructionsDropDown.Visibility = Visibility.Visible;
            }
        }

          private void BackToRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // navigate to the View Recipes page passing it the name of the course
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ViewRecipesPage), courseName);
        }

        private void BeginRecipesButton_Click(object sender, RoutedEventArgs e)
        {
               // create a List to send to the Activ Recipes page
               List<string> sendData = new List<string>();

               sendData.Add(courseName);
               sendData.Add(recipeName);
               // navigate to the CurrentRecipesStepsPage page
               Frame rootFrame = Window.Current.Content as Frame;
               rootFrame.Navigate(typeof(CurrentRecipesStepsPage), sendData);
        }
    }
}
