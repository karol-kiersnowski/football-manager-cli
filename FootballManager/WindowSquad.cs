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

            //pitch = new Pitch(16, 16, 3);
        }
        
        protected override void draw()
        {
            int initialY = displayHeader();

            //System.Console.BackgroundColor = ConsoleColor.DarkGreen;
            //pitch.draw(64, initialY);
            //pitch.writeNumbers(64, initialY, club);
            //Console.ResetColor();

            //Console.SetCursorPosition(56, initialY + 17);
            //Console.WriteLine(Text.tot + " - " + Text.total);
            //Console.SetCursorPosition(56, initialY + 18);
            //Console.WriteLine(Text.gk + "  - " + Text.goalkeeping);
            //Console.SetCursorPosition(56, initialY + 19);
            //Console.WriteLine(Text.plm + " - " + Text.playmaking);
            //Console.SetCursorPosition(56, initialY + 20);
            //Console.WriteLine(Text.sho + " - " + Text.shooting);

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

            Console.SetCursorPosition(x, y);
            Console.Write(Text.age);
            x += 4;

            Console.SetCursorPosition(x, y);
            Console.Write(Text.tot);
            x += 6;

            Console.SetCursorPosition(x, y);
            Console.Write(Text.gk);
            x += 6;

            Console.SetCursorPosition(x, y);
            Console.Write("Def");
            x += 6;

            Console.SetCursorPosition(x, y);
            Console.Write(Text.plm);
            x += 6;

            Console.SetCursorPosition(x, y);
            Console.Write(Text.sho);
            x += 6;

            Console.SetCursorPosition(x, y);
            Console.Write(Text.sta);
            x += 6;

            Console.SetCursorPosition(x, y);
            Console.Write("Ldr");

            y += 1;

            for (int i = 0; i < players.Count; i++)
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
                else if (i >= 11)
                    Window.setColorGray();

                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].nr + ".");
                Console.ResetColor();
                x += 4;

                Console.SetCursorPosition(x, y + i);
                if (i == selectedNumber - 1)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                else
                    Console.ResetColor();
                Console.Write(players[i].fSurname);
                Console.ResetColor();
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
                Console.Write(players[i].age);
                x += 4;

                Console.SetCursorPosition(x, y + i);
                drawBlocks(players[i].skills);
                x += 6;

                Console.SetCursorPosition(x, y + i);
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
                drawBlocks(players[i].condition);
                x += 6;

                Console.SetCursorPosition(x, y + i);
                drawBlocks(players[i].leadership);
                //x += 5;


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

        protected override void selectOption()
        {
            if (match != null)
            {
                if (club == match.host)
                    Console.WriteLine("\nilość zmian: " + match.substitutesHost.Count);
                if (club == match.guest)
                    Console.WriteLine("\nilość zmian: " + match.substitutesGuest.Count);
            }

            Console.Write("\n\n" + Text.selection);

            //if (nr1 == -1)
            //    Console.Write("\n\n" + Text.toMakeSubstitution);
            //else if (nr2 == -1)
                //Console.Write("\n\n" + Text.writeNrOf2Player);

            selectedOption = Console.ReadLine();
            checkBasicOptions();
            if (int.TryParse(selectedOption, out selectedNumber))
            {
                if (selectedNumber == 0)
                    isRunning = false;
                else if (nr1 == -1 && selectedNumber > 0 && selectedNumber <= players.Count)
                    nr1 = selectedNumber - 1;
                else if (nr1 >= 0 && nr1 <= 25 && selectedNumber > 0 && selectedNumber <= players.Count)
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
                        selectedNumber = -1;
                    }
                }
            }

            club.squad.setNumbers();
            club.squad.updateFirst11();
            club.calculateSkills();
        }

        protected override void update() {}

        Club club;
        List<Player> players;
        Player temp;
        int nr1;
        int nr2;
        Match match;
    }
}
