using System.Collections.Generic;

namespace FootballManager
{
    class StatisticsPlayer
    {
        public Player player;
        List<Match> matches;
        public int position;
        public int playedMatches { get; private set; }
        //public int playedMinutes { get; private set; }
        public int goals { get; private set; }
        //int cleanSheets;

        public StatisticsPlayer(Player player)
        {
            this.player = player;
            matches = new List<Match>();
        }

        public void update(Match match)
        {
            bool playedMatch = false;

            if (player.clubId == match.host.id)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (player == match.starting11Host[i])
                        playedMatch = true;
                }

                if (!playedMatch)
                {
                    for (int i = 0; i < match.substitutesHost.Count; i++)
                    {
                        if (player == match.substitutesHost[i].incoming)
                            playedMatch = true;
                    }
                }

                if (playedMatch)
                {
                    for (int i = 0; i < match.goalsHost.Count; i++)
                    {
                        if (player == match.goalsHost[i].player)
                            goals++;
                    }
                }
            }

            else if (player.clubId == match.guest.id)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (player == match.starting11Guest[i])
                        playedMatch = true;
                }

                if (!playedMatch)
                {
                    for (int i = 0; i < match.substitutesGuest.Count; i++)
                    {
                        if (player == match.substitutesGuest[i].incoming)
                            playedMatch = true;
                    }
                }

                if (playedMatch)
                {
                    for (int i = 0; i < match.goalsGuest.Count; i++)
                    {
                        if (player == match.goalsGuest[i].player)
                            goals++;
                    }
                }
            }

            if (playedMatch)
            {
                playedMatches++;
                matches.Add(match);
            }
        }
    }
}
