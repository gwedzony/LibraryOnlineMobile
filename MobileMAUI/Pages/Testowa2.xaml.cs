namespace MobileMAUI.Pages;

public partial class Testowa2 : ContentPage
{
	public Testowa2()
	{
		InitializeComponent();
	}

    private void Przycisk_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new Testowa1());

    }
}