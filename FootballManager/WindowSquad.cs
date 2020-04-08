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
            //club.manager.setTheBestSquad();
            club.squad.setNumbers();

            pitch = new Pitch(16, 24, 3);
        }
        
        protected override void draw()
        {
            int initialY = displayHeader();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            pitch.draw(52, initialY);
            pitch.writeNumbers(52, initialY, club);
            Console.ResetColor();

            Console.SetCursorPosition(52, initialY + 17);
            Console.WriteLine(Text.tot + " - " + Text.total);
            Console.SetCursorPosition(52, initialY + 18);
           Console.WriteLine(Text.gk + "  - " + Text.goalkeeping);
            Console.SetCursorPosition(52, initialY + 19);
           Console.WriteLine(Text.plm + " - " + Text.playmaking);
            Console.SetCursorPosition(52, initialY + 20);
            Console.WriteLine(Text.sho + " - " + Text.shooting);

            int x = 0;
            int y = initialY;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
           x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.player);
            x += 17;
            Console.SetCursorPosition(x, y);
            Console.Write("P");
            x += 2;
            //Console.SetCursorPosition(x, y);
            //Console.Write(Text.tot);            //x += 5;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.age);
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
            Console.Write("Ldr");

            y += 1;

            bool line = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (i == 11 && line == false)
                {
                    Console.SetCursorPosition(0, y + i);
                    Console.Write("-------------------------------------------------");
                    line = true;
                    y++;
                    i--;
                }
                else
                {
                    x = 0;
                    if (i == 0)
                        Window.setColor(Position.goalkeeper);
                    else if (i < club.tactics.defenders + 1)
                        Window.setColor(Position.defender);
                    else if (i < club.tactics.defenders + club.tactics.midfielders + 1)
                        Window.setColor(Position.midfielder);
                    else if (i < club.tactics.defenders + club.tactics.midfielders + club.tactics.forwards + 1)
                        Window.setColor(Position.forward);
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(players[i].nr + ".");
                    Console.ResetColor();
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(players[i].fSurname);
                    x += 17;
                    Console.SetCursorPosition(x, y + i);
                    if (players[i].bestPosition == Position.goalkeeper)
                    {
                        Window.setColor(Position.goalkeeper);
                        Console.Write(Text.goalkeeper);
                    }
                    else if (players[i].bestPosition == Position.defender)
                    {
                        Window.setColor(Position.defender);
                        Console.Write(Text.defender);
                    }
                    else if (players[i].bestPosition == Position.midfielder)
                    {
                        Window.setColor(Position.midfielder);
                        Console.Write(Text.midfielder);
                    }
                    else if (players[i].bestPosition == Position.forward)
                    {
                        Window.setColor(Position.forward);
                        Console.Write(Text.forward);
                    }
                    Console.ResetColor();
                    x += 2;

                    Console.SetCursorPosition(x, y + i);
                    setColorAge(players[i].age);
                    Console.Write(players[i].age);
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    setColor(players[i].goalkeeping);
                    Console.Write(players[i].goalkeeping);
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    setColor(players[i].defending);
                    Console.Write(players[i].defending);
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    setColor(players[i].playmaking);
                    Console.Write(players[i].playmaking);
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    setColor(players[i].shooting);
                    Console.Write(players[i].shooting);
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    setColor(players[i].condition);
                    Console.Write(players[i].condition);
                    x += 4;
                    Console.SetCursorPosition(x, y + i);
                    setColor(players[i].leadership);
                    Console.Write(players[i].leadership);
                    x += 4;


                    /*Console.SetCursorPosition(x, y + i);
                    drawBlocks(players[i].goalkeeping);
                    x += 6;
                    Console.SetCursorPosition(x, y + i);
                    drawBlocks(players[i].defending);
                    x += 6;
                    Console.SetCursorPosition(x, y + i);
                    drawBlocks(players[i].playmaking);
                    x += 6;
                    Console.SetCursorPosition(x, y + i);
                    drawBlocks(players[i].shooting);
                    x += 6;
                    Console.SetCursorPosition(x, y + i);
                    drawBlocks(players[i].condition);*/

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
            checkBasicOptions();
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

        void setColorAge(int age)
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
