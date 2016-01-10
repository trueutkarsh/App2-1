using App2.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NextPage : Page
    {
        public static float height;
        public static float weight;
        public static float age;
        public bool? val1, val2;
        public static int s1;
        public static bool isMale;
        public NextPage()
        {
            this.InitializeComponent();
            grid1.Background = StartPage.grid2.Background;
            title1.Foreground = StartPage.title1.Foreground;
            titleshadow1.Foreground = StartPage.titleshadow1.Foreground;
            Sex1.Foreground = StartPage.block1.Foreground;
            Age1.Foreground = StartPage.block1.Foreground;
            Height1.Foreground = StartPage.block1.Foreground;
            Weight1.Foreground = StartPage.block1.Foreground;
            Lifestyle1.Foreground = StartPage.block1.Foreground;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Height_TextChanged(object sender, TextChangedEventArgs e)
        {
            string temp;
            temp = Height.Text;
            float.TryParse(temp, out height);

        }

        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string temp;
            temp = Weight.Text;
            float.TryParse(temp, out weight);

        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            string temp;
            temp = Age.Text;
            float.TryParse(temp, out age);

        }

        private void OnStart(object sender, RoutedEventArgs e)
        {
            val1 = radioButton1.IsChecked;
            if (val1 == true)
            {
                isMale = true;
            }
            else
            {
                isMale = false;
            }

            User user = new User(PersonalDetails.name,PersonalDetails.mobileNo,height,weight,isMale,s1,PersonalDetails.planLose);
            App.dbh.upsert(user);
            
            if (s1 * age * height * weight != 0)
            {
                this.Frame.Navigate(typeof(Result));
            }
            else
            {
                this.Frame.Navigate(typeof(Result));
            }
        }

        private void options_DropDownClosed(object sender, object e)
        {
            try
            {
                // ComboBoxItem typeItem = (ComboBoxItem)options.SelectedItem;
                //s = typeItem.Content.ToString();
                s1 = options.SelectedIndex;

            }
            catch (Exception error)
            {

            }

        }

    }
}
