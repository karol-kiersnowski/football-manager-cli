using System;
using System.Timers;

namespace FootballManager
{
    class WindowMatch : Window
    {
        public WindowMatch(string menu, Match match)
        {
            this.match = match;
            this.menu = menu + " >> " + Text.match;
            options = new string[3];
            options[0] = Text.boost;
            options[1] = Text.squad;
            options[2] = Text.tactics;

            timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        protected override void draw()
        {
            
        }

        protected override void selectOption()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (match.state == StateOfMatch.finished)
            {
                timer.Close();
                timer.Dispose();
                isRunning = false;
            }
            if (pressedKey.Key == ConsoleKey.D1)
            {
                if (timer.Interval == 1000)
                    timer.Interval = 100;
                else if (timer.Interval == 100)
                    timer.Interval = 1000;
            }
            if (pressedKey.Key == ConsoleKey.D2 &&
                match.state != StateOfMatch.finished)
            {
                timer.Stop();
                new WindowSquad(menu, match.host, match).run();
                timer.Start();
            }
            if (pressedKey.Key == ConsoleKey.D3 &&
                match.state != StateOfMatch.finished)
            {
                timer.Stop();
                new WindowTactics(menu, match.host, match).run();
                timer.Start();
            }
        }





        Match match;
        int minute;
        Timer timer;

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (minute < 90)
            {
                match.playAction(minute);

                Console.Clear();
                Console.WriteLine(logo);
                Console.WriteLine(menu + "\n");
                if (timer.Interval == 1000)
                   Console.WriteLine("1. " + Text.boost);
                if (timer.Interval == 100)
                   Console.WriteLine("1. " + Text.slow);
                Console.WriteLine("2. " + Text.squad);
                Console.WriteLine("3. " + Text.tactics);

                displayStatistics(23, 6);
                displaySquadsAndEvents(0, 10);
                displaySubstitutes(0, 23);
                //displayRelation(0, 28);
                Console.WriteLine("Host attack: " + match.host.attack);
                Console.WriteLine("Guest attack: " + match.guest.attack);
                Console.WriteLine("Host attack: " + match.host.attack);
                Console.WriteLine("Guest attack: " + match.guest.attack);

                minute++;
            }
            else
            {
                timer.Close();
                timer.Dispose();
            }

            GC.Collect();
        }

        void displayStatistics(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("| {0,-22} {1,-5} {2,22}",
                match.host.fullName, match.result, match.guest.fullName);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("| {0,-1} {1,-16} {2,17}",
                match.ballPossessionHost + "%", Text.ballPossession, match.ballPossessionGuest + "%");
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("| {0,-16} {1,-16} {2,16}",
                match.attackForceHost + "%", Text.attackForce, match.attackForceGuest + "%");
        }

