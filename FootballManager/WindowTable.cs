using System;

namespace FootballManager
{
    class WindowTable : Window
    {
        public WindowTable(string menu)
        {
            this.menu = menu + " >> " + Text.leagueTable;
            table = Games.instance.playerLeague.table;
            table.sort();
        }

        protected override void update()
        {
            table = Games.instance.playerLeague.table;
        }

        protected override void draw()
        {
            int initialY = displayHeader();
            Console.WriteLine(Text.league + ": " + Games.instance.playerLeague.name);

            int x = 0;
            int y = initialY + 2;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.positionAbbr);
            x += 5;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.club);
            x += 23;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.played);
            x += 3;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.won);
            x += 3;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.drawn);
            x += 3;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.lost);
            x += 3;
            Console.SetCursorPosition(x, y);
            Console.Write("G+");
            x += 3;
            Console.SetCursorPosition(x, y);
            Console.Write("G-");
            x += 3;
            Console.SetCursorPosition(x, y);
            Console.Write("G+/-");
            x += 5;
           Console.SetCursorPosition(x, y);
            Console.Write(Text.points);

            for (int i = 0; i < table.clubs.Length; i++)
            {
                x = 0;
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.position + ".");
                x += 5;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].fullName);
                x += 23;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.played);
                x += 3;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.won);
                x += 3;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.drawn);
                x += 3;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.lost);
                x += 3;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.scoredGoals);
                x += 3;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.lostGoals);
                x += 3;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.bilanceGoals);
                x += 5;
                Console.SetCursorPosition(x, y);
                Console.Write(table.clubs[i].statistics.points);
            }
        }

        protected override void selectOption()
        {
            Console.ReadKey();
            isRunning = false;
        }

        TableLeague table;
    }
}
