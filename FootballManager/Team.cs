using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballManager
{
    abstract class Team
    {
        public Squad squad { get; private set; }
        public Tactics tactics { get; private set; }
        public Stadium stadium { get; private set; }

        public int id { get; private set; }
        public int ordinalNr { get; private set; }
        public string fullName { get; private set; }
        public string name { get; private set; }


        public int total { get; private set; }
        public int attack { get; private set; }
        public int middle { get; private set; }
        public int defense { get; private set; }
    }
}
