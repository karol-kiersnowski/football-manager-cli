using System;
using System.Collections.Generic;

namespace FootballManager
{
    class WindowTactics : Window
    {
        public WindowTactics(string menu, Club club, Match match)
        {
            this.club = club;
            this.match = match;
            this.menu = menu + " >> " + Text.tactics;
            options = new string[6];
            options[0] = Text.formation;
            options[1] = Text.posture;
            options[2] = "Pressing";
            options[3] = Text.agression;
            options[4] = Text.captain;
            options[5] = Text.setPieces;

            players = club.squad.players;
            pitch = new Pitch(16, 24, 3);

            selected1Number = -1;
        }

        protected override void draw()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            pitch.draw(50, 6);
            pitch.writeNumbers(50, 6, club);
            Console.ResetColor();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(logo);
            Console.WriteLine(menu + "\n");

            string taktyka;

            for (int j = 0; j < options.Length; j++)
            {
                taktyka = club.tactics.formation;
                if (j == 0) taktyka = club.tactics.formation;
                if (j == 1) taktyka = club.tactics.posture;
                if (j == 2) taktyka = club.tactics.pressing;
                if (j == 3) taktyka = club.tactics.agression;
                if (j == 4) taktyka = club.squad.players[club.tactics.captain].nr + ". " +
                            club.squad.players[club.tactics.captain].fullName;
                if (j == 5) taktyka = club.squad.players[club.tactics.setPieces].nr + ". " +
                            club.squad.players[club.tactics.setPieces].fullName;

                if (selected1Number > -1)
                {
                    if (selectedNumber == j+1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("{0,-18} {1}", "   " + options[j], "| " + taktyka);
                        if (selectedNumber == 1)
                        {
                            for (int i = 0; i < Tactics.formations.Length; i++)
                                Console.WriteLine((i + 1) + ". " + Tactics.formations[i]);
                        }
                        if (selectedNumber == 2)
                        {
                            for (int i = 0; i < Tactics.postures.Length; i++)
                                Console.WriteLine((i + 1) + ". " + Tactics.postures[i]);
                        }
                        if (selectedNumber == 3)
                        {
                            for (int i = 0; i < Tactics.levels.Length; i++)
                                Console.WriteLine((i + 1) + ". " + Tactics.levels[i]);
                        }
                        if (selectedNumber == 4)
                        {
                            for (int i = 0; i < Tactics.levels.Length; i++)
                                Console.WriteLine((i + 1) + ". " + Tactics.levels[i]);
                        }
                        if (selectedNumber == 5)
                        {
                            for (int i = 0; i < 11; i++)
                                Console.WriteLine((i + 1) + ". " + club.squad.first11[i].fullName);
                        }
                        if (selectedNumber == 6)
                        {
                            for (int i = 1; i < 11; i++)
                                Console.WriteLine((i + 1) + ". " + club.squad.first11[i].fullName);
                        }
                        Console.WriteLine();
                    }
                    else
                        Console.WriteLine("{0,-18} {1}", "   " + options[j], "| " + taktyka);
                }
                else if (selected1Number == -1)
                    Console.WriteLine("{0,-18} {1}", (j + 1) + ". " + options[j], "| " + taktyka);
            }

            Console.WriteLine();
        }

        protected override void selectOption()
        {
            //Console.WriteLine("selected1Number: " + selected1Number);
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            if (selectedOption == "q") Program.isRunning = false;

            if (int.TryParse(selectedOption, out selectedNumber))
            {
                if (selected1Number > -1)
                {
                    if (selectedNumber == 0) selected1Number = -1;
                    if (selected1Number == 1)
                    {
                        for (int j = 1; j <= Tactics.formations.Length; j++)
                        {
                            if (selectedNumber == j)
                                club.tactics.setFormation(Tactics.formations[j - 1]);
                        }
                    }
                    else if (selected1Number == 2)
                    {
                        for (int j = 1; j <= Tactics.postures.Length; j++)
                        {
                            if (selectedNumber == j)
                                club.tactics.posture = Tactics.postures[j - 1];
                        }
                    }
                    else if (selected1Number == 3)
                    {
                        for (int j = 1; j <= Tactics.levels.Length; j++)
                        {
                            if (selectedNumber == j)
                                club.tactics.pressing = Tactics.levels[j - 1];
                        }
                    }
                    else if (selected1Number == 4)
                    {
                        for (int j = 1; j <= Tactics.levels.Length; j++)
                        {
                            if (selectedNumber == j)
                                club.tactics.agression = Tactics.levels[j - 1];
                        }
                    }
                    else if (selected1Number == 5)
                    {
                        for (int j = 1; j <= 11; j++)
                        {
                            if (selectedNumber == j)
                                club.tactics.captain = j - 1;
                        }
                    }
                    else if (selected1Number == 6)
                    {
                        for (int j = 2; j <= 11; j++)
                        {
                            if (selectedNumber == j)
                                club.tactics.setPieces = j - 1;
                        }
                    }
                    selected1Number = -1;
                }
                else if (selected1Number == -1)
                {
                    selected1Number = selectedNumber;
                    if (selectedNumber == 0) isRunning = false;
                }
            }
            else
                selected1Number = -1;

            club.calculateSkills();
        }

        protected override void update()
        {
            
        }

        int selected1Number;
        Club club;
        List<Player> players;
        Pitch pitch;
        Match match;
    }
}
