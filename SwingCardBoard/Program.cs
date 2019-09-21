﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SwingCardBoard
{
    static class Program
    {
        public static  readonly string Version = "1.0.0";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginWnd login = new LoginWnd();
            if (login.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Application.Run(new MainWnd());
        }
    }
}
