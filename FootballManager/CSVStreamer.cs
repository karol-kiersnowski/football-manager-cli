using System;
using System.Collections.Generic;
using System.IO;

namespace FootballManager
{
    class CSVStreamer
    {
        public static CSVStreamer instance { get; private set; }

        public List<Club> clubs { get; private set; }
        public List<Club> clubsLeague1 { get; private set; }
        public List<Club> clubsLeague2 { get; private set; }
        public List<Manager> managers { get; private set; }
        public List<Player> players { get; private set; }

        public CSVStreamer()
        {
            instance = this;

            clubsLeague1 = new List<Club>(16);
            clubsLeague2 = new List<Club>(16);

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

        int getRowsCount(string fileName)
        {
            int rowsCount = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (reader.ReadLine() != null)
                {
                    rowsCount++;
                }
            }
            return rowsCount - 1;
        }

        void loadClubs()
        {
            string fileName = "data/clubs.csv";
            clubs = new List<Club>(getRowsCount(fileName));

            using (StreamReader reader = new StreamReader(fileName))
            {
                for (int i = 0; i < clubs.Capacity + 1; i++)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    if (i == 0)
                        continue;
                        
                    clubs.Add(new Club(
                        int.Parse(cols[0]),
                        int.Parse(cols[0]) + 1,
                        cols[1],
                        cols[2],
                        cols[3],
                        int.Parse(cols[4]),
                        new Tactics(
                            cols[5],
                            cols[6],
                            cols[7],
                            cols[8],
                            int.Parse(cols[9]),
                            int.Parse(cols[10])
                            ),
                        new StatisticsClub(
                            int.Parse(cols[11]),
                            int.Parse(cols[12]),
                            int.Parse(cols[13]),
                            int.Parse(cols[14]),
                            int.Parse(cols[15]),
                            int.Parse(cols[16]),
                            int.Parse(cols[17]),
                            int.Parse(cols[18]),
                            int.Parse(cols[19])
                            )
                        ));
                }
            }
        }

        void loadManagers()
        {
            string fileName = "data/managers.csv";
            managers = new List<Manager>(getRowsCount(fileName));

            using (StreamReader reader = new StreamReader(fileName))
            {
                for (int i = 0; i < managers.Capacity + 1; i++)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    if (i == 0)
                        continue;

                    managers.Add(new Manager(
                        int.Parse(cols[0]),
                        cols[1],
                        cols[2],
                        int.Parse(cols[3]),
                        int.Parse(cols[4]),
                        int.Parse(cols[5])
                    ));
                }
            }
        }

        void loadPlayers()
        {
            string fileName = "data/players.csv";
            players = new List<Player>(getRowsCount(fileName));

            using (StreamReader reader = new StreamReader(fileName))
            {
                for (int i = 0; i < players.Capacity + 1; i++)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    if (i == 0)
                        continue;

                    players.Add(new Player(
                        int.Parse(cols[0]),
                        cols[1],
                        cols[2],
                        int.Parse(cols[3]),
                        int.Parse(cols[4]),
                        int.Parse(cols[5]),
                        int.Parse(cols[6]),
                        int.Parse(cols[7]),
                        int.Parse(cols[8]),
                        int.Parse(cols[9]),
                        int.Parse(cols[10]),
                        int.Parse(cols[11]),
                        int.Parse(cols[12]),
                        int.Parse(cols[13]),
                        int.Parse(cols[14])
                    ));
                }
            }
        }





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
