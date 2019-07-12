using System;
using System.Collections.Generic;

namespace FootballManager
{
    enum TypeOfMatch { friendly, cup, league }
    enum StateOfMatch { notStarted, playedNow, finished }

    class Match
    {
        public Club winner; // USING IN CUPS MATCHES

        public TypeOfMatch type { get; private set; }
        public StateOfMatch state { get; private set; }
        public int minute { get; private set; }
        public Stadium stadium { get; private set; }
        public Club host { get; private set; }
        public Club guest { get; private set; }
        public string season { get; private set; }
        public int round { get; private set; }

        public string teams { get; private set; }
        public string result { get; private set; }
        public string teamsAndResult { get; private set; }
        public int pointsHost { get; private set; }
        public int pointsGuest { get; private set; }
        public int ballPossessionHost { get; private set; }
        public int ballPossessionGuest { get; private set; }
        public int numberOfActionsHost { get; private set; }
        public int numberOfActionsGuest { get; private set; }
        public int attackForceHost { get; private set; }
        public int attackForceGuest { get; private set; }

        public Action[] actions { get; private set; }
        public Player[] starting11Host { get; private set; }
        public Player[] starting11Guest { get; private set; }
        Player[] current11Host;
        Player[] current11Guest;
        public List<Event> eventsHost { get; private set; }
        public List<Event> eventsGuest { get; private set; }
        public List<Goal> goalsHost { get; private set; }
        public List<Goal> goalsGuest { get; private set; }
        public List<Substitution> substitutesHost { get; private set; }
        public List<Substitution> substitutesGuest { get; private set; }

        public Match(Club host, Club guest, TypeOfMatch type) : this(host, guest)
        {
            this.type = type;
            this.stadium = host.stadium;
        }

        public Match(Club host, Club guest, string season, int round)
            : this(host, guest) // LEAGUE MATCH
        {
            type = TypeOfMatch.league;
            if (round % 2 == 0)
            {
                this.host = host;
                this.guest = guest;
                stadium = host.stadium;
            }
            else if (round % 2 == 1)
            {
                this.host = guest;
                this.guest = host;
                stadium = this.host.stadium;
            }

            this.season = season;
            this.round = round + 1;
        }

        Match(Club host, Club guest)
        {
            this.host = host;
            this.guest = guest;
            state = StateOfMatch.notStarted;
            actions = new Action[90];
            starting11Host = new Player[11];
            starting11Guest = new Player[11];
            current11Host = new Player[11];
            current11Guest = new Player[11];
            eventsHost = new List<Event>();
            eventsGuest = new List<Event>();
            goalsHost = new List<Goal>();
            goalsGuest = new List<Goal>();
            substitutesHost = new List<Substitution>();
            substitutesGuest = new List<Substitution>();

            teams = this.host.fullName + " - " + this.guest.fullName;
            result = "  -  ";
            teamsAndResult = this.host.fullName + "   -   " + this.guest.fullName;
            ballPossessionHost = 50;
            ballPossessionGuest = 50;
        }

        public void clear() // USING IN MANAGER MODE
        {
            state = StateOfMatch.notStarted;
            result = "  -  ";

            pointsHost = 0;
            pointsGuest = 0;
            ballPossessionHost = 50;
            ballPossessionGuest = 50;
            numberOfActionsHost = 0;
            numberOfActionsGuest = 0;
            attackForceHost = 0;
            attackForceGuest = 0;

            actions = new Action[90];
            starting11Host = new Player[11];
            starting11Guest = new Player[11];
            current11Host = new Player[11];
            current11Guest = new Player[11];
            eventsHost = new List<Event>();
            eventsGuest = new List<Event>();
            goalsHost = new List<Goal>();
            goalsGuest = new List<Goal>();
            substitutesHost = new List<Substitution>();
            substitutesGuest = new List<Substitution>();
        }

        public void finish()
        {
            state = StateOfMatch.finished;
            if (goalsHost.Count > goalsGuest.Count) { pointsHost = 3; pointsGuest = 0; }
            if (goalsHost.Count == goalsGuest.Count) { pointsHost = 1; pointsGuest = 1; }
            if (goalsHost.Count < goalsGuest.Count) { pointsHost = 0; pointsGuest = 3; }
            result = goalsHost.Count + " - " + goalsGuest.Count;
            teamsAndResult = host.fullName + " " + goalsHost.Count + " - " + goalsGuest.Count + " " + guest.fullName;
        }

