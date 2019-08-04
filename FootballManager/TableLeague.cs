namespace FootballManager
{
    class TableLeague
    {
        public Club[] clubs;

        public TableLeague(Club[] kluby)
        {
            this.clubs = new Club[kluby.Length];

            for (int i = 0; i < kluby.Length; i++)
                this.clubs[i] = kluby[i];
            for (int i = 0; i < kluby.Length; i++)
                kluby[i].statistics.position = i + 1;
        }

        public void clear()
        {
            for (int i = 0; i < clubs.Length; i++)
                clubs[i].statistics.clear();
        }

        public void sort()
        {
            int n = clubs.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (clubs[i].statistics.points < clubs[i + 1].statistics.points)
                    {
                        Club tmp = clubs[i];
                        clubs[i] = clubs[i + 1];
                        clubs[i + 1] = tmp;
                    }
                    else if (clubs[i].statistics.points == clubs[i + 1].statistics.points)
                    {
                        if (clubs[i].statistics.bilanceGoals < clubs[i + 1].statistics.bilanceGoals)
                        {
                            Club tmp = clubs[i];
                            clubs[i] = clubs[i + 1];
                            clubs[i + 1] = tmp;
                        }
                    }
                }
                n--;
            }
            while (n > 1);

            for (int i = 0; i < clubs.Length; i++)
            {
                clubs[i].statistics.position = i + 1;
            }
        }
    }
}
