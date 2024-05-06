namespace MobileMAUI.Pages;

public partial class Testowa1 : TabbedPage
{
	public Testowa1()
	{
		InitializeComponent();
	}

    private void PrzyciskT1_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new Testowa2());

    }
}