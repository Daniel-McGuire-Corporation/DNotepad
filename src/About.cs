namespace DNotepad
{
    // Form for displaying the About box
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent(); // Initialize the About box components
        }

        // Override the WndProc method to customize window behavior
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HT_CAPTION = 0x2;

            // Intercept window messages to handle window dragging
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == 0x1)
                    m.Result = (IntPtr)HT_CAPTION; // Allow dragging the window by clicking on its caption
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        // Event handler for the OK button click
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the About box when the OK button is clicked
        }

        // Event handler for the Close button click
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the About box when the Close button is clicked
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
