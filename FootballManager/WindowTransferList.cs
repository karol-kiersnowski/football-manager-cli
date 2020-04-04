using System;
using System.Collections.Generic;

namespace FootballManager
{
    class WindowTransferList : Window
    {
        public WindowTransferList(string menu, Club club)
        {
            this.club = club;
            this.menu = menu + " >> " + Text.transferList;
            transferList = Games.instance.transferList;
        }
        
        protected override void draw()
        {
            displayHeader();

            int x = 0;
            int y = 6;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.player);
            x += 14;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.club);
            x += 23;
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

            y += 1;

            for (int i = 0; i < transferList.Count; i++)
            {
                x = 0;
                Console.SetCursorPosition(x, y + i);
                Console.Write(i + 1 + ". ");
                x += 4;
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].surname);
                x += 14;
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < CSVStreamer.instance.clubs.Count; j++)
                {
                    if (CSVStreamer.instance.clubs[j].id == transferList[i].clubId)
                        Console.Write(CSVStreamer.instance.clubs[j].fullName);
                }
                x += 23;
                setColor(transferList[i].age, "wiek");
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].age);
                x += 5;
                setColor(transferList[i].skills);
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].skills);
                x += 4;
                setColor(transferList[i].goalkeeping);
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].goalkeeping);
                x += 4;
                setColor(transferList[i].defending);
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].defending);
                x += 4;
                setColor(transferList[i].playmaking);
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].playmaking);
                x += 4;
                setColor(transferList[i].shooting);
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].shooting);
                x += 4;
                setColor(transferList[i].condition);
                Console.SetCursorPosition(x, y + i);
                Console.Write(transferList[i].condition);
                x += 4;
                setColor(transferList[i].value, i);
                Console.SetCursorPosition(x, y + i);
                Console.Write("{0:n0}", transferList[i].value);

                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        protected override void selectOption()
        {
            if (selectedPlayer == null)
            {
                Console.Write("\n\nPodaj numer piłkarza, którego chcesz kupić: ");
                selectedOption = Console.ReadLine();
                if (selectedOption == "q")
                    Program.isRunning = false;
                if (int.TryParse(selectedOption, out selectedNumber))
                {
                    if (selectedNumber == 0)
                        isRunning = false;
                    if (selectedNumber > 0 && selectedNumber <= transferList.Count)
                    {
                        if (club.id != transferList[selectedNumber - 1].clubId &&
                            club.squad.players.Count < 25 &&
                            club.finance.money > transferList[selectedNumber - 1].value)
                            selectedPlayer = transferList[selectedNumber - 1];
                    }
                }
            }
            else if (selectedPlayer != null)
            {
                Console.Write("\n\nNapewno chcesz kupić " + selectedPlayer.fullName + "? t/n: ");
                selectedOption = Console.ReadLine();
                if (selectedOption == "0")
                    isRunning = false;
                if (selectedOption == "n")
                    selectedPlayer = null;
                if (selectedOption == "t")
                {
                    selectedPlayer.isForSale = false;
                    transferList.Remove(selectedPlayer);
                    new Transfer(selectedPlayer, CSVStreamer.instance.clubs[1], club, selectedPlayer.value);
                    selectedPlayer = null;
                    club.squad.setNumbers();
                    club.calculateSkills();
                }
            }
        }

        Club club;
        List<Player> transferList;
        Player selectedPlayer;

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
        void setColor(double price, int i)
        {
            if (club.finance.money >= transferList[i].value)
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (club.finance.money < transferList[i].value)
                Console.ForegroundColor = ConsoleColor.Blue;
        }

        protected override void update()
        {
            
        }
    }
}
