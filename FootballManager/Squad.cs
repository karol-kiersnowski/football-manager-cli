using System.Collections.Generic;

namespace FootballManager
{
    class Squad
    {
        public static readonly int maxPlayers = 21;
        public static readonly int minPlayers = 16;

        public List<Player> players { get; private set; }
        public Player[] first11 { get; private set; }
        public List<Player> goalkeepers { get; private set; }
        public List<Player> defenders { get; private set; }
        public List<Player> midfielders { get; private set; }
        public List<Player> forwards { get; private set; }

        public Squad(Club club)
        {
            this.club = club;

            players = new List<Player>();
            first11 = new Player[11];
            goalkeepers = new List<Player>();
            defenders = new List<Player>();
            midfielders = new List<Player>();
            forwards = new List<Player>();
        }

        public void setNumbers()
        {
            for (int i = 0; i < players.Count; i++)
                players[i].nr = i + 1;
        }

        public void sortByNumbers()
        {
            int n = players.Count;
            do
            {
                for (int i = 0; i < players.Count - 1; i++)
                {
                    if (players[i].nr > players[i + 1].nr)
                    {
                        Player tmp = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }

        public void updateFirst11()
        {
            first11 = new Player[11];
            for (int i = 0; i < 11; i++)
                first11[i] = players[i];
        }





        public void calculateHowManyPlayersForPositions()
        {
            if (goalkeepers.Count == 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].bestPosition == Position.goalkeeper)
                        goalkeepers.Add(players[i]);
                }

                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].bestPosition == Position.defender)
                        defenders.Add(players[i]);
                }
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].bestPosition == Position.midfielder)
                        midfielders.Add(players[i]);
                }
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].bestPosition == Position.forward)
                        forwards.Add(players[i]);
                }
            }
        }

        public void setTheBestPositions()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].goalkeeping > players[i].shooting)
                {
                    if (players[i].goalkeeping > players[i].defending)
                    {
                        if (players[i].goalkeeping > players[i].playmaking)
                            players[i].bestPosition = Position.goalkeeper;
                        else
                            players[i].bestPosition = Position.midfielder;
                    }
                    else
                    {
                        if (players[i].defending > players[i].playmaking)
                            players[i].bestPosition = Position.defender;
                        else
                            players[i].bestPosition = Position.midfielder;
                    }
                }
                else
                {
                    if (players[i].shooting > club.squad.players[i].defending)
                    {
                        if (players[i].shooting > players[i].playmaking)
                            players[i].bestPosition = Position.forward;
                        else
                            players[i].bestPosition = Position.midfielder;
                    }
                    else
                    {
                        if (players[i].defending > players[i].playmaking)
                            players[i].bestPosition = Position.defender;
                        else
                            players[i].bestPosition = Position.midfielder;
                    }
                }
            }
        }

        public void sort() // SORTOWANIE BABELKOWE PIŁKARZY ODWROTNE, ZEBY KOMPUTER NIE MIAL ZBYT DOBREGO SKLADU
        {
            int n = goalkeepers.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (goalkeepers[i].goalkeeping > goalkeepers[i + 1].goalkeeping)
                    {
                        Player tmp = goalkeepers[i];
                        goalkeepers[i] = goalkeepers[i + 1];
                        goalkeepers[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = defenders.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (defenders[i].defending > defenders[i + 1].defending)
                    {
                        Player tmp = defenders[i];
                        defenders[i] = defenders[i + 1];
                        defenders[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = midfielders.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (midfielders[i].playmaking > midfielders[i + 1].playmaking)
                    {
                        Player tmp = midfielders[i];
                        midfielders[i] = midfielders[i + 1];
                        midfielders[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = forwards.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (forwards[i].shooting > forwards[i + 1].shooting)
                    {
                        Player tmp = forwards[i];
                        forwards[i] = forwards[i + 1];
                        forwards[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }

        public void balancePlayersPositions()
        {
            while (defenders.Count < 4)
            {
                if (midfielders.Count > 4)
                {
                    int i = midfielders.Count - 1;
                    defenders.Add(midfielders[i]);
                    midfielders.RemoveAt(i);
                }
                else if (forwards.Count > 2)
                {
                    int i = forwards.Count - 1;
                    defenders.Add(forwards[i]);
                    forwards.RemoveAt(i);
                }
            }
            while (midfielders.Count < 4)
            {
                if (defenders.Count > 4)
                {
                    int i = defenders.Count - 1;
                    midfielders.Add(defenders[i]);
                    defenders.RemoveAt(i);
                }
                else if (forwards.Count > 2)
                {
                    int i = forwards.Count - 1;
                    midfielders.Add(forwards[i]);
                    forwards.RemoveAt(i);
                }
            }
            while (forwards.Count < 2)
            {
                if (defenders.Count > 4)
                {
                    int i = defenders.Count - 1;
                    forwards.Add(defenders[i]);
                    defenders.RemoveAt(i);
                }
                else if (midfielders.Count > 4)
                {
                    int i = midfielders.Count - 1;
                    forwards.Add(club.squad.midfielders[i]);
                    midfielders.RemoveAt(i);
                }
            }
        }

        public void setSquad()
        {
            players[0] = goalkeepers[0];
            players[1] = defenders[0];
            players[2] = defenders[1];
            players[3] = defenders[2];
            players[4] = defenders[3];
            players[5] = midfielders[0];
            players[6] = midfielders[1];
            players[7] = midfielders[2];
            players[8] = midfielders[3];
            players[9] = forwards[0];
            players[10] = forwards[1];

            int j = 11;
            for (int i = 1; i < goalkeepers.Count; i++)
            {
                players[j] = goalkeepers[i];
                j++;
            }
            for (int i = 4; i < club.squad.defenders.Count; i++)
            {
                players[j] = defenders[i];
                j++;
            }
            for (int i = 4; i < midfielders.Count; i++)
            {
                players[j] = midfielders[i];
                j++;
            }
            for (int i = 2; i < forwards.Count; i++)
            {
                players[j] = forwards[i];
                j++;
            }
        }

        Club club;


        //void sortuj1() // SORTOWANIE BABELKOWE PIŁKARZY UPROSZCZONE BEZ DRUGIEJ PETLI ORAZ Z WARUNKAMI, ZEBY KOMPUTER NIE MIAL ZBYT DOBREGO SKLADU
        //{
        //    obliczPoziomy();
        //    for (int i = 0; i < this.bramkarze.Count - 1; i++)
        //    {
        //        if (this.bramkarze[i].umBramkarskie < this.bramkarze[i + 1].umBramkarskie)
        //        {
        //            Pilkarz tmp = this.bramkarze[i];
        //            this.bramkarze[i] = this.bramkarze[i + 1];
        //            this.bramkarze[i + 1] = tmp;
        //        }
        //    }
        //    if (obrona <= 4)
        //    {
        //        for (int i = 0; i < this.obroncy.Count - 1; i++)
        //        {
        //            if (this.obroncy[i].defensywa < this.obroncy[i + 1].defensywa)
        //            {
        //                Pilkarz tmp = this.obroncy[i];
        //                this.obroncy[i] = this.obroncy[i + 1];
        //                this.obroncy[i + 1] = tmp;
        //            }
        //        }
        //    }
        //    if (pomoc <= 4)
        //    {
        //        for (int i = 0; i < this.pomocnicy.Count - 1; i++)
        //        {
        //            if (this.pomocnicy[i].rozgrywanie < this.pomocnicy[i + 1].rozgrywanie)
        //            {
        //                Pilkarz tmp = this.pomocnicy[i];
        //                this.pomocnicy[i] = this.pomocnicy[i + 1];
        //                this.pomocnicy[i + 1] = tmp;
        //            }
        //        }
        //    }
        //    if (atak <= 4)
        //    {
        //        for (int i = 0; i < this.napastnicy.Count - 1; i++)
        //        {
        //            if (this.napastnicy[i].skutecznosc < this.napastnicy[i + 1].skutecznosc)
        //            {
        //                Pilkarz tmp = this.napastnicy[i];
        //                this.napastnicy[i] = this.napastnicy[i + 1];
        //                this.napastnicy[i + 1] = tmp;
        //            }
        //        }
        //    }
        //}
        //void sortuj() // SORTOWANIE BABELKOWE PIŁKARZY NA POSZCZEGÓLNYCH POZYCJACH, ZEBY KOMPUTER MOGL USTALIC OPTYMALNY SKLAD
        //{
        //    int n = this.bramkarze.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.bramkarze[i].umBramkarskie < this.bramkarze[i + 1].umBramkarskie)
        //            {
        //                Pilkarz tmp = this.bramkarze[i];
        //                this.bramkarze[i] = this.bramkarze[i + 1];
        //                this.bramkarze[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);

        //    n = this.obroncy.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.obroncy[i].defensywa < this.obroncy[i + 1].defensywa)
        //            {
        //                Pilkarz tmp = this.obroncy[i];
        //                this.obroncy[i] = this.obroncy[i + 1];
        //                this.obroncy[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);

        //    n = this.pomocnicy.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.pomocnicy[i].rozgrywanie < this.pomocnicy[i + 1].rozgrywanie)
        //            {
        //                Pilkarz tmp = this.pomocnicy[i];
        //                this.pomocnicy[i] = this.pomocnicy[i + 1];
        //                this.pomocnicy[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);

        //    n = this.napastnicy.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.napastnicy[i].skutecznosc < this.napastnicy[i + 1].skutecznosc)
        //            {
        //                Pilkarz tmp = this.napastnicy[i];
        //                this.napastnicy[i] = this.napastnicy[i + 1];
        //                this.napastnicy[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);
        //}
    }
}
