namespace DNotepad
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = Color.FromArgb(23, 23, 23);
            progressBar1.Location = new Point(1, 1);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(222, 37);
            progressBar1.TabIndex = 1;
            progressBar1.UseWaitCursor = true;
            progressBar1.Click += progressBar1_Click;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 23, 23);
            ClientSize = new Size(224, 23);
            ControlBox = false;
            Controls.Add(progressBar1);
            Cursor = Cursors.AppStarting;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Splash";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Splash.Screen";
            TopMost = true;
            UseWaitCursor = true;
            ResumeLayout(false);
        }

        #endregion
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}