namespace FootballManager
{
    public enum Position { goalkeeper, defender, midfielder, forward }

    class Player
    {
        public StatisticsPlayer statistics { get; private set; }

        public Position bestPosition;
        //public char cPosition;
        public bool isForSale;
        public int clubId;
        //Club club;
        public int id { get; private set; }
        public int nr;
        public string fullName { get; private set; }
        public string fSurname { get; private set; }
        public string forename { get; private set; }
        public string surname { get; private set; }
        public int yearOfBirth { get; private set; }
        public int age { get; private set; }

        public int skills { get; private set; }
        public int goalkeeping { get; private set; }
        public int defending { get; private set; }
        public int playmaking { get; private set; }
        public int shooting { get; private set; }
        public int condition { get; private set; }
        public int leadership { get; private set; }

        public int value { get; private set; }
        public int salary { get; private set; }
        //int matches;
        //int minutes;
        //int goals;

        //Mecz[] terminarz;

        public Player(
            int id,
            string forename,
            string surname,
            int yearOfBirth,
            int club,
            int nr,
            int value,
            int salary,
            int skills,
            int goalkeeping,
            int defending,
            int playmaking,
            int shooting,
            int condition,
            int leadership
            )
        {
            statistics = new StatisticsPlayer(this);

            this.id = id;
            this.forename = forename;
            this.surname = surname;
            fullName = forename + " " + surname;
            fSurname = forename[0] + ". " + surname;
            this.yearOfBirth = yearOfBirth;
            age = 2015 - yearOfBirth;
            this.clubId = club;
            this.nr = nr;

            this.skills = skills;
            this.goalkeeping = goalkeeping;
            this.defending = defending;
            this.playmaking = playmaking;
            this.shooting = shooting;
            this.condition = condition;
            this.leadership = leadership;

            this.value = value;
            this.salary = salary;
        }

        //public void uaktualnijStatystyki(Mecz mecz)
        //{
        //    Klub druzyna;
        //    if (mecz.gospodarz.id == klub || mecz.gosc.id == klub)
        //    {
        //        if (mecz.gospodarz.id == klub) druzyna = mecz.gospodarz;
        //        if (mecz.gosc.id == klub) druzyna = mecz.gosc;

        //        for (int i = 0; i < 11; i++)
        //        {
        //            if (mecz.gospodarz11[i] == this)
        //                mecze++;
        //        }
        //    }
        //}
    }
}