using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SQLite;

namespace FootballManager
{
    class DataSQLite// : Data
    {
        public DataSQLite() { }

        /*SQLiteConnection connection;
        SQLiteCommand command;
        SQLiteDataAdapter adapter;
        DataSet dataSet;

        protected override void initiate()
        {
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=database.db";
                connection.Open();

                command = new SQLiteCommand("SELECT COUNT(*) FROM club", connection);
                clubs = new List<Club>(int.Parse(command.ExecuteScalar().ToString()));
                command = new SQLiteCommand("SELECT COUNT(*) FROM manager", connection);
                managers = new List<Manager>(int.Parse(command.ExecuteScalar().ToString()));
                command = new SQLiteCommand("SELECT COUNT(*) FROM player", connection);
                players = new List<Player>(int.Parse(command.ExecuteScalar().ToString()));

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Window.displayMessage(e.Message);
            }
        }

        protected override void loadClubs()
        {
            try
            {
                connection.Open();
                command = new SQLiteCommand("SELECT * FROM club ORDER BY name, city", connection);
                adapter = new SQLiteDataAdapter(command);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "data");

                for (int i = 0; i < clubs.Capacity; i++)
                {
                    clubs.Add(new Club(
                        int.Parse(dataSet.Tables["data"].Rows[i]["id"].ToString()),
                        i + 1,
                        dataSet.Tables["data"].Rows[i]["name"].ToString(),
                        dataSet.Tables["data"].Rows[i]["city"].ToString(),
                        dataSet.Tables["data"].Rows[i]["league"].ToString(),
                        int.Parse(dataSet.Tables["data"].Rows[i]["money"].ToString()),
                        new Tactics(
                            dataSet.Tables["data"].Rows[i]["formation"].ToString(),
                            dataSet.Tables["data"].Rows[i]["attitude"].ToString(),
                            dataSet.Tables["data"].Rows[i]["pressing"].ToString(),
                            dataSet.Tables["data"].Rows[i]["aggression"].ToString(),
                            int.Parse(dataSet.Tables["data"].Rows[i]["cpt"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["fk"].ToString())
                            ),
                        new StatisticsClub(
                            int.Parse(dataSet.Tables["data"].Rows[i]["position"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["played"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["won"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["drawn"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["lost"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["goalsFor"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["goalsAgainst"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["goalsDifference"].ToString()),
                            int.Parse(dataSet.Tables["data"].Rows[i]["points"].ToString())
                            )
                        ));
                }

                connection.Close();
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Window.displayMessage(e.Message);
            }
        }


        protected override void loadManagers()
        {
            try
            {
                connection.Open();
                command = new SQLiteCommand("SELECT * FROM manager ORDER BY id", connection);
                adapter = new SQLiteDataAdapter(command);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "data");

                for (int i = 0; i < managers.Capacity; i++)
                {
                    managers.Add(new Manager(
                        int.Parse(dataSet.Tables["data"].Rows[i]["id"].ToString()),
                        dataSet.Tables["data"].Rows[i]["firstName"].ToString(),
                        dataSet.Tables["data"].Rows[i]["lastName"].ToString(),
                        int.Parse(dataSet.Tables["data"].Rows[i]["yearOfBirth"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["clubId"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["skill"].ToString())
                        ));
                }

                connection.Close();
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Window.displayMessage(e.Message);
            }
        }


        protected override void loadPlayers()
        {
            try
            {
                connection.Open();

                command = new SQLiteCommand("SELECT * FROM player ORDER BY id", connection);
                adapter = new SQLiteDataAdapter(command);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "data");

                for (int i = 0; i < players.Capacity; i++)
                {
                    players.Add(new Player(
                        int.Parse(dataSet.Tables["data"].Rows[i]["id"].ToString()),
                        dataSet.Tables["data"].Rows[i]["firstName"].ToString(),
                        dataSet.Tables["data"].Rows[i]["lastName"].ToString(),
                        int.Parse(dataSet.Tables["data"].Rows[i]["yearOfBirth"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["clubId"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["no"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["value"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["salary"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["skill"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["goalkeeping"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["defensive"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["playmaking"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["shooting"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["condition"].ToString()),
                        int.Parse(dataSet.Tables["data"].Rows[i]["leadership"].ToString())
                    ));
                }

                connection.Close();
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Window.displayMessage(e.Message);
            }
        }*/
    }
}
