using System.Collections.ObjectModel;

namespace Notes.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Notes> Notes { get; set; } = new ObservableCollection<Notes>();

        public AllNotes() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            IEnumerable<Notes> notes = Directory
                .EnumerateFiles(appDataPath, "*.notes.txt")
                .Select(fileName => new Notes()
                {
                    Filename = fileName,
                    Text = File.ReadAllText(fileName),
                    Date = File.GetCreationTime(fileName)
                })
                .OrderBy(notes => notes.Date);

            foreach (Notes note in notes)
                Notes.Add(note);
        }
    }
}
