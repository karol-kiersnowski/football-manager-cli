namespace FootballManager
{
    class StatisticsClub
    {
        //Liga liga;
        public Match[] matches { get; private set; }
        public Club club;
        public int position;
        public int played { get; private set; }
        public int won { get; private set; }
        public int drawn { get; private set; }
        public int lost { get; private set; }
        public int scoredGoals { get; private set; }
        public int lostGoals { get; private set; }
        public int bilanceGoals { get; private set; }
        public int points { get; private set; }

        //public StatisticsClub(Club club)
        //{
        //    this.club = club;
        //}

        public StatisticsClub(
            int miejsce,
            int iloscMeczow,
            int zwyciestwa,
            int remisy,
            int porazki,
            int goleZdobyte,
            int goleStracone,
            int goleRoznica,
            int punkty
            )
        {
            matches = new Match[30];
            this.position     = miejsce;
            this.played = iloscMeczow;
            this.won  = zwyciestwa;
            this.drawn      = remisy;
            this.lost     = porazki;
            this.scoredGoals = goleZdobyte;
            this.lostGoals = goleStracone;
            this.bilanceGoals = goleRoznica;
            this.points = punkty;
        }

        public void update(Match mecz)
        {
            played++;
            if (club == mecz.host)
            {
                if (mecz.pointsHost == 3) { points += 3; won++; }
                if (mecz.pointsHost == 1) { points += 1; drawn++; }
                if (mecz.pointsHost == 0) { points += 0; lost++; }
                scoredGoals += mecz.goalsHost.Count;
                lostGoals += mecz.goalsGuest.Count;
                bilanceGoals += (mecz.goalsHost.Count - mecz.goalsGuest.Count);
            }
            else if (club == mecz.guest)
            {
                if (mecz.pointsGuest == 3) { points += 3; won++; }
                if (mecz.pointsGuest == 1) { points += 1; drawn++; }
                if (mecz.pointsGuest == 0) { points += 0; lost++; }
                scoredGoals += mecz.goalsGuest.Count;
                lostGoals += mecz.goalsHost.Count;
                bilanceGoals += (mecz.goalsGuest.Count - mecz.goalsHost.Count);
            }
        }

        public void clear()
        {
            position = 0;
            played = 0;
            won = 0;
            drawn = 0;
            lost = 0;
            scoredGoals = 0;
            lostGoals = 0;
            bilanceGoals = 0;
            points = 0;
        }
    }
}
