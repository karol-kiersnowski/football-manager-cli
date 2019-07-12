using System;

namespace FootballManager
{
    class Manager
    {
        public Club club;
        public int id { get; private set; }
        public string fullName { get; private set; }
        public string forename { get; private set; }
        public string surname { get; private set; }
        public int yearOfBirth { get; private set; }
        public int clubId { get; private set; }

        public Manager(int id, string forename, string surname, int yearOfBirth, int club, int skills)
        {
            this.id = id;
            this.forename = forename;
            this.surname = surname;
            fullName = forename + " " + surname;
            this.yearOfBirth = yearOfBirth;
            this.clubId = club;
        }

        public void setForSale()
        {
            int ostatniPilkarz = club.squad.players.Count - 1;
            club.squad.players[ostatniPilkarz].isForSale = true;
            Games.instance.transferList.Add(club.squad.players[ostatniPilkarz]);
        }

        public void setForSale(Player pilkarz, int cena)
        {
            pilkarz.isForSale = true;
            Games.instance.transferList.Add(pilkarz);
        }

        public void proposeAContract()
        {

        }

        public void setTheBestSquad()
        {
            try
            {
                club.squad.setTheBestPositions();
                club.squad.calculateHowManyPlayersForPositions();
                club.squad.sort();
                club.squad.balancePlayersPositions();
                club.squad.setSquad();
            }
            catch (Exception e)
            {
                Window.displayMessage(e.Message);
            }
        }
    }
}
