using System.IO;

namespace FootballManager
{
    class DataCSV : Data
    {
        public DataCSV() { }

        StreamReader reader;

        int getRowsCount(string fileName)
        {
            int rowsCount = 0;
            using (reader = new StreamReader(fileName))
            {
                while (reader.ReadLine() != null)
                {
                    rowsCount++;
                }
            }
            return rowsCount - 1;
        }

        protected override void initiate() { }

        protected override void loadClubs()
        {
            string fileName = "data/clubs.csv";
            clubs = new Club[getRowsCount(fileName)];
            reader = new StreamReader(fileName);

            // READS THE HEADER
            reader.ReadLine();
            // READS ROWS
            for (int i = 0; i < clubs.Length; i++)
            {
                string[] cols = reader.ReadLine().Split(',');

                clubs[i] = new Club(
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
                );
            }
        }

        protected override void loadManagers()
        {
            string fileName = "data/managers.csv";
            managers = new Manager[getRowsCount(fileName)];

            reader = new StreamReader(fileName);
            reader.ReadLine();
            for (int i = 0; i < managers.Length; i++)
            {
                string[] cols = reader.ReadLine().Split(',');

                managers[i] = new Manager(
                    int.Parse(cols[0]),
                    cols[1],
                    cols[2],
                    int.Parse(cols[3]),
                    int.Parse(cols[4]),
                    int.Parse(cols[5])
                );
            }
        }

        protected override void loadPlayers()
        {
            string fileName = "data/players.csv";
            players = new Player[getRowsCount(fileName)];

            reader = new StreamReader(fileName);
            reader.ReadLine();
            for (int i = 0; i < players.Length; i++)
            {
                string[] cols = reader.ReadLine().Split(',');

                players[i] = new Player(
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
                );
            }
        }
    }
}
