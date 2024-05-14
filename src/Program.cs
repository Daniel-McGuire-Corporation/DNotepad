using System.Runtime.InteropServices;

namespace DNotepad
{
    internal static class Program
    {
        // Importing the AllocConsole function from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        // Main entry point of the application
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize the application configuration
            ApplicationConfiguration.Initialize();

            // Create the main form instance
            Notepad mainForm = new Notepad();

            // Process command line arguments
            foreach (string arg in args)
            {
                // Check if the argument is a file path
                if (System.IO.File.Exists(arg))
                {
                    mainForm.OpenFile(arg); // Open the specified file
                }
                else
                {
                    // Handle other types of arguments
                    switch (arg.ToLower())
                    {
                        case "/about":
                            // Show the About dialog
                            About aboutBox = new About();
                            aboutBox.ShowDialog();
                            break;
                        case "/help":
                            // Show the help screen
                            MessageBox.Show(
                                "DNotepad Help Screen\n" +
                                "Usage: DNotepad.exe [arguments]\n" +
                                "Arguments:\n" +
                                "\t/?\t\tShow this help dialog\n" +
                                "\t/about\t\tShow the about dialog\n" +
                                "\t[filePath]\tOpen the specified file",
                                "Help");
                            break;

                        // Add more cases as needed for other arguments
                        default:
                            // Show a message for unknown arguments
                            MessageBox.Show($"Unknown argument: {arg}");
                            break;
                    }
                }
            }

            // Run the main form
            Application.Run(new Notepad());
        }
    }
}
