using System.Collections.Generic;

namespace FootballManager
{
    class TableTopScorers
    {
        public List<Player> players;

        public TableTopScorers(List<Player> players)
        {
            this.players = players;
        }

        public void sort()
        {
            int n = players.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (players[i].statistics.goals < players[i + 1].statistics.goals)
                    {
                        Player tmp = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = tmp;
                    }
                    else if (players[i].statistics.goals == players[i + 1].statistics.goals)
                    {
                        if (players[i].statistics.playedMatches > players[i + 1].statistics.playedMatches)
                        {
                            Player tmp = players[i];
                            players[i] = players[i + 1];
                            players[i + 1] = tmp;
                        }
                    }
                }
                n--;
            }
            while (n > 1);

            for (int i = 0; i < players.Count; i++)
            {
                players[i].statistics.position = i + 1;
            }
        }
    }
}
