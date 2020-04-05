using System.Collections.Generic;

namespace FootballManager
{
    class Cup
    {
        public static readonly string[] rounds = {
            Text._1_8Final,
            Text._1_4Final,
            Text._1_2Final,
            Text.final,
            Text.finished
        };

        public string name { get; private set; }
        public Club[] clubs { get; private set; }
        int nrRound;
        public string nextRound { get; private set; }
        public List<Player> players { get; private set; }
        public TableTopScorers topScorers { get; private set; }

        Match[] _1_8Final;
        Match[] _1_4Final;
        Match[] _1_2Final;
        Match final;

        public Cup(string name, Club[] clubs)
        {
            this.name = name;
            this.clubs = clubs;

            nrRound = 0;
            nextRound = rounds[nrRound];

            players = new List<Player>(21 * clubs.Length);
            for (int i = 0; i < clubs.Length; i++)
            {
                for (int j = 0; j < clubs[i].squad.players.Count; j++)
                    players.Add(clubs[i].squad.players[j]);
            }

            topScorers = new TableTopScorers(players);

            _1_8Final = new Match[8];
            _1_4Final = new Match[4];
            _1_2Final = new Match[2];
        }

        public void playRound()
        {
            if (nextRound == Text._1_8Final)
            {
                for (int i = 0; i < 8; i++)
                {
                    _1_8Final[i] = new Match(clubs[i], clubs[i + 8], TypeOfMatch.cup);
                    _1_8Final[i].playWithoutRelation();
                }
                nrRound++;
            }

            if (nextRound == Text._1_4Final)
            {
                for (int i = 0; i < 4; i++)
                {
                    _1_4Final[i] = new Match(_1_8Final[i].winner, _1_8Final[i+ 4].winner, TypeOfMatch.cup);
                    _1_4Final[i].playWithoutRelation();
                }
                nrRound++;
            }

            if (nextRound == Text._1_2Final)
            {
                for (int i = 0; i < 2; i++)
                {
                    _1_2Final[i] = new Match(_1_4Final[i].winner, _1_4Final[i + 2].winner, TypeOfMatch.cup);
                    _1_2Final[i].playWithoutRelation();
                }
                nrRound++;
            }

            if (nextRound == Text.final)
            {
                final = new Match(_1_2Final[0].winner, _1_2Final[1].winner, TypeOfMatch.cup);
                final.playWithoutRelation();
                nrRound++;
            }

            nextRound = rounds[nrRound];
        }
    }
}
