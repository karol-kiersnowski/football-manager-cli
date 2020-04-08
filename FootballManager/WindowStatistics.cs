using System;

namespace FootballManager
{
    class WindowStatistics : Window
    {
        public WindowStatistics(string menu)
        {
            this.menu = menu + " >> " + Text.statistics;
            options = new string[4];
            options[0] = Text.leagueTable;
           options[1] = Text.topScorers;
           options[2] = Text.leagueFixtures;
            options[3] = Text.clubFixtures;
        }

        protected override void draw()
        {
            displayHeader();
            displayOptions();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            switch(selectedOption)
            {
                case "q": Program.isRunning = false;    break;
                case "0": isRunning = false;  break;
                case "1": new WindowTable(menu).run();  break;
                case "2": new WindowTopScorers(menu).run(); break;
                case "3": new WindowFixturesLeague(menu).run(); break;
                case "4": new WindowFixturesClub(menu).run(); break;
            }
        }

        protected override void update()
        {
            
        }
    }
}
