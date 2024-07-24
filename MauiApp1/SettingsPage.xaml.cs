using Microsoft.Maui.Controls;

using System;

namespace MauiApp1
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            LoadCurrentStyle();
            ApplyCurrentStyle();
        }
        private void ApplyCurrentStyle()
        {
            this.Resources["PrimaryColor"] = Application.Current.Resources["PrimaryColor"];
            this.Style = (Style)Application.Current.Resources["PrimaryStyle"];
        }

        private void LoadCurrentStyle()
        {
            var savedStyle = Preferences.Get("SelectedStyle", "Light Blue");
            if (savedStyle == "Light Blue")
            {
                StylePicker.SelectedItem = "Light Blue";
            }
            else if (savedStyle == "Dark Blue")
            {
                StylePicker.SelectedItem = "Dark Blue";
            }
        }

        private void OnStylePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStyle = StylePicker.SelectedItem.ToString();
            Preferences.Set("SelectedStyle", selectedStyle);

            if (selectedStyle == "Light Blue")
            {
                Application.Current.Resources["PrimaryColor"] = Application.Current.Resources["LightBlueColor"];
                Application.Current.Resources["PrimaryStyle"] = Application.Current.Resources["LightBlueStyle"];
            }
            else if (selectedStyle == "Dark Blue")
            {
                Application.Current.Resources["PrimaryColor"] = Application.Current.Resources["DarkBlueColor"];
                Application.Current.Resources["PrimaryStyle"] = Application.Current.Resources["DarkBlueStyle"];
            }

            // Apply the new style to all ContentPages
            foreach (var page in Application.Current.MainPage.Navigation.NavigationStack)
            {
                if (page is ContentPage contentPage)
                {
                    contentPage.Resources["PrimaryColor"] = Application.Current.Resources["PrimaryColor"];
                    contentPage.Style = (Style)Application.Current.Resources["PrimaryStyle"];
                }
            }
        }


private void OnLanguagePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLanguage = LanguagePicker.SelectedItem.ToString();
            if (selectedLanguage == "Arabic")
            {
                FlowDirection = FlowDirection.RightToLeft;
                Application.Current.Resources["Choose Style"] = "اختر النمط";
                Application.Current.Resources["Choose Language"] = "اختر اللغة";
                Application.Current.Resources["Light Blue"] = "أزرق فاتح";
                Application.Current.Resources["Dark Blue"] = "أزرق داكن";
                Application.Current.Resources["AppTitle"] = "عنوان التطبيق";
                Application.Current.Resources["Settings"] = "إعدادات";
                Application.Current.Resources["App"] = "التطبيق";
                Application.Current.Resources["Login"] = "تسجيل الدخول";
                Application.Current.Resources["GoToSignUp"] = "تسجيل";
                Application.Current.Resources["SignUp"] = "تسجيل";
                Application.Current.Resources["Start"] = "بداية";
                Application.Current.Resources["Username"] = "اسم المستخدم";
                Application.Current.Resources["Password"] = "كلمة المرور";
                Application.Current.Resources["LoginButton"] = "دخول";
                Application.Current.Resources["CancelButton"] = "إلغاء";
            }
            else
            {
                FlowDirection = FlowDirection.LeftToRight;
                Application.Current.Resources["Choose Style"] = "Choose Style";
                Application.Current.Resources["Choose Language"] = "Choose Language";
                Application.Current.Resources["Light Blue"] = "Light Blue";
                Application.Current.Resources["Dark Blue"] = "Dark Blue";
                Application.Current.Resources["AppTitle"] = "App Title";
                Application.Current.Resources["App"] = "App";
                Application.Current.Resources["Settings"] = "Settings";
                Application.Current.Resources["Login"] = "Login";
                Application.Current.Resources["GoToSignUp"] = "Go To Sign Up";
                Application.Current.Resources["SignUp"] = "SignUp";
                Application.Current.Resources["Start"] = "Start";
                Application.Current.Resources["Username"] = "Username";
                Application.Current.Resources["Password"] = "Password";
                Application.Current.Resources["LoginButton"] = "Login";
                Application.Current.Resources["CancelButton"] = "Cancel";
            }
        }
    }
}