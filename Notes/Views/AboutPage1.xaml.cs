namespace Notes.Views;

public partial class AboutPage1 : ContentPage
{
	public AboutPage1()
	{
		InitializeComponent();
	}

	private async void LearnMore_Clicked(object sender, EventArgs e)
	{

		await Launcher.Default.OpenAsync("https://aka.ms/maui");
	}
}
	
