using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWepED
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select your Worms 4 Mayhem directory";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (File.Exists(dialog.FileName + @"\data\Tweak\Local.xml"))
                {
                    Application.Run(new Main(dialog.FileName));
                }
                else
                {
                    MessageBox.Show(dialog.FileName + @"\data\Tweak\Local.xml" + " not found! Exiting...");
                }
            }

        }
    }
}
