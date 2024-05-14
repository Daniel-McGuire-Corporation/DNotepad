namespace DNotepad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            // Initialize the form components
            InitializeComponent();

            // Subscribe to the FormClosing event to handle closing behavior
            this.FormClosing += new FormClosingEventHandler(NotepadForm_FormClosing);

            // Allow the form to accept file drops
            this.AllowDrop = true;

            // Subscribe to DragEnter event to handle file dragging
            this.DragEnter += new DragEventHandler(NotepadForm_DragEnter);

            // Subscribe to DragDrop event to handle file dropping
            this.DragDrop += new DragEventHandler(NotepadForm_DragDrop);
        }

        // Method to open a file and load its contents into the richTextBox
        public void OpenFile(string filePath)
        {
            try
            {
                richTextBox1.Text = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }
        }

        // Event handler for when files are dropped onto the form
        private void NotepadForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                // Load the contents of the dropped file into the richTextBox
                richTextBox1.Text = File.ReadAllText(files[0]);
            }
        }

        // Event handler for when files are dragged over the form
        private void NotepadForm_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file drop
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Allow copying the file
            else
                e.Effect = DragDropEffects.None; // Otherwise, don't allow dropping
        }

        // Event handler for the form closing event
        private void NotepadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt the user to save changes before closing
            DialogResult result = MessageBox.Show("Do you want to save changes to your document?", "Save Document", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                // Call the saveToolStripMenuItem_Click event handler to save the file
                saveToolStripMenuItem_Click(sender, e);
                
                
            }
            if (result == DialogResult.No)
            {
               
                
            }
            else if (result == DialogResult.Cancel)
            {
                // Cancel the closing operation if the user chooses to cancel
                e.Cancel = true;
            }
        }

        // Event handler for opening a file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the contents of the selected file into the richTextBox
                    richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message);
                }
            }
        }

        // Event handler for saving a file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DNP File|*.dnp|Text File|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the contents of the richTextBox to the selected file
                File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
            }
        }

        // Event handler for showing the About box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.ShowDialog();
        }

        // Event handler for closing the form
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
