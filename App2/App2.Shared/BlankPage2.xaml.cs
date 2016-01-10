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
    public sealed partial class BlankPage2 : Page
    {
        public static string name;
        public static string mobileNo;
        public static string plan;
        private static bool? val1, val2;
        public static bool planLose;
        public BlankPage2()
        {
            this.InitializeComponent();
            grid1.Background = StartPage.grid2.Background;
            title1.Foreground = StartPage.title1.Foreground;
            titleshadow1.Foreground = StartPage.titleshadow1.Foreground;
        }

        /*private void OnStart(object sender, RoutedEventArgs e)
        {
            name = Name.Text;
            mobileNo = Mobile_no.Text;
            val1 = radioButton1.IsChecked;
            if (val1 == true)
            {
                planLose = true;
            }
            else
            {
                planLose = false;
            }
            this.Frame.Navigate(typeof(NextPage));

        }*/

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = Name.Text;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            val1 = radioButton1.IsChecked;
        }

        private void title1_PointerMoved(object sender, PointerRoutedEventArgs e)
        {

        }

        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            name = Name.Text;
            title1.Text = AddFood.s2.ToString();
            mobileNo = Mobile_no.Text;
            val1 = radioButton1.IsChecked;
            if (val1 == true)
            {
                planLose = true;
            }
            else
            {
                planLose = false;
            }
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            val2 = radioButton2.IsChecked;
        }
    }
}

