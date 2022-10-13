namespace Notes.Vues;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotesPage : ContentPage
{
	string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
	public NotesPage()
	{
		InitializeComponent();

		string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
		
	}


	private void LoadNote(string fileName)
	{
		Models.Notes notesModel = new Models.Notes();
		notesModel.Filename = fileName;

		if(File.Exists(_fileName))
		{
			notesModel.Date = File.GetCreationTime(fileName);
			notesModel.Text = File.ReadAllText(fileName);
		}
		BindingContext = notesModel;
	}

    public string ItemId
    {
        set { LoadNote(value); }
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Notes notes)
            File.WriteAllText(notes.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Notes notes)
        {
            // Delete the file.
            if (File.Exists(notes.Filename))
                File.Delete(notes.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}