namespace FootballManager
{
    class Stadium
    {
        public Stadium(Club club, int capacity)
        {
            this.club = club;
            this.capacity = capacity;
            name = club.fullName + " Stadion";
        }

        Club club;
        public string name { get; private set; }
        public int capacity { get; private set; }

        //List<Mecz> mecze;

        void modernize()
        {

        }
    }
}
