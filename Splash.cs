using System;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DNotepad
{
    public partial class Splash : Form
    {
        private const int totalTime = 6; // Total time in seconds
        private const int progressBarSegments = 500; // Number of segments to divide progress bar
        private int segmentDuration; // Duration of each segment in milliseconds
        private int currentSegment; // Current segment of progress
        private int millisecondsPassed; // Milliseconds passed within current segment
        public Splash()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // Calculate segment duration
            segmentDuration = (totalTime * 1000) / progressBarSegments;

            // Initialize the timer
            timer1.Interval = segmentDuration;
            timer1.Tick += Timer1_Tick;

            // Initialize the progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = progressBarSegments;
            progressBar1.Value = 0;
            timer1.Start();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Increment milliseconds passed within current segment
            millisecondsPassed += segmentDuration;

            // Check if segment completed
            if (millisecondsPassed >= segmentDuration)
            {
                // Move to the next segment
                currentSegment++;
                progressBar1.Value = currentSegment;

                // Check if all segments completed
                if (currentSegment >= progressBarSegments)
                {
                    timer1.Stop();
                    Notepad form2 = new Notepad();
                    form2.Shown += Form2_Shown; // Handle the Shown event of Form2
                    form2.Show();
                }

                // Reset milliseconds passed for the new segment
                millisecondsPassed = 0;
            }
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            // Close Form1 when Form2 is shown
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
