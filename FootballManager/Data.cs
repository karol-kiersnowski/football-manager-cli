using System;
using System.Collections.Generic;
using System.IO;

namespace FootballManager
{
    abstract class Data
    {
        public static Data instance { get; private set; }

        public List<Club> clubs { get; protected set; }
        public List<Club> clubsLeague1 { get; protected set; }
        public List<Club> clubsLeague2 { get; protected set; }
        public List<Manager> managers { get; protected set; }
        public List<Player> players { get; protected set; }

        public Data()
        {
            instance = this;

            clubsLeague1 = new List<Club>(16);
            clubsLeague2 = new List<Club>(16);

            openConnection();
            loadClubs();
            loadManagers();
            loadPlayers();
            assignClubsToLeagues();
            assignManagersToClubs();
            assignPlayersToClubs();

            for (int i = 0; i < clubs.Count; i++)
            {
                clubs[i].squad.sortByNumbers();
                clubs[i].squad.updateFirst11();
                clubs[i].calculateSkills();
            }
        }

        protected abstract void openConnection();
        protected abstract void loadClubs();
        protected abstract void loadManagers();
        protected abstract void loadPlayers();




        void assignClubsToLeagues()
        {
            for (int i = 0; i < clubs.Count; i++)
            {
                if (clubs[i].league == "1")
                    clubsLeague1.Add(clubs[i]);
                else if (clubs[i].league == "2")
                    clubsLeague2.Add(clubs[i]);
            }
        }

        void assignManagersToClubs()
        {
            try
            {
                for (int j = 0; j < managers.Count; j++)
                {
                    for (int i = 0; i < clubs.Count; i++)
                    {
                        if (managers[j].clubId == clubs[i].id)
                        {
                            clubs[i].manager = managers[j];
                            managers[j].club = clubs[i];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Window.writeLine(e.Message);
            }
        }

        void assignPlayersToClubs()
        {
            try
            {
                for (int j = 0; j < players.Count; j++)
                {
                    for (int i = 0; i < clubs.Count; i++)
                    {
                        if (players[j].clubId == clubs[i].id)
                            clubs[i].squad.players.Add(players[j]);
                    }
                }
            }
            catch (Exception e)
            {
                Window.writeLine(e.Message);
            }
        }





































        void displayClubs()
        {
            int x = 0;
            int y = 3;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.name);
            x += 23;
            //Console.SetCursorPosition(x, y);
            //Console.Write(Text.total);
            //x += 7;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.attack);
            x += 7;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.middle);
            x += 7;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.defense);

            y += 1;


            for (int i = 0; i < clubs.Count; i++)
            {
                x = 0;
                Console.SetCursorPosition(x, y + i);
                Console.Write(i + 1 + ".");
                x += 4;
                Console.SetCursorPosition(x, y + i);
                Console.Write(clubs[i].fullName);
                x += 23;
                //Console.SetCursorPosition(x, y + i);
                //drawBlocks(clubs[i].total);
                //x += 7;
                Console.SetCursorPosition(x, y + i);
                Window.drawBlocks(clubs[i].attack);
                x += 7;
                Console.SetCursorPosition(x, y + i);
                Window.drawBlocks(clubs[i].middle);
                x += 7;
                Console.SetCursorPosition(x, y + i);
                Window.drawBlocks(clubs[i].defense);
            }

            Console.WriteLine("\n");
        }

        void displayManagers()
        {
            int x = 0;
            int y = 3;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.name);
            x += 23;

            y += 1;

            for (int i = 0; i < managers.Count; i++)
            {
                x = 0;
                Console.SetCursorPosition(x, y + i);
                Console.Write(managers[i].id + ".");
                x += 4;
                Console.SetCursorPosition(x, y + i);
                Console.Write(managers[i].fullName);
                x += 23;
            }

            Console.WriteLine("\n");
        }

        void displayPlayers()
        {
            int x = 0;
            int y = 3;
           Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
           Console.SetCursorPosition(x, y);
            Console.Write(Text.name);
            x += 23;

            y += 1;

            for (int i = 0; i < players.Count; i++)
            {
                x = 0;
                Console.SetCursorPosition(x, y + i);
                Console.Write(i + 1 + ".");
                x += 4;
                Console.SetCursorPosition(x, y + i);
                Console.Write(players[i].fullName);
                x += 23;
            }

            Console.WriteLine("\n");
        }
    }
}
