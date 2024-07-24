using System;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class SignUpPage : ContentPage
    {
        DatabaseHelper _databaseHelper;

        public SignUpPage()
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

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            await _databaseHelper.InsertUserAsync(user);
            await DisplayAlert("Success", "User registered successfully!", "OK");
            await Navigation.PopAsync(); // Navigate back to login page
        }
    }
}
