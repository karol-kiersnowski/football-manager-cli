using System;
using System.Collections.Generic;
using System.IO;

namespace FootballManager
{
    abstract class Data
    {
        public static Data instance { get; private set; }

        public Club[] clubs { get; protected set; }
        public Club[] clubsLeague1 { get; protected set; }
        public Club[] clubsLeague2 { get; protected set; }
        public Manager[] managers { get; protected set; }
        public Player[] players { get; protected set; }

        public Data()
        {
            instance = this;

            clubsLeague1 = new Club[16];
            clubsLeague2 = new Club[16];

            initiate();
            loadClubs();
            loadManagers();
            loadPlayers();
            assignClubsToLeagues();
            assignManagersToClubs();
            assignPlayersToClubs();

            for (int i = 0; i < clubs.Length; i++)
            {
                clubs[i].squad.sortByNumbers();
                clubs[i].squad.updateFirst11();
                clubs[i].calculateSkills();
            }
        }

        protected abstract void initiate();
        protected abstract void loadClubs();
        protected abstract void loadManagers();
        protected abstract void loadPlayers();




        void assignClubsToLeagues()
        {
            int l1 = 0;
            int l2 = 0;
            for (int i = 0; i < clubs.Length; i++)
            {
                if (clubs[i].league == "1")
                {
                    clubsLeague1[l1] = clubs[i];
                    l1++;
                } else if (clubs[i].league == "2")
                {
                    clubsLeague2[l2] = clubs[i];
                    l2++;
                }
            }
        }

        void assignManagersToClubs()
        {
            try
            {
                for (int j = 0; j < managers.Length; j++)
                {
                    for (int i = 0; i < clubs.Length; i++)
                    {
                        if (managers[j].clubId == clubs[i].id)
                        {
                            clubs[i].manager = managers[j];
                            managers[j].club = clubs[i];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Window.writeLine(e.Message);
            }
        }

        void assignPlayersToClubs()
        {
            try
            {
                for (int j = 0; j < players.Length; j++)
                {
                    for (int i = 0; i < clubs.Length; i++)
                    {
                        if (players[j].clubId == clubs[i].id)
                            clubs[i].squad.players.Add(players[j]);
                    }
                }
            }
            catch (Exception e)
            {
                Window.writeLine(e.Message);
            }
        }
    }
}
