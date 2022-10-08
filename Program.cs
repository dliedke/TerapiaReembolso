/* *******************************************************************************************************************
 * Application: TerapiaReembolso
 * 
 * Authors:  Daniel Liedke
 * 
 * Copyright © Dell Inc. 2020
 * Usage and reproduction in any manner whatsoever without the written permission of Dell Inc. is strictly forbidden.
 *  
 * Purpose: Start up class
 *           
 * *******************************************************************************************************************/

using System;
using System.Windows.Forms;

namespace TerapiaReembolso
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
