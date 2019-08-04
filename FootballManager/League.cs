using System.Collections.Generic;

namespace FootballManager
{
    class League
    {
        public string name { get; private set; }
        public Club[] clubs { get; private set; }
        public List<Player> players { get; private set; }
        public TableLeague table { get; private set; }
        public TableTopScorers topScorers { get; private set; }
        public int nrRound { get; private set; }
        public Round[] rounds { get; private set; }

        public League(string name, Club[] clubs)
        {
            this.name = name;
            this.clubs = clubs;

            players = new List<Player>(21 * clubs.Length);
            for (int i = 0; i < clubs.Length; i++)
            {
                for (int j = 0; j < clubs[i].squad.players.Count; j++)
                    players.Add(clubs[i].squad.players[j]);
            }

            table = new TableLeague(clubs);
            topScorers = new TableTopScorers(players);

            rounds = new Round[(clubs.Length - 1) * 2];
            for (int i = 0; i < rounds.Length; i++)
                rounds[i] = new Round(this, i);

            for (int k = 0; k < clubs.Length; k++)
            {
                for (int j = 0; j < rounds.Length; j++)
                {
                    for (int i = 0; i < rounds[0].matches.Length; i++)
                    {
                        if (clubs[k].fullName == rounds[j].matches[i].host.fullName || clubs[k].fullName == rounds[j].matches[i].guest.fullName)
                            clubs[k].statistics.matches[j] = rounds[j].matches[i];
                    }
                }
            }
        }

        public void playRound()
        {
            if (nrRound < rounds.Length)
            {
                rounds[nrRound].play();
                nrRound++;
            }
        }

        public void updateStatistics()
        {
            rounds[nrRound - 1].updateStatistics();
        }
    }
}
