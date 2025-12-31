//--Copyright (c) 2024-2026 Robert A. Howell

using System;
using System.Windows.Forms;

namespace HttpRequest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new HTTPRequest());
        }
    };
}