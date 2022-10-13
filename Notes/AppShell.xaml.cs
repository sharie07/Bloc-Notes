namespace Notes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Vues.NotesPage), typeof(Vues.NotesPage));
    }
}
