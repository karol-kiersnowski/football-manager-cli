namespace FootballManager
{
    class Club
    {
        public Manager manager;
        public Squad squad { get; private set; }
        public Tactics tactics { get; private set; }
        public Finance finance { get; private set; }
        public Stadium stadium { get; private set; }
        public StatisticsClub statistics { get; private set; }

        public int id { get; private set; }
        public int ordinalNr { get; private set; }
        public string fullName { get; private set; }
        public string name { get; private set; }
        public string city { get; private set; }
        public string league { get; private set; }

        public int total { get; private set; }
        public int attack { get; private set; }
        public int middle { get; private set; }
        public int defense { get; private set; }

        public Club(
            int id,
            int lp,
            string name,
            string city,
            string league,
            int money,
            Tactics tactics,
            StatisticsClub statistics)
        {
            this.id = id;
            this.ordinalNr = lp;
            this.name = name;
            this.city = city;
            fullName = name + " " + city;
            this.league = league;

            this.tactics = tactics;
            this.statistics = statistics;
            this.statistics.club = this;

            squad = new Squad(this);
            stadium = new Stadium(this, 4000);
            finance = new Finance(this, money);
        }

        public void calculateSkills()
        {
            total = 0;
            attack = 0;
            middle = 0;
            defense = 0;

            // OBLICZANIE POZIOMU OBRONY
            int tym = 0;
            int tymPoziom = 0;
            int k = 1;
            int n = 1 + tactics.defenders;
            for (int i = k; i < n; i++)
            {
                if (i < squad.players.Count)
                    tym += squad.players[i].defending;
            }
            tym += squad.players[0].goalkeeping;
            defense = tym / (tactics.defenders + 1);
            tymPoziom += tym;

            // OBLICZANIE POZIOMU POMOCY
            k = 1 + tactics.defenders;
            n = 1 + tactics.defenders + tactics.midfielders;
            tym = 0;
            for (int i = k; i < n; i++)
            {
                if (i < squad.players.Count)
                    tym += squad.players[i].playmaking;
            }
            middle = tym / tactics.midfielders;
            tymPoziom += tym;

            // OBLICZANIE POZIOMU ATAKU
            k = 1 + tactics.defenders + tactics.midfielders;
            n = 1 + tactics.defenders + tactics.midfielders + tactics.forwards;
            tym = 0;
            for (int i = k; i < n; i++)
            {
                if (i < squad.players.Count)
                    tym += squad.players[i].shooting;
            }
            attack = tym / tactics.forwards;
            tymPoziom += tym;

            // OBLICZANIE POZIOMU DRUZYNY
            for (int i = 0; i < squad.players.Count; i++)
                tym += squad.players[i].skills;
            total = tym / squad.players.Count;
            //poziom = tymPoziom / 11;


            // OBLICZANIE POZIOMU KONDYCJI
            k = 1 + tactics.defenders;
            n = 1 + tactics.defenders + tactics.midfielders;
            tym = 0;
            for (int i = k; i < n; i++)
            {
                if (i < squad.players.Count)
                    tym += squad.players[i].condition;
            }
            int kondycjaPomocnikow = tym / tactics.midfielders;

            if (tactics.pressing == "bardzo słaby")
                middle -= 3;
            if (tactics.pressing == "słaby")
                middle -= 1;
            if (tactics.pressing == "mocny")
            {
                if (kondycjaPomocnikow >  50) middle += 3;
                if (kondycjaPomocnikow <= 50) middle -= 3;
            }
            if (tactics.pressing == "bardzo mocny")
            {
                if (kondycjaPomocnikow >  70) middle += 5;
                if (kondycjaPomocnikow <= 70) middle -= 5;
            }



            if (tactics.posture == "bardzo ofensywne") { attack += 10; defense -= 10; }
            if (tactics.posture == "ofensywne") { attack += 5; defense -= 5; }
            if (tactics.posture == "defensywne") { attack -= 5; defense += 5; }
            if (tactics.posture == "bardzo defensywne") { attack -= 10; defense += 10; }

            if (tactics.agression == "bardzo słaby") defense -= 5;
            if (tactics.agression == "słaby") defense -= 2;
            if (tactics.agression == "mocny") defense += 2;
            if (tactics.agression == "bardzo mocny") defense += 5;

            if (squad.players[tactics.captain].leadership >=  0 && squad.players[tactics.captain].leadership < 10) middle -= 5;
            if (squad.players[tactics.captain].leadership >= 10 && squad.players[tactics.captain].leadership < 20) middle -= 4;
            if (squad.players[tactics.captain].leadership >= 20 && squad.players[tactics.captain].leadership < 30) middle -= 3;
            if (squad.players[tactics.captain].leadership >= 30 && squad.players[tactics.captain].leadership < 40) middle -= 2;
            if (squad.players[tactics.captain].leadership >= 40 && squad.players[tactics.captain].leadership < 50) middle -= 1;
            if (squad.players[tactics.captain].leadership >= 50 && squad.players[tactics.captain].leadership < 60) middle += 1;
            if (squad.players[tactics.captain].leadership >= 60 && squad.players[tactics.captain].leadership < 70) middle += 2;
            if (squad.players[tactics.captain].leadership >= 70 && squad.players[tactics.captain].leadership < 80) middle += 3;
            if (squad.players[tactics.captain].leadership >= 80 && squad.players[tactics.captain].leadership < 90) middle += 4;
            if (squad.players[tactics.captain].leadership >= 90 && squad.players[tactics.captain].leadership < 100) middle += 5;


            if (attack <= 1) attack = 1;
            if (middle <= 1) middle = 1;
            if (defense <= 1) defense = 1;
            if (attack > 99) attack = 99;
            if (middle > 99) middle = 99;
            if (defense > 99) defense = 99;
        }
    }
}
