using System;

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
            int intialY = displayHeader();
            Console.SetCursorPosition(45, intialY);
            Console.WriteLine(Text.money + "{0:n0}", club.finance.money);
            Console.SetCursorPosition(0, intialY + 1);
            displayOptions();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            checkBasicOptions();
            switch (selectedOption)
            {
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
