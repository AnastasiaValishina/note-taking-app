namespace NoteTakingApp
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }

        public Note(string title, string note)
        {
            Title = title;
            NoteText = note;
        }
    }
}
