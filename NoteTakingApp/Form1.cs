using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            notesList.Add(new Note("one", "hi"));
            notesList.Add(new Note("second note", "1 2 3 4 5"));

            ResetListBindings();
        }

        private void ResetListBindings()
        {
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
                var toDelete = previousNotesList.SelectedItem;
                notesList.Remove((Note)toDelete);
                ResetListBindings();
            }
            catch(Exception ex) { Console.WriteLine("Not a valid note."); }
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
                notesList.Add(new Note(titleBox.Text, noteBox.Text));
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
