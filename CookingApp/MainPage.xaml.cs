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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CookingCurriculum
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // This function is called when the My Courses button is clicked
        private void MyCourses_Click(object sender, RoutedEventArgs e)
        {
            // If the user has not started any courses, then open the Popup window
            if (User.startedCoursesTitles.Count == 0)
            {
                if (!StandardPopup.IsOpen)
                    StandardPopup.IsOpen = true;
            }
            else // the user has started at least one course so show the started courses
            {
                // navigate to the started courses page
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(StartedCoursesPage));
            }
        }

        // This function is called when the Course Catalog button is clicked
        private void CourseCatalog_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ViewCoursesPage));
        }

        // This function is called when the close button in the pop up window is clicked
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        /* This function is used during tests to add a course to the users started courses list
        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            User.startedCourses.Add(course);
        }
        */
    }
}
