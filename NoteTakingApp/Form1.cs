using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class NoteTaker : Form
    {
        List<Note> notesList = new List<Note>();
        bool isEditing = false;
        BindingSource bindingSource = new BindingSource();

        public NoteTaker()
        {
            InitializeComponent();
            bindingSource.DataSource = notesList;
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            LoadNotes();
        }

        private void LoadNotes()
        {
            notesList.Clear();
            notesList.AddRange(SqliteDataAccess.LoadNotes());
            ResetListBindings();
        }

        private void ResetListBindings()
        {
            previousNotesList.DataSource = null;
            previousNotesList.DataSource = bindingSource;
            previousNotesList.DisplayMember = "Title";
            bindingSource.ResetBindings(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var toDelete = (Note)previousNotesList.SelectedItem;
                if (toDelete != null)
                {
                    SqliteDataAccess.DeleteNote(toDelete.Id);
                    notesList.Remove((Note)toDelete);
                    ResetListBindings();
                }
                else
                {
                    MessageBox.Show("Please select a note to delete.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting note: {ex.Message}");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                Note note = (Note)previousNotesList.SelectedItem;
                note.Title = titleBox.Text;
                note.NoteText = noteBox.Text;
            }
            else
            {
                SqliteDataAccess.SaveNote(new Note(titleBox.Text, noteBox.Text));
            }
            titleBox.Text = "";
            noteBox.Text = "";
            isEditing = false;
            ResetListBindings();
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            Note note = (Note)previousNotesList.SelectedItem;
            titleBox.Text = note.Title;
            noteBox.Text = note.NoteText;
            isEditing = true;
        }

        private void doubleClick(object sender, EventArgs e)
        {
            Note note = (Note)previousNotesList.SelectedItem;
            titleBox.Text = note.Title;
            noteBox.Text = note.NoteText;
            isEditing = true;
        }
    }
}
