namespace FootballManager
{
    public abstract class Event
    {
        public int minute { get; protected set; }
        public Event() { }
    }

    class Substitution : Event
    {
        public Player outgoing { get; private set; }
        public Player incoming { get; private set; }

        public Substitution(int minute, Player outgoing, Player incoming)
        {
            this.minute = minute;
            this.outgoing = outgoing;
            this.incoming = incoming;
        }
    }

    class PenaltyNoGoal : Event
    {
        public Player player { get; private set; }

        public PenaltyNoGoal(int minute, Player player)
        {
            this.minute = minute;
            this.player = player;
        }
    }

    class Goal : Event
    {
        public Player player { get; private set; }
        public bool isFromPenalty { get; private set; }

        public Goal(int minute, Player player, bool isFromPenalty)
        {
            this.minute = minute;
            this.player = player;
            this.isFromPenalty = isFromPenalty;
        }
    }

    /// <summary>
    /// 
    /// </summary>

    class Foul : Event
    {
        public Player player { get; private set; }

        public Foul(int minute, Player player)
        {
            this.minute = minute;
            this.player = player;
        }
    }

    class YellowCard : Event
    {
        public Player player { get; private set; }

        public YellowCard(int minute, Player player)
        {
            this.minute = minute;
            this.player = player;
        }
    }

    class RedCard : Event
    {
        public Player player { get; private set; }
        public bool is2ndYellowCard { get; private set; }

        public RedCard(int minute, Player player, bool is2ndYellowCard)
        {
            this.minute = minute;
            this.player = player;
            this.is2ndYellowCard = is2ndYellowCard;
        }
    }
}
