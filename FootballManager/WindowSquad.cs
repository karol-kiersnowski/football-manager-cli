using System;
using System.Collections.Generic;

namespace FootballManager
{
    class WindowSquad : Window
    {
        public WindowSquad(string menu, Club club, Match match)
        {
            this.club = club;
            this.match = match;
            this.menu = menu + " >> " + Text.squad;
            players = club.squad.players;
            nr1 = -1;
            nr2 = -1;
            club.squad.setNumbers();

            pitch = new Pitch(17, 26, 3);
        }
        
        protected override void draw()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            pitch.draw(50, 6);
            pitch.writeNumbers(50, 6, club);
            Console.ResetColor();
            Console.SetCursorPosition(50, 24);
            Console.WriteLine(Text.tot + " - " + Text.total);
            Console.SetCursorPosition(50, 25);
            Console.WriteLine(Text.gk + "  - " + Text.goalkeeping);
            Console.SetCursorPosition(50, 26);
            Console.WriteLine(Text.plm + " - " + Text.playmaking);
            Console.SetCursorPosition(50, 27);
            Console.WriteLine(Text.sho + " - " + Text.shooting);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(logo);
            Console.WriteLine(menu);

            int x = 0;
            int y = 6;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.player);
            x += 17;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.age);
            x += 4;
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

            y += 1;

            bool line = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (i == 11 && line == false)
                {
                    Console.SetCursorPosition(0, y + i);
                    Console.Write("------------------------------------------------");
                    line = true;
                    y++;
                    i--;
                }
                else
                {
                    x = 0;
                    if (i == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (i < club.tactics.defenders + 1)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (i < club.tactics.defenders + club.tactics.midfielders + 1)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (i < club.tactics.defenders + club.tactics.midfielders + club.tactics.forwards + 1)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(players[i].nr + ".");
                    Console.ResetColor();
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(players[i].fSurname);
                    x += 17;
                    setColor(players[i].age, "wiek");
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(players[i].age);
                    x += 4;
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

                    Console.ResetColor();
                }
            }
        }

        protected override void selectOption()
        {
            if (match != null)
            {
                if (club == match.host)
                    Console.WriteLine("\nilość zmian: " + match.substitutesHost.Count);
                if (club == match.guest)
                    Console.WriteLine("\nilość zmian: " + match.substitutesGuest.Count);
            }
            if (nr1 == -1)
                Console.Write("\n\n" + Text.toMakeSubstitution);
            else if (nr2 == -1)
                Console.Write("\n\n" + Text.writeNrOf2Player);

            selectedOption = Console.ReadLine();
            if (selectedOption == "q")
                Program.isRunning = false;
            if (int.TryParse(selectedOption, out selectedNumber))
            {
                if (selectedNumber == 0)
                    isRunning = false;
                else if (nr1 == -1 && selectedNumber > 0 && selectedNumber <= players.Count)
                    nr1 = selectedNumber - 1;
                else if (nr1 >= 0 && nr1 <= 25 &&
                    selectedNumber > 0 && selectedNumber <= players.Count)
                {
                    if (match == null || (match.substitutesHost.Count < 3))
                    {
                        nr2 = selectedNumber - 1;

                        temp = players[nr1];
                        players[nr1] = players[nr2];
                        players[nr2] = temp;

                        if (match != null)
                            match.substitutesHost.Add(new Substitution(match.minute, players[nr2], players[nr1]));

                        nr1 = -1;
                        nr2 = -1;
                    }
                }
            }

            club.squad.setNumbers();
            club.squad.updateFirst11();
            club.calculateSkills();
        }

        Club club;
        List<Player> players;
        Player temp;
        int nr1;
        int nr2;
        Match match;

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

        Pitch pitch;
    }
}
