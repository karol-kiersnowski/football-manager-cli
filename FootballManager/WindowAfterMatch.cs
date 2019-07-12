using System;

namespace FootballManager
{
    class WindowAfterMatch : Window
    {
        public WindowAfterMatch(string menu, Match match)
        {
            this.match = match;
            this.menu = menu + " >> " + match.host.fullName + " - " + match.guest.fullName;
        }

        protected override void draw()
        {
            displayHeader();
            displayStatistics(0, 6);
            displaySquads(0, 10);
            displayEvents(0, 23);
        }

        protected override void selectOption()
        {
            Console.ReadKey();
            isRunning = false;
        }

        Match match;

        void displayStatistics(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("{0,-22} {1,-5} {2,22}",
                match.host.fullName, match.result, match.guest.fullName);
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("{0,-16} {1,-16} {2,17}",
                match.ballPossessionHost + "%", Text.ballPossession, match.ballPossessionGuest + "%");
            y++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("{0,-16} {1,-16} {2,16}",
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

            for (int i = 0; i < match.eventsHost.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (match.eventsHost[i] is Goal)
                {
                    Goal goal = (Goal)match.eventsHost[i];
                    if (!goal.isFromPenalty)
                        Console.WriteLine(goal.minute + " " + goal.player.surname);
                    else if (goal.isFromPenalty)
                        Console.WriteLine(goal.minute + " (k)" + goal.player.surname);
                }
                else if (match.eventsHost[i] is PenaltyNoGoal)
                {
                    PenaltyNoGoal penalty = (PenaltyNoGoal)match.eventsHost[i];
                    Console.WriteLine(penalty.minute + " " + penalty.player.surname + " (/k)");
                }
            }

            for (int i = 0; i < match.eventsGuest.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (match.eventsGuest[i] is Goal)
                {
                    Goal goal = (Goal)match.eventsGuest[i];
                    if (!goal.isFromPenalty)
                        Console.WriteLine(goal.minute + " " + goal.player.surname);
                    else if (goal.isFromPenalty)
                        Console.WriteLine(goal.minute + " (k)" + goal.player.surname);
                }
                else if (match.eventsGuest[i] is PenaltyNoGoal)
                {
                    PenaltyNoGoal penalty = (PenaltyNoGoal)match.eventsGuest[i];
                    Console.WriteLine(penalty.minute + " " + penalty.player.surname + " (/k)");
                }
            }
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
            //    Console.SetCursorPosition(20, y + i);

            //    for (int j = 0; j < match.eventsHost.Count; j++)
            //    {
            //        if (match.eventsHost[j].player == match.host.squad.players[i])
            //        {
            //            if (match.eventsHost[j].type == TypeOfEvent.goal)
            //                Console.Write(match.eventsHost[j].minute + " ");
            //            if (match.eventsHost[j].type == TypeOfEvent.goalFromPenalty)
            //                Console.Write(match.eventsHost[j].minute + " (k) ");
            //            if (match.eventsHost[j].type == TypeOfEvent.karnyBezGola)
            //                Console.Write(match.eventsHost[j].minute + " (/k) ");
            //        }
            //    }
            //}

            //for (int i = 0; i < 11; i++)
            //{
            //    Console.SetCursorPosition(x + 30, y + i);
            //    Console.Write(match.guest.squad.players[i].nr + ". " + match.guest.squad.players[i].surname);

            //    for (int j = 0; j < match.eventsGuest.Count; j++)
            //    {
            //        if (match.eventsGuest[j].player == match.guest.squad.players[i])
            //        {
            //            Console.SetCursorPosition(54, y + i);
            //            if (match.eventsGuest[j].type == TypeOfEvent.goal)
            //                Console.Write(match.eventsGuest[j].minute + " ");
            //            if (match.eventsGuest[j].type == TypeOfEvent.goalFromPenalty)
            //                Console.Write(match.eventsGuest[j].minute + " (k) ");
            //            if (match.eventsGuest[j].type == TypeOfEvent.karnyBezGola)
            //                Console.Write(match.eventsGuest[j].minute + " (/k) ");
            //        }
            //    }
            //}
        }

        protected override void update()
        {
            
        }
    }
}
