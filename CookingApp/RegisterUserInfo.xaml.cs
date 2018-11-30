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
using CookingCurriculum.DataBase;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CookingCurriculum
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterUserInfo : Page
    {
        public List<int> hi;

        public RegisterUserInfo()
        {
            this.InitializeComponent();
        }

        private void RegisterUserButton_Click(object sender, RoutedEventArgs e)
        {

            //add user to DB
            int dbQueryStatus = DBConnection.AddUser(User.name);
            // set the user's name
            User.name = NameTextBox.Text;

            // navigate to the main curriculum page
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