        public void playWithoutRelation() // USING IN MANAGER MODE FOR OTHER CLUBS
        {
            for (int i = 0; i < 90; i++)
                playAction(i);
        }

        /// <summary>
        /// 
        /// </summary>
        public void makeSubstitution()
        {

        }

        void refreshTeamsSkills()
        {
            calculateSkillsDifference();
            calculateChanceOfPenalty();
            calculateLevelsDifferenceGoalkeeperExecutorOfPenalty();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minute"></param>

        public void playAction(int minute)
        {
            this.minute = minute;
            actions[minute] = new Action(minute);

            if (minute == 0)
            {
                state = StateOfMatch.playedNow;
                fillComments();
                setStarting11();
                calculateSkillsDifference();
                calculateChanceOfPenalty();
                calculateLevelsDifferenceGoalkeeperExecutorOfPenalty();

                actions[minute].comment += rozpoczecieMeczu[generator.Next(rozpoczecieMeczu.Count)] + " ";
            }
            if (minute == 45)
                actions[minute].comment += rozpoczecie2Polowy[generator.Next(rozpoczecie2Polowy.Count)] + " ";
            if (minute >= 0 && minute < 90)
            {
                if (generator.Next(100) <= ballPossessionHostGenerally)
                {
                    actions[minute].ballPossession = EClub.host;
                    attackingTeam = host;
                    defendingTeam = guest;
                    numberOfActionsHost++;

                    if (generator.Next(1000) <= attackForceHostGenerally)
                    {
                        nr = generator.Next(1, 11);
                        Goal goal = new Goal(minute + 1, attackingTeam.squad.players[nr], false);
                        eventsHost.Add(goal);
                        goalsHost.Add(goal);
                        fillComments();
                        actions[minute].comment += gol[generator.Next(gol.Count)] + " ";
                    }
                    if (generator.Next(chancePenaltyHost) == 0)
                    {
                        nr = generator.Next(1, 11);
                        fillComments();
                        actions[minute].comment += rzutKarny[generator.Next(rzutKarny.Count)] + " ";

                        if (generator.Next(100) <= penaltyForceHost)
                        {
                            Goal goal = new Goal(minute + 1, attackingTeam.squad.players[attackingTeam.tactics.setPieces], true);
                            eventsHost.Add(goal);
                            goalsHost.Add(goal);
                            actions[minute].comment += rzutKarnyGol[generator.Next(rzutKarnyGol.Count)] + " ";
                        }
                        else
                        {
                            PenaltyNoGoal penalty = new PenaltyNoGoal(minute + 1, attackingTeam.squad.players[attackingTeam.tactics.setPieces]);
                            eventsHost.Add(penalty);
                            actions[minute].comment += rzutKarnyNieGol[generator.Next(rzutKarnyNieGol.Count)] + " ";
                        }
                    }
                }
                else
                {
                    actions[minute].ballPossession = EClub.guest;
                    attackingTeam = guest;
                    defendingTeam = host;
                    numberOfActionsGuest++;

                    if (generator.Next(1000) <= attackForceGuestGenerally)
                    {
                        nr = generator.Next(1, 11);
                        Goal goal = new Goal(minute + 1, attackingTeam.squad.players[nr], false);
                        eventsGuest.Add(goal);
                        goalsGuest.Add(goal);
                        fillComments();
                        actions[minute].comment += gol[generator.Next(gol.Count)] + " ";
                    }
                    if (generator.Next(chancePenaltyGuest) == 0)
                    {
                        nr = generator.Next(1, 11);
                        fillComments();
                        actions[minute].comment += rzutKarny[generator.Next(rzutKarny.Count)] + " ";

                        if (generator.Next(100) <= penaltyForceGuest)
                        {
                            Goal goal = new Goal(minute + 1, attackingTeam.squad.players[attackingTeam.tactics.setPieces], true);
                            eventsGuest.Add(goal);
                            goalsGuest.Add(goal);
                            actions[minute].comment += rzutKarnyGol[generator.Next(rzutKarnyGol.Count)] + " ";
                        }
                        else
                        {
                            PenaltyNoGoal penalty = new PenaltyNoGoal(minute + 1, attackingTeam.squad.players[attackingTeam.tactics.setPieces]);
                            eventsGuest.Add(penalty);
                            actions[minute].comment += rzutKarnyNieGol[generator.Next(rzutKarnyNieGol.Count)] + " ";
                        }
                    }
                }

                ballPossessionHost = (int)(numberOfActionsHost / (double)(minute + 1) * 100);
                ballPossessionGuest = 100 - ballPossessionHost;
                if (numberOfActionsHost > 0)
                    attackForceHost = (int)(goalsHost.Count / (double)numberOfActionsHost * 100);
                if (numberOfActionsGuest > 0)
                    attackForceGuest = (int)(goalsGuest.Count / (double)numberOfActionsGuest * 100);

                result = goalsHost.Count + " - " + goalsGuest.Count;
            }
            if (minute == 44)
            {
                fillComments();
                actions[minute].comment += zakonczeniePolowy[generator.Next(zakonczeniePolowy.Count)] + " ";
                actions[minute].comment += ballPossession[generator.Next(ballPossession.Count)];
            }
            if (minute == 89)
            {
                fillComments();
                actions[minute].comment += zakonczenieMeczu[generator.Next(zakonczenieMeczu.Count)] + " ";
                actions[minute].comment += ballPossession[generator.Next(ballPossession.Count)];
                finish();
            }
        }




        int differenceMiddle;
        int differenceAttackHostDefenseGuest;
        int differenceAttackGuestDefenseHost;
        int ballPossessionHostGenerally;
        int ballPossessionGuestGenerally;
        double attackForceHostGenerally;
        double attackForceGuestGenerally;

        int chancePenaltyHost;
        int chancePenaltyGuest;
        int differenceExecutorHostGoalkeeperGuest;
        int differenceExecutorGuestGoalkeeperHost;
        int penaltyForceHost;
        int penaltyForceGuest;

        // RELATION VARIABLES
        Club attackingTeam;
        Club defendingTeam;
        int nr;
        static Random generator = new Random();
        //List<string> wynikMeczu;
        List<string> squads;
        List<string> ballPossession;
        List<string> rozpoczecieMeczu;
        List<string> zakonczeniePolowy;
        List<string> rozpoczecie2Polowy;
        List<string> zakonczenieMeczu;
        List<string> rzutKarny;
        List<string> rzutKarnyGol;
        List<string> rzutKarnyNieGol;
        List<string> gol;

        void setStarting11()
        {
            for (int i = 0; i < 11; i++)
            {
                starting11Host[i] = host.squad.players[i];
                starting11Guest[i] = guest.squad.players[i];
            }
        }

        void setCurrent11()
        {
            for (int i = 0; i < 11; i++)
            {
                current11Host[i] = host.squad.players[i];
                current11Guest[i] = guest.squad.players[i];
            }
        }

        void calculateSkillsDifference()
        {
            differenceMiddle = (host.middle - guest.middle) / 10;
            differenceAttackHostDefenseGuest = (host.attack - guest.defense) / 10;
            differenceAttackGuestDefenseHost = (guest.attack - host.defense) / 10;

            // OBLICZANIE OGÓLNEGO POSIADANIA PIŁKI DLA GOSPODARZA W PROCENTACH
            if (differenceMiddle == -9) { ballPossessionHostGenerally = 15; }
            if (differenceMiddle == -8) { ballPossessionHostGenerally = 19; }
            if (differenceMiddle == -7) { ballPossessionHostGenerally = 23; }
            if (differenceMiddle == -6) { ballPossessionHostGenerally = 27; }
            if (differenceMiddle == -5) { ballPossessionHostGenerally = 31; }
            if (differenceMiddle == -4) { ballPossessionHostGenerally = 35; }
            if (differenceMiddle == -3) { ballPossessionHostGenerally = 39; }
            if (differenceMiddle == -2) { ballPossessionHostGenerally = 43; }
            if (differenceMiddle == -1) { ballPossessionHostGenerally = 47; }
            if (differenceMiddle ==  0) { ballPossessionHostGenerally = 50; }
            if (differenceMiddle ==  1) { ballPossessionHostGenerally = 53; }
            if (differenceMiddle ==  2) { ballPossessionHostGenerally = 57; }
            if (differenceMiddle ==  3) { ballPossessionHostGenerally = 61; }
            if (differenceMiddle ==  4) { ballPossessionHostGenerally = 65; }
            if (differenceMiddle ==  5) { ballPossessionHostGenerally = 69; }
            if (differenceMiddle ==  6) { ballPossessionHostGenerally = 73; }
            if (differenceMiddle ==  7) { ballPossessionHostGenerally = 77; }
            if (differenceMiddle ==  8) { ballPossessionHostGenerally = 81; }
            if (differenceMiddle ==  9) { ballPossessionHostGenerally = 85; }
            
            ballPossessionGuestGenerally = 100 - ballPossessionHostGenerally;

            // OBLICZANIE SKUTECZNOSCI ATAKU GOSPODARZA W PROMILACH
            if (differenceAttackHostDefenseGuest == -9) attackForceHostGenerally = 1;
            if (differenceAttackHostDefenseGuest == -8) attackForceHostGenerally = 3;
            if (differenceAttackHostDefenseGuest == -7) attackForceHostGenerally = 5;
            if (differenceAttackHostDefenseGuest == -6) attackForceHostGenerally = 8;
            if (differenceAttackHostDefenseGuest == -5) attackForceHostGenerally = 10;
            if (differenceAttackHostDefenseGuest == -4) attackForceHostGenerally = 12;
            if (differenceAttackHostDefenseGuest == -3) attackForceHostGenerally = 15;
            if (differenceAttackHostDefenseGuest == -2) attackForceHostGenerally = 18;
            if (differenceAttackHostDefenseGuest == -1) attackForceHostGenerally = 20;
            if (differenceAttackHostDefenseGuest ==  0) attackForceHostGenerally = 23;
            if (differenceAttackHostDefenseGuest ==  1) attackForceHostGenerally = 27;
            if (differenceAttackHostDefenseGuest ==  2) attackForceHostGenerally = 30;
            if (differenceAttackHostDefenseGuest ==  3) attackForceHostGenerally = 35;
            if (differenceAttackHostDefenseGuest ==  4) attackForceHostGenerally = 40;
            if (differenceAttackHostDefenseGuest ==  5) attackForceHostGenerally = 45;
            if (differenceAttackHostDefenseGuest ==  6) attackForceHostGenerally = 50;
            if (differenceAttackHostDefenseGuest ==  7) attackForceHostGenerally = 60;
            if (differenceAttackHostDefenseGuest ==  8) attackForceHostGenerally = 60;
            if (differenceAttackHostDefenseGuest ==  9) attackForceHostGenerally = 70;

            // OBLICZANIE SKUTECZNOSCI ATAKU GOSCI W PROMILACH
            if (differenceAttackGuestDefenseHost == -9) attackForceGuestGenerally = 1;
            if (differenceAttackGuestDefenseHost == -8) attackForceGuestGenerally = 3;
            if (differenceAttackGuestDefenseHost == -7) attackForceGuestGenerally = 5;
            if (differenceAttackGuestDefenseHost == -6) attackForceGuestGenerally = 8;
            if (differenceAttackGuestDefenseHost == -5) attackForceGuestGenerally = 10;
            if (differenceAttackGuestDefenseHost == -4) attackForceGuestGenerally = 12;
            if (differenceAttackGuestDefenseHost == -3) attackForceGuestGenerally = 15;
            if (differenceAttackGuestDefenseHost == -2) attackForceGuestGenerally = 18;
            if (differenceAttackGuestDefenseHost == -1) attackForceGuestGenerally = 20;
            if (differenceAttackGuestDefenseHost ==  0) attackForceGuestGenerally = 23;
            if (differenceAttackGuestDefenseHost ==  1) attackForceGuestGenerally = 27;
            if (differenceAttackGuestDefenseHost ==  2) attackForceGuestGenerally = 30;
            if (differenceAttackGuestDefenseHost ==  3) attackForceGuestGenerally = 35;
            if (differenceAttackGuestDefenseHost ==  4) attackForceGuestGenerally = 40;
            if (differenceAttackGuestDefenseHost ==  5) attackForceGuestGenerally = 45;
            if (differenceAttackGuestDefenseHost ==  6) attackForceGuestGenerally = 50;
            if (differenceAttackGuestDefenseHost ==  7) attackForceGuestGenerally = 60;
            if (differenceAttackGuestDefenseHost ==  8) attackForceGuestGenerally = 60;
            if (differenceAttackGuestDefenseHost ==  9) attackForceGuestGenerally = 70;
        }

        void calculateChanceOfPenalty()
        {
            if (host.tactics.agression == "bardzo słaby") chancePenaltyGuest = 270;
            if (host.tactics.agression == "słaby") chancePenaltyGuest = 180;
            if (host.tactics.agression == "zwykły") chancePenaltyGuest = 120;
            if (host.tactics.agression == "mocny") chancePenaltyGuest = 90;
            if (host.tactics.agression == "bardzo mocny") chancePenaltyGuest = 30;

            if (guest.tactics.agression == "bardzo słaby") chancePenaltyHost = 270;
            if (guest.tactics.agression == "słaby") chancePenaltyHost = 180;
            if (guest.tactics.agression == "zwykły") chancePenaltyHost = 120;
            if (guest.tactics.agression == "mocny") chancePenaltyHost = 90;
            if (guest.tactics.agression == "bardzo mocny") chancePenaltyHost = 30;
        }

        void calculateLevelsDifferenceGoalkeeperExecutorOfPenalty()
        {
            differenceExecutorHostGoalkeeperGuest = host.squad.players[host.tactics.setPieces].shooting - guest.squad.players[0].goalkeeping;
            differenceExecutorGuestGoalkeeperHost = guest.squad.players[0].goalkeeping - host.squad.players[host.tactics.setPieces].shooting;

            differenceExecutorHostGoalkeeperGuest = differenceExecutorHostGoalkeeperGuest / 10;
            differenceExecutorGuestGoalkeeperHost = differenceExecutorGuestGoalkeeperHost / 10;

            if (differenceExecutorHostGoalkeeperGuest == -9) penaltyForceHost = 15;
            if (differenceExecutorHostGoalkeeperGuest == -8) penaltyForceHost = 23;
            if (differenceExecutorHostGoalkeeperGuest == -7) penaltyForceHost = 31;
            if (differenceExecutorHostGoalkeeperGuest == -6) penaltyForceHost = 39;
            if (differenceExecutorHostGoalkeeperGuest == -5) penaltyForceHost = 45;
            if (differenceExecutorHostGoalkeeperGuest == -4) penaltyForceHost = 51;
            if (differenceExecutorHostGoalkeeperGuest == -3) penaltyForceHost = 57;
            if (differenceExecutorHostGoalkeeperGuest == -2) penaltyForceHost = 61;
            if (differenceExecutorHostGoalkeeperGuest == -1) penaltyForceHost = 65;
            if (differenceExecutorHostGoalkeeperGuest ==  0) penaltyForceHost = 70;
            if (differenceExecutorHostGoalkeeperGuest ==  1) penaltyForceHost = 73;
            if (differenceExecutorHostGoalkeeperGuest ==  2) penaltyForceHost = 76;
            if (differenceExecutorHostGoalkeeperGuest ==  3) penaltyForceHost = 79;
            if (differenceExecutorHostGoalkeeperGuest ==  4) penaltyForceHost = 82;
            if (differenceExecutorHostGoalkeeperGuest ==  5) penaltyForceHost = 85;
            if (differenceExecutorHostGoalkeeperGuest ==  6) penaltyForceHost = 88;
            if (differenceExecutorHostGoalkeeperGuest ==  7) penaltyForceHost = 91;
            if (differenceExecutorHostGoalkeeperGuest ==  8) penaltyForceHost = 94;
            if (differenceExecutorHostGoalkeeperGuest ==  9) penaltyForceHost = 97;

            if (differenceExecutorGuestGoalkeeperHost == -9) penaltyForceGuest = 15;
            if (differenceExecutorGuestGoalkeeperHost == -8) penaltyForceGuest = 23;
            if (differenceExecutorGuestGoalkeeperHost == -7) penaltyForceGuest = 31;
            if (differenceExecutorGuestGoalkeeperHost == -6) penaltyForceGuest = 39;
            if (differenceExecutorGuestGoalkeeperHost == -5) penaltyForceGuest = 45;
            if (differenceExecutorGuestGoalkeeperHost == -4) penaltyForceGuest = 51;
            if (differenceExecutorGuestGoalkeeperHost == -3) penaltyForceGuest = 57;
            if (differenceExecutorGuestGoalkeeperHost == -2) penaltyForceGuest = 61;
            if (differenceExecutorGuestGoalkeeperHost == -1) penaltyForceGuest = 65;
            if (differenceExecutorGuestGoalkeeperHost ==  0) penaltyForceGuest = 70;
            if (differenceExecutorGuestGoalkeeperHost ==  1) penaltyForceGuest = 73;
            if (differenceExecutorGuestGoalkeeperHost ==  2) penaltyForceGuest = 76;
            if (differenceExecutorGuestGoalkeeperHost ==  3) penaltyForceGuest = 79;
            if (differenceExecutorGuestGoalkeeperHost ==  4) penaltyForceGuest = 82;
            if (differenceExecutorGuestGoalkeeperHost ==  5) penaltyForceGuest = 85;
            if (differenceExecutorGuestGoalkeeperHost ==  6) penaltyForceGuest = 88;
            if (differenceExecutorGuestGoalkeeperHost ==  7) penaltyForceGuest = 91;
            if (differenceExecutorGuestGoalkeeperHost ==  8) penaltyForceGuest = 94;
            if (differenceExecutorGuestGoalkeeperHost ==  9) penaltyForceGuest = 97;
        }

        void fillComments()
        {
            if (attackingTeam == null) attackingTeam = host;
            if (defendingTeam == null) defendingTeam = guest;

            string skladGospodarz = host.fullName + ": " + host.squad.first11[0].surname + " - ";

            for (int i = 1; i < 11; i++)
            {
                if (i == host.tactics.defenders ||
                    i == host.tactics.defenders + host.tactics.midfielders)
                    skladGospodarz += host.squad.first11[i].surname + " - ";
                else
                    skladGospodarz += host.squad.first11[i].surname + " ";
            }

            string skladGosc = guest.fullName + ": " + guest.squad.first11[0].surname + " - ";

            for (int i = 1; i < 11; i++)
            {
                if (i == guest.tactics.defenders ||
                    i == guest.tactics.defenders + guest.tactics.midfielders)
                    skladGosc += guest.squad.first11[i].surname + " - ";
                else
                    skladGosc += guest.squad.first11[i].surname + " ";
            }

            squads = new List<string>();
            squads.Add(skladGospodarz + "\n" + skladGosc);

            rozpoczecieMeczu = new List<string>();
            rozpoczecieMeczu.Add("Sędzia rozpoczyna mecz.");
            rozpoczecieMeczu.Add(host.fullName + " rozpoczyna mecz.");
            rozpoczecieMeczu.Add("Zaczynamy 1. połowę.");
            rozpoczecieMeczu.Add("Sędzia zaczyna 1. połowę meczu.");

            rozpoczecie2Polowy = new List<string>();
            rozpoczecie2Polowy.Add("Zaczynamy drugą połowę meczu.");
            rozpoczecie2Polowy.Add("Sędzia rozpoczyna drugą połowę meczu.");
            rozpoczecie2Polowy.Add("Rozpoczynamy drugie 45 minut meczu.");
            rozpoczecie2Polowy.Add(guest.fullName + " rozpoczyna 2. połowę meczu.");

            zakonczeniePolowy = new List<string>();
            zakonczeniePolowy.Add("Koniec 1. połowy.");
            zakonczeniePolowy.Add("Wynik do przerwy " + result + ".");
            zakonczeniePolowy.Add("Sędzia kończy 1. połowę meczu.");
            zakonczeniePolowy.Add("Minęło 45 minut gry. Wynik " + result + ".");
            zakonczeniePolowy.Add("Po 45 minutach gry jest " + result + ".");

            zakonczenieMeczu = new List<string>();
            zakonczenieMeczu.Add("Sędzia odgwizduje koniec meczu.");
            zakonczenieMeczu.Add("Koniec meczu. Wynik " + result + ".");
            zakonczenieMeczu.Add("Sędzia kończy spotkanie. Wynik " + result + ".");

            ballPossession = new List<string>();
            ballPossession.Add("Posiadanie piłki " + ballPossessionHost + " - " + ballPossessionGuest + ".");
            ballPossession.Add("Gospodarz posiadał piłkę przez " + ballPossessionHost + "% czasu.");
            ballPossession.Add("Piłkarze gości posiadali piłkę przez " + ballPossessionGuest + "% czasu.");
            ballPossession.Add("Gospodarze posiadali piłkę przez " + ballPossessionHost + "% czasu, a goście przez " + ballPossessionGuest + "%.");

            gol = new List<string>();
            gol.Add(attackingTeam.squad.players[nr].surname + " zachowuje zimną krew będąc sam na sam z bramkarzem. Gol dla drużyny " + attackingTeam.fullName + ".");
            gol.Add(attackingTeam.squad.players[nr].surname + " strzela gola. Gol dla drużyny " + attackingTeam.fullName + ".");
            gol.Add(attackingTeam.squad.players[nr].surname + " strzela w samo okienko bramki i nie daje żadnych szans bramkarzowi. Gol dla drużyny " + attackingTeam.fullName + ".");
            gol.Add("Przy tym strzale " + defendingTeam.squad.players[0].surname + " nie miał żadnych szans. " + attackingTeam.fullName + " strzela gola.");
            gol.Add(attackingTeam.squad.players[nr + 1].surname + " dośrodkowuje piłkę i " + attackingTeam.squad.players[nr].surname + " strzela gola głową. Gol dla drużyny " + attackingTeam.fullName + ".");
            gol.Add(attackingTeam.squad.players[nr].surname + " mija kilku obrońców... w tym bramkarza. Piękna bramka piłkarza " + attackingTeam.fullName + ".");
            gol.Add("Piękna kombinacyjna akcja piłkarzy " + attackingTeam.fullName + ". Gola strzela " + attackingTeam.squad.players[nr].surname + ".");
            gol.Add(attackingTeam.squad.players[nr + 1].surname + " zagrywa prostopadłą piłkę do kolegi z zespołu. " + attackingTeam.squad.players[nr].surname + " mija bramkarza i strzela do pustej bramki.");

            rzutKarny = new List<string>();
            rzutKarny.Add("Sędzia dyktuje rzut karny dla " + attackingTeam.fullName + ".\n");
            rzutKarny.Add("Piłkarz drużyny " + attackingTeam.fullName + " został sfaulowany w polu karny. Sędzie wskazuje na 11 metr.\n");
            rzutKarny.Add(attackingTeam.squad.players[nr].surname + " został zfaulowany w polu karnym. Sędzia pokazuje na 11 metr.\n");
            rzutKarny.Add("Piłkarz drużyny " + defendingTeam.fullName + " fauluje przeciwnika w polu karnym. Sędzie odgwizduje rzut karny.\n");

            rzutKarnyGol = new List<string>();
            rzutKarnyGol.Add(attackingTeam.squad.players[attackingTeam.tactics.setPieces].surname + " pewnie wykorzystuje jedenastkę.");
            rzutKarnyGol.Add(attackingTeam.squad.players[attackingTeam.tactics.setPieces].surname + " strzela technicznie w lewy róg bramki. Gol dla " + attackingTeam.fullName + ".");
            rzutKarnyGol.Add(attackingTeam.squad.players[attackingTeam.tactics.setPieces].surname + " uderza mocno pod poprzeczkę. " + defendingTeam.squad.players[0].surname + " był bez szans.");

            rzutKarnyNieGol = new List<string>();
            rzutKarnyNieGol.Add(attackingTeam.squad.players[attackingTeam.tactics.setPieces].surname + " strzela w prawy dolny róg bramki. Jednak strzał był za słaby - bramkarz broni.");
            rzutKarnyNieGol.Add(attackingTeam.squad.players[attackingTeam.tactics.setPieces].surname + " nie trafia w bramkę. Piłka ląduje daleko w trybunach.");
        }
    }
}
