using System;
using System.Data;
using System.Data.OleDb;

namespace FootballManager
{
    class Generator
    {
        public Generator()
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=..\..\..\generator.accdb;";
                connection.Open();

                command = new OleDbCommand("SELECT COUNT(*) FROM Imie", connection);
                forenames = new string[(int)command.ExecuteScalar()];
                command = new OleDbCommand("SELECT COUNT(*) FROM Nazwisko", connection);
                surnames = new string[(int)command.ExecuteScalar()];
                command = new OleDbCommand("SELECT COUNT(*) FROM NazwaKlubu", connection);
                namesOfClubs = new string[(int)command.ExecuteScalar()];
                command = new OleDbCommand("SELECT COUNT(*) FROM Miasto WHERE Popularnosc IN (1,2)", connection);
                cities = new string[(int)command.ExecuteScalar()];
                
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                isError = true;
            }
            if (isError == false)
            {
                generator = new Random();
                numberOfClubs = 32;
                numberOfPlayers = numberOfClubs * 21;
                clubs = new Club[numberOfClubs];
                managers = new Manager[numberOfClubs];
            }
        }

        public int generuj()
        {
            if (isError == false)
            {
                loadData();
                clearPreviousData();
                generateClubs();
                generateManagers();
                generatePlayers();
                return 0;
            }
            else
                return -1;
        }




        string[] forenames;
        string[] surnames;
        string[] namesOfClubs;
        string[] cities;
        int numberOfPlayers;
        int numberOfClubs;
        Club[] clubs;
        Manager[] managers;

        bool isError;
        Random generator;
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter adapter;
        DataSet data;

        void loadData()
        {
            try
            {
                connection.Open();

                // WCZYTYWANIE IMION
                command = new OleDbCommand("SELECT Imie FROM Imie ORDER BY Imie", connection);
                adapter = new OleDbDataAdapter(command);
                data = new DataSet();
                adapter.Fill(data, "Data");
                for (int i = 0; i < forenames.Length; i++)
                    forenames[i] = data.Tables["Data"].Rows[i]["Imie"].ToString();

                // WCZYTYWANIE NAZWISK
                command = new OleDbCommand("SELECT Nazwisko FROM Nazwisko ORDER BY Nazwisko", connection);
                adapter = new OleDbDataAdapter(command);
                data = new DataSet();
                adapter.Fill(data, "Data");
                for (int i = 0; i < surnames.Length; i++)
                    surnames[i] = data.Tables["Data"].Rows[i]["Nazwisko"].ToString();

                // WCZYTYWANIE MIAST
                command = new OleDbCommand("SELECT Miasto, Popularnosc FROM Miasto WHERE Popularnosc IN (1,2) ORDER BY Miasto", connection);
                adapter = new OleDbDataAdapter(command);
                data = new DataSet();
                adapter.Fill(data, "Data");
                for (int i = 0; i < cities.Length; i++)
                    cities[i] = data.Tables["Data"].Rows[i]["Miasto"].ToString();

                //WCZYTYWANIE NAZW KLUBOW
                command = new OleDbCommand("SELECT Nazwa FROM NazwaKlubu ORDER BY Nazwa", connection);
                adapter = new OleDbDataAdapter(command);
                data = new DataSet();
                adapter.Fill(data, "Data");
                for (int i = 0; i < namesOfClubs.Length; i++)
                    namesOfClubs[i] = data.Tables["Data"].Rows[i]["Nazwa"].ToString();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        void clearPreviousData()
        {
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
                                                Data Source=dane\baza danych.accdb;";
                connection.Open();
                command = new OleDbCommand("DELETE FROM Klub", connection);
                command.ExecuteNonQuery();
                command = new OleDbCommand("DELETE FROM Mecz", connection);
                command.ExecuteNonQuery();
                command = new OleDbCommand("DELETE FROM Menedzer", connection);
                command.ExecuteNonQuery();
                command = new OleDbCommand("DELETE FROM Pilkarz", connection);
                command.ExecuteNonQuery();
                command = new OleDbCommand("DELETE FROM StanGry", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        void generateManagers()
        {
            try
            {
                connection.Open();
                for (int i = 0; i < numberOfClubs; i++)
                {
                    int id = i + 1;
                    string imie = forenames[generator.Next(0, forenames.Length)];
                    string nazwisko = surnames[generator.Next(0, surnames.Length)];
                    int rokUrodzenia = generator.Next(1950, 1980);
                    int umiejetnosci = generator.Next(1, 100);
                    int klub = clubs[i].id;

                    command = new OleDbCommand("INSERT INTO Menedzer (Id, Imie, Nazwisko, RokUrodzenia, Klub, Umiejetnosci) " +
                        "values('" + id + "', '" + imie + "', '" + nazwisko + "', '" + rokUrodzenia + "', '" + klub + "', '" +
                        umiejetnosci + "')", connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        void generatePlayers()
        {

                connection.Open();

                for (int i = 0; i < numberOfPlayers; i++)
                {
                    int id = i + 1;
                    string imie = forenames[generator.Next(0, forenames.Length)];
                    string nazwisko = surnames[generator.Next(0, surnames.Length)];
                    int rokUrodzenia = generator.Next(1980, 1997);
                    int umBramkarskie = generator.Next(1, 100);
                    int defensywa = generator.Next(1, 100);
                    int rozgrywanie = generator.Next(1, 100);
                    int skutecznosc = generator.Next(1, 100);
                    int kondycja = generator.Next(30, 90);
                    int przywodztwo = generator.Next(30, 90);
                    int miejsce = 0;
                    int mecze = 0;
                    int gole = 0;

                    int umiejetnosci = (defensywa + rozgrywanie + skutecznosc + umBramkarskie) / 4;

                    int wartosc = umiejetnosci * 10000;
                    int pensja = umiejetnosci * 100;

                    int klub = -1;
                    int nr = 0;

                    for (int j = 0; j < numberOfClubs; j++)
                    {
                        if (clubs[j].squad.players.Count < clubs[j].squad.players.Capacity)
                        {
                            klub = clubs[j].id;
                            clubs[j].squad.players.Add(new Player(id, imie, nazwisko, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                            nr = clubs[j].squad.players.Count;
                            break;
                        }
                    }

                    command = new OleDbCommand("INSERT INTO Pilkarz (Id, Imie, Nazwisko, RokUrodzenia, Klub, Nr, Wartosc, Pensja, " +
                        "Suma, UmBramkarskie, Defensywa, Rozgrywanie, Skutecznosc, Kondycja, Przywodztwo, Miejsce, Mecze, Gole) " +
                        "values('" + id + "', '" + imie + "', '" + nazwisko + "', '" + rokUrodzenia + "', '" + klub + "', '" + nr + "', '" + wartosc + "', '" + pensja + "', '" +
                        umiejetnosci + "', '" + umBramkarskie + "', '" + defensywa + "', '" + rozgrywanie + "', '" + skutecznosc + "', '" +
                        kondycja + "', '" + przywodztwo + "', '" + miejsce + "', '" + mecze + "', '" + gole + "')", connection);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            
        }

        void generateClubs()
        {
            try
            {
                connection.Open();
                for (int i = 0; i < numberOfClubs; i++)
                {
                    int id = i + 1;
                    string nazwaKlubu = namesOfClubs[generator.Next(0, namesOfClubs.Length)];
                    string miasto = cities[generator.Next(0, cities.Length)];
                    string liga;
                    if (i < 16)
                        liga = "1. liga";
                    else
                        liga = "2. liga";
                    int pieniadze = generator.Next(1000000, 10000000);
                    string formacja = Tactics.formations[generator.Next(7)];
                    string ustawienie = Tactics.postures[generator.Next(5)];
                    string pressing = Tactics.levels[generator.Next(5)];
                    string agresja = Tactics.levels[generator.Next(5)];
                    int kapitan = generator.Next(0, 11);
                    int rzutyKarne = generator.Next(1, 11);
                    int staleFragmentyGry = generator.Next(1, 11);

                    clubs[i] = new Club(id, id, nazwaKlubu, miasto, liga, pieniadze,
                        new Tactics(formacja, ustawienie, pressing, agresja, kapitan, staleFragmentyGry),
                        new StatisticsClub(id, 0, 0, 0, 0, 0, 0, 0, 0));

                    clubs[i].squad.players.Capacity = generator.Next(16, 21);

                    command = new OleDbCommand("INSERT INTO Klub (Id, NazwaKlubu, Miasto, Liga, Pieniadze, " +
                        "Formacja, Ustawienie, Pressing, Agresja, Kapitan, StaleFragmenty, " +
                        "Miejsce, Mecze, Zwyciestwa, Remisy, Porazki, GoleZdobyte, GoleStracone, GoleRoznica, Punkty) " +
                        "values('" + id + "', '" + nazwaKlubu + "', '" + miasto + "', '" + liga + "', '" + pieniadze + "', '" +
                        formacja + "', '" + ustawienie + "', '" + pressing + "', '" + agresja + "', '" + kapitan + "', '" + staleFragmentyGry + "', '" +
                        0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "')", connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }
    }
}
