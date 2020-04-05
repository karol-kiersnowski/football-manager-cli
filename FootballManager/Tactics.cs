namespace FootballManager
{
    class Tactics
    {
        public static readonly string[] formations = { "5-4-1", "5-3-2", "4-5-1", "4-4-2", "4-3-3", "3-5-2", "3-4-3" };
        public static readonly string[] postures = { Text.veryDefensive, Text.defensive,Text.neutral, Text.offensive, Text.veryOffensive };
        public static readonly string[] levels ={ Text.veryWeak, Text.weak, Text.normal, Text.strong, Text.veryStrong };

        //Klub druzyna;
        public string formation { get; private set; }
        public string posture;
        public string pressing;
        public string agression;
        public int captain;
        public int setPieces;

        public int defenders    { get; private set; }
        public int midfielders  { get; private set; }
        public int forwards     { get; private set; }

        public Tactics(
            //Klub druzyna,
            string formacja,
            string posture,
            string pressing,
            string agresja,
            int captain,
            int setPieces
            )
        {
            //this.druzyna = druzyna;
            this.formation =   formacja;
            this.posture = posture;
            this.pressing =   pressing;
            this.agression = agresja;
            this.captain =           captain;
            this.setPieces = setPieces;
            defenders = (int)char.GetNumericValue(formation[0]);
            midfielders = (int)char.GetNumericValue(formation[2]);
            forwards = (int)char.GetNumericValue(formation[4]);
        }

        public void setFormation(string formation)
        {
            this.formation = formation;
            defenders = (int)char.GetNumericValue(formation[0]);
            midfielders = (int)char.GetNumericValue(formation[2]);
            forwards = (int)char.GetNumericValue(formation[4]);
        }
    }
}
