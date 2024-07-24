using System;
using Microsoft.Maui.Controls;
using System.Linq;

namespace MauiApp1
{
    public partial class LoginPage : ContentPage
    {
        DatabaseHelper _databaseHelper;
        User _currentUser;
        public LoginPage()
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"));
            ApplyCurrentStyle();
        }
        private void ApplyCurrentStyle()
        {
            this.Resources["PrimaryColor"] = Application.Current.Resources["PrimaryColor"];
            this.Style = (Style)Application.Current.Resources["PrimaryStyle"];
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            _currentUser = await _databaseHelper.GetUserAsync(username, password);

            if (_currentUser != null)
            {
                await Navigation.PushAsync(new Homepage(_currentUser));
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        private async void OnGoToSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
