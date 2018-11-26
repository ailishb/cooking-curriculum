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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CookingCurriculum
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrentRecipesStepsPage : Page
    {
        public ObservableCollection<Ingredient> ingredients;
        public List<RecipeStep> recipeSteps;
        public string courseName;
        public string recipeName;

          public CurrentRecipesStepsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
               base.OnNavigatedTo(e);

               // get out the course and recipe names
               var data = e.Parameter as List<string>;

               courseName = data[0];
               recipeName = data[1];

               //Get Recipe instructions and steps
               int recipeID = DBConnection.GetRecipeIDFromName(recipeName);
               recipeSteps = DBConnection.GetRecipeSteps(recipeID);

               // set the recipe name on the page
               RecipeName.Text = recipeName;

               // Create a new flip view and add contents
               FlipView CurrentStep = new FlipView();

          }

        private void BackToActiveRecipesButton_Click(object sender, RoutedEventArgs e)
        {
               // create a List to send to the Activ Recipes page
               List<string> sendData = new List<string>();

               sendData.Add(courseName);
               sendData.Add(recipeName);

               // navigate to the new page and send the course and recipe data
               Frame rootFrame = Window.Current.Content as Frame;
               rootFrame.Navigate(typeof(ActiveRecipePage), sendData);
          }

        private void FinishRecipesButton_Click(object sender, RoutedEventArgs e)
        {
               // Add to finished recipe
               // Prompt for rating
        }
     }
}
