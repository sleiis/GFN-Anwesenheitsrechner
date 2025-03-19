using System;
using System.Threading;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new form_Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler beim Start");
            }
        }
    }
}
