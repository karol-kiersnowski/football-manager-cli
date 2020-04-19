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
            int initialY = displayHeader();

            int x = 0;
            int y = initialY;
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
                for (int j = 0; j < Data.instance.clubs.Length; j++)
                {
                    if (Data.instance.clubs[j].id == transferList[i].clubId)
                        Console.Write(Data.instance.clubs[j].fullName);
                }
                x += 23;
                setColorAge(transferList[i].age);
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
                System.Console.Write("{0:n0}", transferList[i].value);

                System.Console.ForegroundColor = ConsoleColor.Gray;
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
                    new Transfer(selectedPlayer, Data.instance.clubs[1], club, selectedPlayer.value);
                    selectedPlayer = null;
                    club.squad.setNumbers();
                    club.calculateSkills();
                }
            }
        }

        protected override void update()
        {

        }

        Club club;
        List<Player> transferList;
        Player selectedPlayer;

        void setColor(double price, int i)
        {
            if (club.finance.money >= transferList[i].value)
                System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            if (club.finance.money < transferList[i].value)
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
        }
    }
}
