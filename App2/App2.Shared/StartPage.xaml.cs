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
    public sealed partial class StartPage : Page
    {
        public static Grid grid2;
        public static TextBlock title1;
        public static TextBlock titleshadow1;
        public StartPage()
        {
            this.InitializeComponent();
            grid2 = grid1;
            title1 = title2;
            titleshadow1 = titleshadow2;
        }

        private void OnStart(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PersonalDetails));
        }

    }
}

