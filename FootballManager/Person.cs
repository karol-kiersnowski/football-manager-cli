using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballManager
{
    abstract class Person
    {
        public int id { get; private set; }
        public string fullName { get; private set; }
        public string fSurname { get; private set; }
        public string forename { get; private set; }
        public string surname { get; private set; }
        public int yearOfBirth { get; private set; }
        public int age { get; private set; }
    }
}
