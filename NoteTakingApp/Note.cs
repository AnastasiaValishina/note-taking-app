using System.ComponentModel;

namespace NoteTakingApp
{
    public class Note : INotifyPropertyChanged
    {
        public int Id { get; set; }
        
        private string title;
        private string noteText;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string NoteText
        {
            get { return noteText; }
            set
            {
                if (noteText != value)
                {
                    noteText = value;
                    OnPropertyChanged(nameof(NoteText));
                }
            }
        }

        public Note(string title, string note)
        {
            Title = title;
            NoteText = note;
        }

        public Note() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
