using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadSavedStyle();
            MainPage = new NavigationPage(new MainPage());
        }

        private void LoadSavedStyle()
        {
            var savedStyle = Preferences.Get("SelectedStyle", "Light Blue");
            if (savedStyle == "Light Blue")
            {
                Application.Current.Resources["PrimaryColor"] = Application.Current.Resources["LightBlueColor"];
                Application.Current.Resources["PrimaryStyle"] = Application.Current.Resources["LightBlueStyle"];
            }
            else if (savedStyle == "Dark Blue")
            {
                Application.Current.Resources["PrimaryColor"] = Application.Current.Resources["DarkBlueColor"];
                Application.Current.Resources["PrimaryStyle"] = Application.Current.Resources["DarkBlueStyle"];
            }
        }
    }
}
