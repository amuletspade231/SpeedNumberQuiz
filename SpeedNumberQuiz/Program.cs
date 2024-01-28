using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Amanda Cao

// This is a speed quiz to see how many questions the user can get right within 30s.
// With a correct answer, the text will turn green.
// With the wrong answer or invalid input, the text will turn red.

namespace SpeedNumberQuiz
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
