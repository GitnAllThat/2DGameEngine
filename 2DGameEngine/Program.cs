using Microsoft.Xna.Framework;
using System;
using System.Windows.Forms;



namespace _2DLevelCreator
{


    static class Program // Make sure to define a class here
    {
        public static MainForm mainForm;

        [STAThread] // This attribute is important for Windows Forms applications


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);



            mainForm = new MainForm();
            mainForm.Show();

            Application.Run(mainForm);
        }
    }
}