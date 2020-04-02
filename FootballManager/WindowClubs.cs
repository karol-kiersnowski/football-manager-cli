using System;

namespace FootballManager
{
    class WindowClubs : Window
    {
        public WindowClubs(string menu, string name)
        {
            this.name = name;
            this.menu = menu + " >> " + name;
            clubs = CSVStreamer.instance.clubsLeague1.ToArray();
        }

        public WindowClubs(string menu, Club host)
        {
            this.host = host;
            this.menu = menu + " >> " + host.fullName;
            clubs = CSVStreamer.instance.clubsLeague1.ToArray();
        }

        protected override void draw()
        {
            displayHeader();

            Console.Write(Text.league + ": 1");
            int x = 0;
            int y = 8;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.name);
            x += 23;
            //Console.SetCursorPosition(x, y);
            //Console.Write(Text.total);
            //x += 7;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.attack);
            x += 7;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.middle);
            x += 7;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.defense);

            y += 1;

            for (int i = 0; i < clubs.Length; i++)
            {
                x = 0;
                Console.SetCursorPosition(x, y + i);
                Console.Write(i + 1 + ".");
                x += 4;
                Console.SetCursorPosition(x, y + i);
                Console.Write(clubs[i].fullName);
                x += 23;
                //Console.SetCursorPosition(x, y + i);
                //drawBlocks(clubs[i].total);
                //x += 7;
                Console.SetCursorPosition(x, y + i);
                drawBlocks(clubs[i].attack);
                x += 7;
                Console.SetCursorPosition(x, y + i);
                drawBlocks(clubs[i].middle);
                x += 7;
                Console.SetCursorPosition(x, y + i);
                drawBlocks(clubs[i].defense);
            }

            Console.WriteLine("\n");
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            switch (selectedOption)
            {
                case "q": Program.isRunning = false; break;
                case "0": isRunning = false; break;
            }

            if (int.TryParse(selectedOption, out selectedNumber))
            {
                if (name == Text.managerMode)
                {
                    for (int i = 1; i < clubs.Length + 1; i++)
                    {
                        if (selectedNumber == i)
                            new WindowManagerMode(menu, clubs[i - 1]).run();
                    }
                }
                else if (name == Text.friendlyMatch)
                {
                    for (int i = 1; i < clubs.Length + 1; i++)
                    {
                        if (selectedNumber == i)
                            new WindowClubs(menu, clubs[i - 1]).run();
                    }
                }
                else
                {
                    for (int i = 1; i < clubs.Length + 1; i++)
                    {
                        if (selectedNumber == i)
                        {
                            if (host != clubs[i - 1])
                                new WindowBeforeMatch(menu, host, clubs[i - 1]).run();
                        }
                    }
                }
            }
        }

        protected override void update()
        {
        }

        string name;
        Club[] clubs;
        Club host;
    }
}
