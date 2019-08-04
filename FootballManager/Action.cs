namespace FootballManager
{
    enum EClub { host, guest }

    class Action
    {
        public string comment;
        public EClub ballPossession;
        public int id { get; private set; }
        public int minute { get; private set; }

        public Action(int id)
        {
            this.id = id;
            this.minute = id + 1;
        }
    }
}
