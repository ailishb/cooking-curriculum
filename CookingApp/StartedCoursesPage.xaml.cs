using CookingCurriculum.Classes;
using CookingCurriculum.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartedCoursesPage : Page
    {
        public ObservableCollection<string> startedCourses;

        public StartedCoursesPage()
        {
            this.InitializeComponent();

            // alloc memory
            startedCourses = new ObservableCollection<string>();

            // copy in the started courses from the user data
            foreach(var item in User.startedCoursesTitles)
            {
                startedCourses.Add(item);
            }
        }

        private void GoToCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // get course name of the clicked button
            var courseName = (string)((Button)e.OriginalSource).DataContext;

            if (courseName != null)
            {
                // navigate to the View Recipes page passing it the name of the course
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(ViewRecipesPage), courseName);
            }
        }

        private void QuitCourseButton_Click(object sender, RoutedEventArgs e)
        {
            //get course name
            var courseName = (string)((Button)e.OriginalSource).DataContext;

            // remove the course from the database
            int dropStatus = DBConnection.DropCourse(courseName);

            if (dropStatus < 1) { Debug.WriteLine("Error: enrollment failed"); }

            // remove the course from the local user data
            User.startedCoursesTitles.Remove(courseName);

            // if courses is empty, navigate to main page
            if (User.startedCoursesTitles.Count == 0)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MainPage));
            }
        }

        private void BackMainPageButton_Click(object sender, RoutedEventArgs e)
        {
            // navigate to the main curriculum page
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
