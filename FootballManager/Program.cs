﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FootballManager
{
    class Program
    {
        public static bool isRunning;

        static void Main(string[] args)
        {
            //Console.CursorVisible = false;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            isRunning = true;
            Window.setTitle("Football Manager");
            Window.setDimensions(90, 30);
            new WindowLanguage().run();
            new WindowLoading().run();
            new WindowMain().run();
            Console.Clear();
        }
    }
}
