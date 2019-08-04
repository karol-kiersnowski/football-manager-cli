﻿using System;

namespace FootballManager
{
    class WindowTransfers : Window
    {
        public WindowTransfers(string menu, Club club)
        {
            this.club = club;
            this.menu = menu + " >> " + Text.transfers;
            options = new string[3];
            options[0] = Text.displayPlayerOnTransferList;
            options[1] = Text.browseTransferList;
            options[2] = Text.browsePlayersOfClubs;
        }

        protected override void draw()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 6);
            Console.WriteLine(Text.money + "{0:n0}", club.finance.money);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(logo);
            Console.WriteLine(menu + "\n");
            displayOptions();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            switch(selectedOption)
            {
                case "q": Program.isRunning = false; break;
                case "0": isRunning = false; break;
                case "1": new WindowTransfersSales(menu, club).run(); break;
                case "2": new WindowTransferList(menu, club).run(); break;
            }
        }

        protected override void update()
        {
            
        }

        Club club;
    }
}
