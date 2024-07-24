using System;
using System.IO;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class Homepage : ContentPage
    {
        DatabaseHelper _databaseHelper;
        User _currentUser;

        public Homepage(User currentUser)
        {
            InitializeComponent();
            _databaseHelper = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"));
            _currentUser = currentUser;
            LoadCurrentUser();
            ApplyCurrentStyle();
        }
        private void ApplyCurrentStyle()
        {
            this.Resources["PrimaryColor"] = Application.Current.Resources["PrimaryColor"];
            this.Style = (Style)Application.Current.Resources["PrimaryStyle"];
        }
        private void LoadCurrentUser()
        {
            if (_currentUser != null && !string.IsNullOrEmpty(_currentUser.ImagePath))
            {
                ProfileImage.Source = ImageSource.FromFile(_currentUser.ImagePath);
            }
            else
            {
                ProfileImage.Source = "default_profile_image.png"; // Default profile image path
            }

            // Enable the button after user is loaded
            ChangeProfilePictureButton.IsEnabled = true;
        }

        private async void OnChangeProfilePictureClicked(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                await DisplayAlert("Error", "User not loaded yet. Please try again later.", "OK");
                return;
            }

            var action = await DisplayActionSheet("Change Profile Picture", "Cancel", null, "Take Photo", "Choose from Gallery");
            switch (action)
            {
                case "Take Photo":
                    var photoResult = await MediaPicker.CapturePhotoAsync();
                    if (photoResult != null)
                    {
                        ProfileImage.Source = ImageSource.FromStream(() => photoResult.OpenReadAsync().Result);
                        await SaveProfilePictureAsync(photoResult.FullPath);
                    }
                    break;
                case "Choose from Gallery":
                    var galleryResult = await MediaPicker.PickPhotoAsync();
                    if (galleryResult != null)
                    {
                        ProfileImage.Source = ImageSource.FromStream(() => galleryResult.OpenReadAsync().Result);
                        await SaveProfilePictureAsync(galleryResult.FullPath);
                    }
                    break;
                case "Cancel":
                default:
                    // Cancel button pressed or nothing selected
                    break;
            }
        }

        private async Task SaveProfilePictureAsync(string imagePath)
        {
            // Ensure _currentUser is not null before updating
            if (_currentUser != null)
            {
                _currentUser.ImagePath = imagePath;
                await _databaseHelper.UpdateUserAsync(_currentUser);
            }
            else
            {
                await DisplayAlert("Error", "User not loaded. Cannot save profile picture.", "OK");
            }
        }
    }
}
