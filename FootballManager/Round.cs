namespace FootballManager
{
    class Round
    {
        public string name { get; private set; }
        public Match[] matches { get; private set; }

        public Round(League league, int nrRound)
        {
            this.league = league;
            this.noRound = nrRound;
            name = Text.round + (nrRound + 1) + ".";
            matches = new Match[league.clubs.Length / 2];

            attributeMatches();
        }

        public void play()
        {
            for (int i = 0; i < matches.Length; i++)
                matches[i].playWithoutRelation();
        }

        public void updateStatistics() // UAKTUALNIENIE TABELI LIGOWEJ
        {
            for (int i = 0; i < matches.Length; i++)
            {
                for (int j = 0; j < league.clubs.Length; j++)
                {
                    if (league.table.clubs[j] == matches[i].host || league.table.clubs[j] == matches[i].guest)
                        league.table.clubs[j].statistics.update(matches[i]);
                }
            }
            league.table.sort();

            for (int i = 0; i < league.players.Count; i++)
            {
                for (int j = 0; j < matches.Length; j++)
                {
                    league.topScorers.players[i].statistics.update(matches[j]);
                }
            }

            league.topScorers.sort();

        }




        League league;
        int noRound;

        void attributeMatches()
        {
            if (noRound == 0)
            {
                for (int i = 0; i < matches.Length; i++)
                    matches[i] = new Match(league.clubs[i * 2], league.clubs[i * 2 + 1], Games.instance.season, noRound);
            }
            if (noRound == 1)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[2], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[3], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[4], league.clubs[6], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[5], league.clubs[7], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[8], league.clubs[10], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[9], league.clubs[11], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[12], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[13], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 2)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[3], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[2], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[4], league.clubs[7], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[5], league.clubs[6], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[8], league.clubs[11], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[9], league.clubs[10], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[12], league.clubs[15], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[13], league.clubs[14], Games.instance.season, noRound);
            }
            if (noRound == 3)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[4], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[5], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[6], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[7], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[8], league.clubs[12], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[9], league.clubs[13], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[10], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[11], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 4)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[5], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[6], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[7], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[8], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[9], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[10], league.clubs[13], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[11], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[12], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 5)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[6], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[7], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[8], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[9], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[10], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[11], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[12], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[13], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 6)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[7], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[8], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[9], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[10], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[11], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[12], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[13], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[14], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 7)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[8], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[9], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[10], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[11], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[12], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[13], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 8)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[9], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[10], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[11], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[12], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[13], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[14], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[15], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[8], Games.instance.season, noRound);
            }
            if (noRound == 9)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[10], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[11], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[12], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[13], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[14], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[15], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[8], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[9], Games.instance.season, noRound);
            }
            if (noRound == 10)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[11], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[12], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[13], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[14], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[15], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[8], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[9], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[10], Games.instance.season, noRound);
            }
            if (noRound == 11)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[12], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[13], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[14], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[15], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[8], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[9], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[10], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[11], Games.instance.season, noRound);
            }
            if (noRound == 12)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[13], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[14], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[15], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[8], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[9], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[10], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[11], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[12], Games.instance.season, noRound);
            }
            if (noRound == 13)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[14], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[15], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[8], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[9], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[10], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[11], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[12], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[13], Games.instance.season, noRound);
            }
            if (noRound == 14)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[15], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[8], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[9], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[10], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[11], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[12], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[13], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[14], Games.instance.season, noRound);
            }

            int k = 15;

            if (noRound == 0 + k)
            {
                for (int i = 0; i < matches.Length; i++)
                    matches[i] = new Match(league.clubs[i * 2], league.clubs[i * 2 + 1], Games.instance.season, noRound);
            }
            if (noRound == 1 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[2], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[3], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[4], league.clubs[6], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[5], league.clubs[7], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[8], league.clubs[10], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[9], league.clubs[11], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[12], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[13], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 2 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[3], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[2], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[4], league.clubs[7], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[5], league.clubs[6], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[8], league.clubs[11], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[9], league.clubs[10], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[12], league.clubs[15], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[13], league.clubs[14], Games.instance.season, noRound);
            }
            if (noRound == 3 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[4], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[5], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[6], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[7], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[8], league.clubs[12], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[9], league.clubs[13], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[10], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[11], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 4 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[5], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[6], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[7], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[8], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[9], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[10], league.clubs[13], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[11], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[12], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 5 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[6], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[7], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[8], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[9], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[10], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[11], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[12], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[13], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 6 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[7], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[8], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[9], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[10], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[11], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[12], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[13], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[14], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 7 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[8], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[9], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[10], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[11], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[12], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[13], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[14], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[15], Games.instance.season, noRound);
            }
            if (noRound == 8 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[9], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[10], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[11], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[12], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[13], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[14], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[15], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[8], Games.instance.season, noRound);
            }
            if (noRound == 9 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[10], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[11], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[12], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[13], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[14], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[15], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[8], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[9], Games.instance.season, noRound);
            }
            if (noRound == 10 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[11], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[12], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[13], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[14], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[15], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[8], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[9], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[10], Games.instance.season, noRound);
            }
            if (noRound == 11 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[12], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[13], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[14], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[15], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[8], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[9], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[10], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[11], Games.instance.season, noRound);
            }
            if (noRound == 12 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[13], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[14], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[15], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[8], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[9], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[10], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[11], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[12], Games.instance.season, noRound);
            }
            if (noRound == 13 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[14], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[15], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[8], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[9], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[10], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[11], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[12], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[13], Games.instance.season, noRound);
            }
            if (noRound == 14 + k)
            {
                matches[0] = new Match(league.clubs[0], league.clubs[15], Games.instance.season, noRound);
                matches[1] = new Match(league.clubs[1], league.clubs[8], Games.instance.season, noRound);
                matches[2] = new Match(league.clubs[2], league.clubs[9], Games.instance.season, noRound);
                matches[3] = new Match(league.clubs[3], league.clubs[10], Games.instance.season, noRound);
                matches[4] = new Match(league.clubs[4], league.clubs[11], Games.instance.season, noRound);
                matches[5] = new Match(league.clubs[5], league.clubs[12], Games.instance.season, noRound);
                matches[6] = new Match(league.clubs[6], league.clubs[13], Games.instance.season, noRound);
                matches[7] = new Match(league.clubs[7], league.clubs[14], Games.instance.season, noRound);
            }
        }
    }
}
