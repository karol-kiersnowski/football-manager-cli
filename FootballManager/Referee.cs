using System;

namespace FootballManager
{
    class Referee
    {
        public int id { get; private set; }
        public string fullName { get; private set; }
        public string forename { get; private set; }
        public string surname { get; private set; }
        public int yearOfBirth { get; private set; }


        public Referee(int id, string forename, string surname, int yearOfBirth, int skills)
        {
            this.id = id;
            this.forename = forename;
            this.surname = surname;
            fullName = forename + " " + surname;
            this.yearOfBirth = yearOfBirth;
        }

        public void startMatch()
        {

        }

        public void showYellowCard()
        {

        }
    }
}