        void displaySquads(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(match.host.fullName);
            Console.SetCursorPosition(x + 20, y);
            Console.Write(match.guest.fullName);
            y++;

            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(match.host.squad.players[i].nr + ". " + match.host.squad.players[i].surname);
            }

            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(x + 20, y + i);
                Console.Write(match.host.squad.players[i].nr + ". " + match.host.squad.players[i].surname);
            }
        }

        void displayEvents(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(match.host.fullName);
            Console.SetCursorPosition(x + 20, y);
            Console.Write(match.guest.fullName);
            y++;

            //for (int i = 0; i < match.eventsHost.Count; i++)
            //{
            //    Console.SetCursorPosition(x, y + i);
            //    if (match.eventsHost[i].type == TypeOfEvent.goal)
            //        Console.WriteLine(match.eventsHost[i].minute + " " + match.eventsHost[i].player.surname);
            //    else if (match.eventsHost[i].type == TypeOfEvent.goalFromPenalty)
            //        Console.WriteLine(match.eventsHost[i].minute + " " + match.eventsHost[i].player.surname + " (k)");
            //    else if (match.eventsHost[i].type == TypeOfEvent.karnyBezGola)
            //        Console.WriteLine(match.eventsHost[i].minute + " " + match.eventsHost[i].player.surname + " (/k)");
            //}

            //for (int i = 0; i < match.eventsGuest.Count; i++)
            //{
            //    Console.SetCursorPosition(x + 20, y + i);
            //    if (match.eventsGuest[i].type == TypeOfEvent.goal)
            //        Console.WriteLine(match.eventsGuest[i].minute + " " + match.eventsGuest[i].player.surname);
            //    else if (match.eventsGuest[i].type == TypeOfEvent.goalFromPenalty)
            //        Console.WriteLine(match.eventsGuest[i].minute + " " + match.eventsGuest[i].player.surname + " (k)");
            //    else if (match.eventsGuest[i].type == TypeOfEvent.karnyBezGola)
            //        Console.WriteLine(match.eventsGuest[i].minute + " " + match.eventsGuest[i].player.surname + " (/k)");
            //}
        }

        void displaySquadsAndEvents(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(match.host.fullName);
            Console.SetCursorPosition(x + 30, y);
            Console.Write(match.guest.fullName);
            y++;

            //for (int i = 0; i < 11; i++)
            //{
            //    Console.SetCursorPosition(x, y + i);
            //    Console.Write(match.host.squad.players[i].nr + ". " + match.host.squad.players[i].surname);
            //    Console.SetCursorPosition(x + 17, y + i);

            //    for (int j = 0; j < match.eventsHost.Count; j++)
            //    {
            //        if (match.eventsHost[j].player == match.host.squad.players[i])
            //        {
            //            if (match.eventsHost[j].type == TypeOfEvent.goal)
            //                Console.Write(match.eventsHost[j].minute + " ");
            //            if (match.eventsHost[j].type == TypeOfEvent.goalFromPenalty)
            //                Console.Write(match.eventsHost[j].minute + "k ");
            //            if (match.eventsHost[j].type == TypeOfEvent.karnyBezGola)
            //                Console.Write(match.eventsHost[j].minute + "/k ");
            //        }
            //    }
            //}

            //for (int i = 0; i < 11; i++)
            //{
            //    Console.SetCursorPosition(x + 30, y + i);
            //    Console.Write(match.guest.squad.players[i].nr + ". " + match.guest.squad.players[i].surname);
            //    Console.SetCursorPosition(x + 30 + 17, y + i);

            //    for (int j = 0; j < match.eventsGuest.Count; j++)
            //    {
            //        if (match.eventsGuest[j].player == match.guest.squad.players[i])
            //        {
            //            if (match.eventsGuest[j].type == TypeOfEvent.goal)
            //                Console.Write(match.eventsGuest[j].minute + " ");
            //            if (match.eventsGuest[j].type == TypeOfEvent.goalFromPenalty)
            //                Console.Write(match.eventsGuest[j].minute + "k ");
            //            if (match.eventsGuest[j].type == TypeOfEvent.karnyBezGola)
            //                Console.Write(match.eventsGuest[j].minute + "/k ");
            //        }
            //    }
            //}
        }

        void displaySubstitutes(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("Min");
            Console.SetCursorPosition(x + 4, y);
            Console.Write("Outgoing");
            Console.SetCursorPosition(x + 25, y);
            Console.Write("Incoming");
            y++;

            for (int i = 0; i < match.substitutesHost.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(match.substitutesHost[i].minute);
                Console.SetCursorPosition(x + 4, y + i);
                Console.Write(match.substitutesHost[i].outgoing.fSurname);
                Console.SetCursorPosition(x + 25, y + i);
                Console.Write(match.substitutesHost[i].incoming.fSurname);
            }
        }

        void displayRelation(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Text.minute + match.actions[minute].minute + "  |  ");
           if (match.actions[minute].ballPossession == EClub.host)
                Console.WriteLine(Text.ballIsPossessedBy + match.host.fullName);            if (match.actions[minute].ballPossession == EClub.guest)
                Console.WriteLine(Text.ballIsPossessedBy + match.guest.fullName);

            for (int i = 89; i >= 0; i--)
            {
                if (match.actions[i] != null)
                {
                    if (match.actions[i].comment != null)
                    {
                        Console.Write(match.actions[i].minute + "   ");
                        Console.WriteLine(match.actions[i].comment);
                    }
                }
            }
        }

        protected override void update()
        {
            
        }
    }
}
