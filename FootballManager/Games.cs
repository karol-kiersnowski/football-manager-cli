using System.Collections.Generic;

namespace FootballManager
{
    class Games
    {
        public static Games instance { get; private set; }

        public bool isStarted { get; private set; }
        public static int year;
        public string season { get; private set; }
        public int week { get; private set; }

        CupWithGroupStage europeanCup;
        Cup polishCup;
        public League playerLeague;
        public League polishLeague1 { get; private set; }
        public League polishLeague2 { get; private set; }

        public Club playerClub { get; private set; }
        public List<Club> clubs { get; private set; }

        public List<Player> transferList { get; private set; }

        public Games(int Year, Club playerClub)
        {
            instance = this;

            this.playerClub = playerClub;
            if (playerClub != null) isStarted = true;
            if (playerClub == null) isStarted = false;
            year = Year;
            season = year + "/" + (year + 1);

            clubs = Database.instance.clubs;

            transferList = new List<Player>();

            for (int i = 0; i < clubs.Count; i++)
            {
                clubs[i].manager.setForSale();
            }

            List<Club> clubs1 = new List<Club>(16);
            List<Club> clubs2 = new List<Club>(16);

            for (int i = 0; i < clubs.Count; i++)
            {
                if (clubs[i].league == "1") clubs1.Add(clubs[i]);
                if (clubs[i].league == "2") clubs2.Add(clubs[i]);
            }

            europeanCup = new CupWithGroupStage("European Cup", clubs1.ToArray());
            polishCup = new Cup(Text.polishCup, clubs1.ToArray());

            polishLeague1 = new League(Text.polishLeague1, clubs1.ToArray());
            polishLeague2 = new League(Text.polishLeague2, clubs2.ToArray());

            if (isStarted)
            {
                for (int i = 0; i < polishLeague1.clubs.Length; i++)
                {
                    if (playerClub == polishLeague1.clubs[i])
                        playerLeague = polishLeague1;
                }

                if (playerLeague == null)
                    playerLeague = polishLeague2;

                checkPosition();
            }
            else if (!isStarted)
                playerLeague = polishLeague1;
        }

        public void goToNextWeek()
        {
            if (week < 30)
            {
                playerLeague.playRound();
                week++;

                for (int i = 0; i < playerLeague.clubs.Length; i++)
                    clubs[i].finance.calculate();

                checkPosition();
            }
        }

        public int checkPosition()
        {
            playerLeague.table.sort();
            for (int i = 0; i < playerLeague.clubs.Length; i++)
            {
                if (playerClub == playerLeague.table.clubs[i])
                    return playerLeague.table.clubs[i].statistics.position;
            }
            return -1;
        }

        public string check5PreviousMatches()
        {
            string forma = "";

            for (int j = 0; j < 5; j++)
            {
                if ((playerLeague.nrRound - 1 - j) >= 0)
                {
                    if (playerClub == playerClub.statistics.matches[playerLeague.nrRound - 1 - j].host)
                    {
                        if (playerClub.statistics.matches[playerLeague.nrRound - 1 - j].pointsHost == 3) forma += Text.won;
                        if (playerClub.statistics.matches[playerLeague.nrRound - 1 - j].pointsHost == 1) forma += Text.drawn;
                        if (playerClub.statistics.matches[playerLeague.nrRound - 1 - j].pointsHost == 0) forma += Text.lost;
                    }
                    if (playerClub == playerClub.statistics.matches[playerLeague.nrRound - 1 - j].guest)
                    {
                        if (playerClub.statistics.matches[playerLeague.nrRound - 1 - j].pointsGuest == 3) forma += Text.won;
                        if (playerClub.statistics.matches[playerLeague.nrRound - 1 - j].pointsGuest == 1) forma += Text.drawn;
                        if (playerClub.statistics.matches[playerLeague.nrRound - 1 - j].pointsGuest == 0) forma += Text.lost;
                    }
                }
            }
            return forma;
        }

        public Match checkPreviousMatch()
        {
            if (playerLeague.nrRound - 1 >= 0) return playerClub.statistics.matches[playerLeague.nrRound - 1];
            else return null;
        }

        public Match checkNextMatch()
        {
            if (playerLeague.nrRound < playerLeague.rounds.Length) return playerClub.statistics.matches[playerLeague.nrRound];
            else return null;
        }
    }
}
