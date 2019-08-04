using System;

namespace FootballManager
{
    class WindowBeforeMatch : Window
    {
        public WindowBeforeMatch(string menu, Club host, Club guest)
        {
            this.host = host;
            this.guest = guest;
            this.menu = menu + " - " + guest.fullName;
            options = new string[3];
            options[0] = Text.startMatch;
            options[1] = Text.squad;
            options[2] = Text.tactics;

            host.manager.setTheBestSquad();
        }

        protected override void draw()
        {
            displayHeader();
            displayOptions();
            Console.WriteLine("{0,-17} {1,-7} {2,17}", host.fullName, "Drużyny", guest.fullName);
            Console.WriteLine("{0,-17} {1,-16} {2,8}", host.total, "Poziom", guest.total);
            Console.WriteLine("{0,-17} {1,-16} {2,8}", host.attack, "Atak", guest.attack);
            Console.WriteLine("{0,-17} {1,-16} {2,8}", host.middle, "Pomoc", guest.middle);
            Console.WriteLine("{0,-17} {1,-16} {2,8}", host.defense, "Obrona", guest.defense);

            //Console.WriteLine(gospodarz.nazwa + "\t\t" + gosc.nazwa);
            //Console.WriteLine(gospodarz.poziom + "\t\tPoziom\t\t" + gosc.poziom);
            //Console.WriteLine(gospodarz.atak + "\t\tAtak\t\t" + gosc.atak);
            //Console.WriteLine(gospodarz.pomoc + "\t\tPomoc\t\t" + gosc.pomoc);
            //Console.WriteLine(gospodarz.obrona + "\t\tObrona\t\t" + gosc.obrona);
            //Console.WriteLine(gospodarz.ustawienie);

            Console.WriteLine();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            if (selectedOption == "q") Program.isRunning = false;
            if (int.TryParse(selectedOption, out selectedNumber))
            {
                switch (selectedNumber)
                {
                    case 0: isRunning = false; break;
                    case 1: new WindowMatch(menu, new Match(host, guest, TypeOfMatch.friendly)).run(); break;
                    case 2: new WindowSquad(menu, host, null).run(); break;
                    case 3: new WindowTactics(menu, host, null).run(); break;
                }
            }
        }

        protected override void update()
        {
            
        }

        Club host;
        Club guest;
    }
}
