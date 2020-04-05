using System;
using System.Collections.Generic;

namespace FootballManager
{
    class WindowTransfersSales : Window
    {
        public WindowTransfersSales(string menu, Club club)
        {
            this.club = club;
            this.menu = menu + " >> " + Text.sale;
            players = club.squad.players;
        }
        
        protected override void draw()
        {
            int initialY = displayHeader();

            int x = 0;
            int y = initialY;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.player);
            x += 17;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.age);
            x += 5;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.tot);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.gk);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write("Def");
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.plm);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.sho);
            x += 4;
           Console.SetCursorPosition(x, y);
            Console.Write(Text.sta);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.value);
           x += 10;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.salary);
            x += 7;
            Console.SetCursorPosition(x, y);
            Console.Write("Status");

            y += 1;

            for (int i = 0; i < players.Count; i++)
            {
                x = 0;
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].nr);
                x += 4;
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].fSurname);
                x += 17;
                setColor(players[i].age, "wiek");
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].age);
                x += 5;
                setColor(players[i].skills);
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].skills);
                x += 4;
                setColor(players[i].goalkeeping);
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].goalkeeping);
                x += 4;
                setColor(players[i].defending);
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].defending);
                x += 4;
                setColor(players[i].playmaking);
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].playmaking);
                x += 4;
                setColor(players[i].shooting);
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].shooting);
                x += 4;
                setColor(players[i].condition);
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].condition);
                x += 4;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + i);
                Console.Write("{0:n0}", players[i].value);
                x += 10;
                Console.SetCursorPosition(x, y + i);
                Console.Write("{0:n0}", players[i].salary);
                x += 7;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + i);
                if (players[i].isForSale)
                    Console.Write("Na sprzedaż");
            }
        }

        protected override void selectOption()
        {
            Console.Write("\n\nPodaj numer piłkarza, którego chcesz wystawić na listę transferową lub z niej usunąć: ");
            selectedOption = Console.ReadLine();
            if (selectedOption == "q") Program.isRunning = false;
            if (int.TryParse(selectedOption, out selectedNumber))
            {
                if (selectedNumber == 0) isRunning = false;
                if (selectedNumber > 0 && selectedNumber <= players.Count)
                {
                    if (!players[selectedNumber - 1].isForSale)
                    {
                        players[selectedNumber - 1].isForSale = true;
                        Games.instance.transferList.Add(players[selectedNumber - 1]);
                    }
                    else if (players[selectedNumber - 1].isForSale)
                    {
                        players[selectedNumber - 1].isForSale = false;
                        Games.instance.transferList.Remove(players[selectedNumber - 1]);
                    }
                }
            }
        }

        Club club;
        List<Player> players;

        void setColor(int skills)
        {
            if (skills >= 80)
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (skills >= 60 && skills < 80)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (skills >= 40 && skills < 60)
                Console.ForegroundColor = ConsoleColor.Blue;
            if (skills < 40)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        void setColor(int age, string data)
        {
            if (age < 20)
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (age >= 20 && age < 27)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (age >= 27 && age < 35)
                Console.ForegroundColor = ConsoleColor.Blue;
            if (age >= 35)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        protected override void update()
        {
            
        }
    }
}
