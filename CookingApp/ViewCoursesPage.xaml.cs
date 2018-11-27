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
    public sealed partial class ViewCoursesPage : Page
    {
        // hold course descriptions for the list view
        public ObservableCollection<CourseDescription> courseDescriptions;
        CourseDescription courses = new CourseDescription();

        public ViewCoursesPage()
        {
            this.InitializeComponent();

            // allocate memory for courseDescriptions
            courseDescriptions = new ObservableCollection<CourseDescription>();

            // Retrieve the courses data from the database
            var courseList = DBConnection.GetCourseDescriptions();
            foreach(var item in courseList)
            {
                courseDescriptions.Add(item); // must add the item so the change registers with the system
            }
        }

        private void CourseDescriptionListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // iterate through each course description in the list view
            foreach (var item in CourseDescriptionListView.Items)
            {
                // create a list view item from the current iterated item
                var container = (ListViewItem)CourseDescriptionListView.ContainerFromItem(item);

                if(container != null)
                {
                    // isolate the description grid in the list view item
                    var descriptionBox = (container.ContentTemplateRoot as FrameworkElement)?.FindName("DescriptionGrid") as FrameworkElement;

                    if(descriptionBox != null)
                    {
                        // reverse the visibility of the item
                        descriptionBox.Visibility = e.ClickedItem == item ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            }
        }

        private void BackMainPageButton_Click(object sender, RoutedEventArgs e)
        {
               // navigate to the main curriculum page
               Frame rootFrame = Window.Current.Content as Frame;
               rootFrame.Navigate(typeof(MainPage));
          }

        // navigate to the course and add it to the started courses page
        private void BeginCourseButton_Click(object sender, RoutedEventArgs e)
        {
            var courseName = ((CourseDescription)((Button)e.OriginalSource).DataContext).m_title;

            if (courseName != null)
            {
                int status = DBConnection.EnrollUserInCourse(User.name, courseName);
                User.startedCoursesTitles.Add(courseName); // this needs to be changed to be a call to a database

                // navigate to the View Recipes page passing it the name of the course
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(ViewRecipesPage), courseName);
            }
        }

        private void PreviewCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // should add a pop up for the preview
        }
     }
}
