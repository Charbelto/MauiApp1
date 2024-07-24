using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ApplyCurrentStyle();
        }
        private void ApplyCurrentStyle()
        {
            this.Resources["PrimaryColor"] = Application.Current.Resources["PrimaryColor"];
            this.Style = (Style)Application.Current.Resources["PrimaryStyle"];
        }
        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
