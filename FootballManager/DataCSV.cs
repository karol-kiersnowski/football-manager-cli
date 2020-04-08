using System;
using System.Collections.Generic;
using System.IO;

namespace FootballManager
{
    class DataCSV : Data
    {
        public DataCSV() { }

        protected override void openConnection() { }

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

        protected override void loadClubs()
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

        protected override void loadManagers()
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

        protected override void loadPlayers()
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
    }
}
