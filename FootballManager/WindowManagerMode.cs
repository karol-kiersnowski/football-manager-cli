using System;

namespace FootballManager
{
    class WindowManagerMode : Window
    {
        public WindowManagerMode(string menu, Club playerClub)
        {
            this.club = playerClub;

            new Games(2019, playerClub);

            this.menu = menu + " >> " + playerClub.fullName;
            options = new string[9];
            options[0] = Text.startMatch;
            options[1] = Text.squad;
            options[2] = Text.tactics;
            options[3] = Text.training;
            options[4] = Text.transfers;
            options[5] = Text.finance;
            options[6] = Text.stadium;
            options[7] = Text.statistics;
            options[8] = Text.saveGame;

            playerClub.manager.setTheBestSquad();
        }

        protected override void draw()
        {
            displayHeader();
            displayOptions();
            displayInformationsAboutClub(25, 6);
            Console.WriteLine();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            switch (selectedOption)
            {
                case "q": Program.isRunning = false; break;
                case "0": isRunning = false; break;
                case "1": playRound(); break;
                case "2": new WindowSquad(menu, club, null).run(); break;
                case "3": new WindowTactics(menu, club, null).run(); break;
                case "4": new WindowTraining(menu, club).run(); break;
                case "5": new WindowTransfers(menu, club).run(); break;
                case "6": new WindowFinance(menu, club).run(); break;
                case "7": new WindowStadium(menu, club).run(); break;
                case "8": new WindowStatistics(menu).run(); break;
            }
        }

        Club club;

        void playRound()
        {
            if (Games.instance.playerLeague.nrRound < 30)
            {
                Games.instance.goToNextWeek();
                Match match = Games.instance.checkPreviousMatch();
                //match.clear();
                //new WindowMatch(menu, match).run();
                Games.instance.playerLeague.updateStatistics();
            }
            else
            {
                int year = Games.year + 1;
                new Games(year, club);
            }
        }

        void displayInformationsAboutClub(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.club + ": " + Games.instance.playerClub.fullName);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.manager + Games.instance.playerClub.manager.fullName);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.league + ": " + Games.instance.playerLeague.name);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.season + Games.instance.season);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.money + "{0:n0}", Games.instance.playerClub.finance.money);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.nextRound + (Games.instance.polishLeague1.nrRound + 1));
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.position + Games.instance.checkPosition());
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Text.form + Games.instance.check5PreviousMatches());
            y++;
            Console.SetCursorPosition(x, y);
            if (Games.instance.checkNextMatch() != null)
                Console.WriteLine(Text.nextMatch + Games.instance.checkNextMatch().teams);
            if (Games.instance.checkNextMatch() == null)
                Console.WriteLine(Text.nextMatch);
            y++;
            Console.SetCursorPosition(x, y);
            if (Games.instance.checkPreviousMatch() != null)
                Console.WriteLine(Text.previousMatch + Games.instance.checkPreviousMatch().teamsAndResult);
            if (Games.instance.checkPreviousMatch() == null)
                Console.WriteLine(Text.previousMatch);
        }

        protected override void update()
        {
            
        }
    }
}
