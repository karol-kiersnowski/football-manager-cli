using System;

namespace FootballManager
{
    class WindowTopScorers : Window
    {
        public WindowTopScorers(string menu)
        {
            this.menu = menu + " >> " + Text.topScorers;
            clubs = Games.instance.playerLeague.clubs;
            table = Games.instance.playerLeague.topScorers;
            table.sort();
        }

        protected override void draw()
        {
            displayHeader();

            int x = 0;
            int y = 6;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.positionAbbr);
            x += 5;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.player);
            x += 23;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.club);
            x += 23;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.goals);
            x += 6;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.matches);


            for (int i = 0; i < 20; /*table.players.Count;*/ i++)
            {
                x = 0;
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write(table.players[i].statistics.position + ".");
                x += 5;
                Console.SetCursorPosition(x, y);
                Console.Write(table.players[i].fullName);
                x += 23;
                Console.SetCursorPosition(x, y);
                Console.Write(clubs[table.players[i].clubId - 1].fullName);
                x += 23;
                Console.SetCursorPosition(x, y);
                Console.Write(table.players[i].statistics.goals);
                x += 6;
                Console.SetCursorPosition(x, y);
                Console.Write(table.players[i].statistics.playedMatches);
            }
        }
        protected override void selectOption()
        {
            Console.ReadKey();
            isRunning = false;
        }

        protected override void update()
        {
            
        }

        Club[] clubs;
        TableTopScorers table;
    }
}
