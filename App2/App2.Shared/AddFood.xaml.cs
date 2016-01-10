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
using App2.Models;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddFood : Page
    {
        public static string selected;
        public static int s2;
        public List<FoodItems> log;
        public AddFood()
        {
            this.InitializeComponent();
            grid1.Background = StartPage.grid2.Background;
            title1.Foreground = StartPage.title1.Foreground;
            titleshadow1.Foreground = StartPage.titleshadow1.Foreground;
            tb1.Foreground = StartPage.block1.Foreground;
            tb1_Copy.Foreground = StartPage.block1.Foreground;
            log = new List<FoodItems>();
            log = App.dbh.getAllFood();
            foreach(FoodItems food in log)
            {
                cb1.Items.Add(food.name);
            }
            cb1.SelectedValuePath= "name";
            tb1_Copy.Text = "Ideal Calorie intake:" + Result.calto; 
            //cb1.Items.Count;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Log entry = new Log(-1f*float.Parse(textBox.Text), "Workout");
                App.dbh.updateLog(entry);

                tb1.Text = "Net Cal Intake: "+App.dbh.lastLog().cumCalorie.ToString()+ " cal";
            }
            catch (Exception error2) { }
        }

        private void comboBox_DropDownClosed(object sender, object e)
        {
            try
            {
                //  ComboBoxItem typeItem = (ComboBoxItem)cb1.SelectedItem;
                // selected = typeItem.Content.ToString();
                s2 = cb1.SelectedIndex;
               // s2 = cb1.Items.Count;
            }
            catch (Exception error1)
            { }


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

               FoodItems fd= log.ElementAt<FoodItems>(s2);
                Log entry = new Log(fd.cal,fd.name);
                App.dbh.updateLog(entry);

                tb1.Text = "Net Cal Intake: " + App.dbh.lastLog().cumCalorie.ToString() + " cal";
            }
            catch (Exception error2) { }

        }

        private void OnStart(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PersonalDetails));
        }
    }
}
