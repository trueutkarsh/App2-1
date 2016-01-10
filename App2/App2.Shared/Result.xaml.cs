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
    public sealed partial class Result : Page
    {
        public static double calto;
        public Result()
        {
            this.InitializeComponent();
            grid1.Background = StartPage.grid2.Background;
            title1.Foreground = StartPage.title1.Foreground;
            titleshadow1.Foreground = StartPage.titleshadow1.Foreground;
            double BMR = 10 * NextPage.weight + 6.25 * NextPage.height - 5 * NextPage.age;
            if (NextPage.isMale == true)
            {
                BMR += 5;
            }
            else
            {
                BMR -= 161;
            }
            double[] array = { 1.2, 1.375, 1.55, 1.725, 1.9 };
            double calories = BMR * array[NextPage.s1];
            calories = Math.Round(calories, 2);
            textBlock.Text = calories.ToString() + " cal";
            if (PersonalDetails.planLose == true)
            {
                calories = calories - 500;
                calories = Math.Round(calories, 2);
                calto = calories;
                textBlock_Copy.Text = calories.ToString() + " cal";
            }
            else
            {
                calories += 500;
                calories = Math.Round(calories, 2);
                calto = calories;
                textBlock_Copy.Text = calories.ToString() + " cal";
            }

        }

        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddFood));
        }
    }
}

