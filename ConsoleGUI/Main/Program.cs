using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using ConsoleGUI.Classes;

namespace ConsoleGUI
{
    //using static LayerObject.ShapeType;
    using static ConsoleColor;
    using static ConsoleKey;
    public class Program
    {      
        
        public static void Main()
        {

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.BufferWidth = Console.WindowWidth;
            //Largest windowwidth = 200
            //Largest windowheight = 71

            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.CursorVisible = false;
            var sheet = new DrawSheet();
            sheet.DisplayAdd((5, 5), 'o');
            Console.ReadKey();
            var obj = new Circle();
            obj.Color = DarkGreen;
            sheet.ShapeObjects.Add(obj);
            sheet.Activate(obj);
            sheet.DisplayAdd((5, 5), 'o');

            Console.ReadKey();
        }



        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

    }
}

    
