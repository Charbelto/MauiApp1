namespace MauiApp1;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
        ApplyCurrentStyle();
    }
    private void ApplyCurrentStyle()
    {
        this.Resources["PrimaryColor"] = Application.Current.Resources["PrimaryColor"];
        this.Style = (Style)Application.Current.Resources["PrimaryStyle"];
    }
}