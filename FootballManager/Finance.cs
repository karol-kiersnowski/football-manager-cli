namespace FootballManager
{
    class Finance
    {
        public Club club;
        public int money { get; private set; }
        public int moneyFromPreviousWeek { get; private set; }

        public int ingoing { get; private set; }
        public int tickets { get; private set; }
        public int sponsors { get; private set; }
        public int saleOfPlayers;

        public int outgoing { get; private set; }
        public int salaries { get; private set; }
        public int stadium { get; private set; }
        public int purchaseOfPlayers;

        public int balance { get; private set; }

        public Finance(Club club, int money)
        {
            this.club = club;
            this.money = money;
        }

        public void calculate()
        {
            moneyFromPreviousWeek = money;

            balance = 0;
            ingoing = 0;
            outgoing = 0;

            ingoing += saleOfPlayers;
            saleOfPlayers = 0;

            outgoing += purchaseOfPlayers;
            purchaseOfPlayers = 0;

            tickets = 70000;
            ingoing += tickets;

            sponsors = 50000;
            ingoing += sponsors;

            stadium = 10000;
            outgoing += stadium;

            salaries = 0;
            for (int i = 0; i < club.squad.players.Count; i++)
                salaries += club.squad.players[i].salary;
            outgoing += salaries;

            balance = ingoing - outgoing;

            money = moneyFromPreviousWeek + balance;
        }
    }
}
