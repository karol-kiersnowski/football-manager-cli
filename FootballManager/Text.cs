namespace FootballManager
{
    class Text
    {
		public static string selectedLanguage		{ get; private set; }

        public static string selection              { get; private set; }
        public static string selectionYesNo         { get; private set; }

        public static string loadingData            { get; private set; }

        // GAMES
        public static string polishCup              { get; private set; }
        public static string polishLeague1          { get; private set; }
        public static string polishLeague2          { get; private set; }
        public static string englishLeague          { get; private set; }

        // CUP
        public static string groupStage             { get; private set; }
        public static string _1_8Final              { get; private set; }
        public static string _1_4Final              { get; private set; }
        public static string _1_2Final              { get; private set; }
        public static string final                  { get; private set; }
        public static string finished               { get; private set; }

        // MENU
        public static string friendlyMatch          { get; private set; }
        public static string managerMode            { get; private set; }
        public static string savingGame             { get; private set; }
        public static string match                  { get; private set; }

        // WINDOW MAIN
        public static string playFriendlyMatch      { get; private set; }
        public static string startManagerMode       { get; private set; }
        public static string loadManagerMode        { get; private set; }
        public static string generateData           { get; private set; }
        public static string help                   { get; private set; }
        public static string aboutGame              { get; private set; }
        public static string settings               { get; private set; }
        public static string exit                   { get; private set; }

        // WINDOW GENERATOR
        public static string question               { get; private set; }
        public static string confirmation           { get; private set; }
        public static string failure                { get; private set; }
        public static string error                  { get; private set; }

        // WINDOW ABOUT GAME
        public static string version { get; private set; }
        public static string license { get; private set; }
        public static string author { get; private set; }

        // WINDOW SETTINGS
        public static string language               { get; private set; }
        public static string widthAndHeightOfWindow { get; private set; }

        // WINDOW CLUBS, STADIUMS, PLAYERS
        public static string league                 { get; private set; }
        public static string number                 { get; private set; }
        public static string name                   { get; private set; }
        public static string attack                 { get; private set; }
        public static string middle                 { get; private set; }
        public static string defense                { get; private set; }
        public static string capacity               { get; private set; }

        public static string fullName               { get; private set; }
        public static string goalkeeper             { get; private set; }
        public static string defender               { get; private set; }
        public static string midfielder             { get; private set; }
        public static string forward                { get; private set; }
        public static string age                    { get; private set; }
        public static string tot                    { get; private set; }
        public static string gk                     { get; private set; }
        public static string plm                    { get; private set; }
        public static string sho                    { get; private set; }
        public static string sta                    { get; private set; }
        public static string total                  { get; private set; }
        public static string goalkeeping            { get; private set; }
        public static string playmaking             { get; private set; }
        public static string shooting               { get; private set; }
        public static string stamina                { get; private set; }
        public static string value                  { get; private set; }
        public static string salary                 { get; private set; }

        // WINDOW MANAGER MODE
        public static string startMatch             { get; private set; }
        public static string squad                  { get; private set; }
        public static string tactics                { get; private set; }
        public static string training               { get; private set; }
        public static string transfers              { get; private set; }
        public static string finance                { get; private set; }
        public static string stadium                { get; private set; }
        public static string statistics             { get; private set; }
        public static string saveGame               { get; private set; }
        public static string gameSavedSuccessfully  { get; private set; }

        public static string club                   { get; private set; }
        public static string manager                { get; private set; }
        public static string season                 { get; private set; }
        public static string nextRound              { get; private set; }
        public static string position               { get; private set; }
        public static string form                   { get; private set; }
        public static string nextMatch              { get; private set; }
        public static string previousMatch          { get; private set; }

        // WINDOW SQUAD
        public static string toMakeSubstitution     { get; private set; }
        public static string writeNrOf2Player       { get; private set; }

        // WINDOW TACTICS
        public static string formation              { get; private set; }
        public static string posture                { get; private set; }
        public static string style                  { get; private set; }
        public static string agression              { get; private set; }
        public static string captain                { get; private set; }
        public static string setPieces              { get; private set; }

        // TACTICS - POSTURES AND LEVELS
        public static string veryDefensive          { get; private set; }
        public static string defensive              { get; private set; }
        public static string neutral                { get; private set; }
        public static string offensive              { get; private set; }
        public static string veryOffensive          { get; private set; }

        public static string veryWeak               { get; private set; }
        public static string weak                   { get; private set; }
        public static string normal                 { get; private set; }
        public static string strong                 { get; private set; }
        public static string veryStrong             { get; private set; }

        // WINDOW TRAINING
        public static string intensity              { get; private set; }
        public static string fitness                { get; private set; }
        public static string playmakingDefensive    { get; private set; }
        public static string shootingGoalkeeping    { get; private set; }

        // WINDOW FINANCE
        public static string week                   { get; private set; }
        public static string money                  { get; private set; }
        public static string ingoing                { get; private set; }
        public static string tickets                { get; private set; }
        public static string sponsors               { get; private set; }
        public static string outgoing               { get; private set; }
        public static string salaries               { get; private set; }
        public static string balance                { get; private set; }

        // WINDOW TRANSFERS
        public static string displayPlayerOnTransferList { get; private set; }
        public static string browseTransferList     { get; private set; }
        public static string browsePlayersOfClubs   { get; private set; }
        public static string sale                   { get; private set; }
        public static string transferList           { get; private set; }

        // WINDOW STATISTICS
        public static string leagueTable            { get; private set; }
        public static string topScorers             { get; private set; }
        public static string leagueFixtures         { get; private set; }
        public static string clubFixtures           { get; private set; }

        // WINDOW TABLE
        public static string positionAbbr           { get; private set; }
        public static string played                 { get; private set; }
        public static string won                    { get; private set; }
        public static string drawn                  { get; private set; }
        public static string lost                   { get; private set; }
        public static string points                 { get; private set; }

        public static string player                 { get; private set; }
        public static string matches                { get; private set; }
        public static string goals                  { get; private set; }

        // WINDOW FIXTURES
        public static string round                  { get; private set; }
        public static string host                   { get; private set; }
        public static string guest                  { get; private set; }
        public static string score                  { get; private set; }
        public static string selectMatch            { get; private set; }
        public static string selectRound            { get; private set; }

        // WINDOW MATCH
        public static string boost                  { get; private set; }
        public static string slow                   { get; private set; }
        public static string minute                 { get; private set; }
        public static string ballIsPossessedBy      { get; private set; }
        public static string ballPossession         { get; private set; }
        public static string attackForce            { get; private set; }

        public Text(string SelectedLanguage)
        {
			selectedLanguage = SelectedLanguage;

            if (SelectedLanguage == "English")
            {
                selection              = ">> ";
                selectionYesNo         = "Selection (y/n): ";

                loadingData            = "Loading data";

                // GAMES
                polishCup              = "Polish Cup";
                polishLeague1          = "1st Polish League";
                polishLeague2          = "2nd Polish League";
                englishLeague          = "English League";

                // CUP
                groupStage             = "Group stage";
                _1_8Final              = "1/8 of final";
                _1_4Final              = "Quater-final";
                _1_2Final              = "Semi-final";
                final                  = "Final";
                finished               = "Finished";

                // MENU
                friendlyMatch          = "Friendly match";
                managerMode            = "Manager mode";
                savingGame             = "Saving the game";
                match                  = "Match";

                // WINDOW MAIN
                playFriendlyMatch      = "Play a friendly match";
                startManagerMode       = "Start a manager mode";
                loadManagerMode        = "Load a manager mode";
                generateData           = "Generate new data";
                help                   = "Help";
                aboutGame              = "About game";
                settings               = "Settings";
                exit                   = "Exit";

                // WINDOW GENERATOR
                question               = "Are you sure you want to generate a new data? Your saved game will be lost!";
                confirmation           = "Data has generated.";
                failure                = "Failure. Data hasn't generated.";
                error                  = "An error occured. Data hasn't generated.";

                // WINDOWS ABOUT GAME
                version                 = "Version";
                license                 = "License";
                author                  = "Author";

                // WINDOW SETTINGS
                language               = "Language";
                widthAndHeightOfWindow = "Width and height of window";

                // WINDOW CLUBS, STADIUMS
                league                 = "League";
                number                 = "No.";
                name                   = "Name";
                attack                 = "Attack";
                middle                 = "Middle";
                defense                = "Defence";
                capacity               = "Capacity";

                fullName               = "Name";
                goalkeeper              = "G";
                defender                = "D";
                midfielder              = "M";
                forward                 = "F";
                age                    = "Age";
                tot                    = "Total";
                gk                     ="Goalk";
                plm                     = "Playm";
                sho                     = "Shoot";
                sta                     = "Stami";
                total                  = "Total";
                goalkeeping            = "Goalkeeping";
                playmaking             = "Playmaking";
                shooting               = "Shooting";
                stamina                = "Stamina";
                value                  = "Value";
                salary                 = "Salary";

                // WINDOW MANAGER MODE
                startMatch             = "Start a match";
                squad                  = "Squad";
                tactics                = "Tactics";
                training               = "Training";
                transfers              = "Transfers";
                finance                = "Finance";
                stadium                = "Stadium";
                statistics             = "Statistics";
                saveGame               = "Save a game";
                gameSavedSuccessfully  = "Game has saved successfully";

                club                   = "Club";   
                manager                = "Manager: ";
                season                 = "Season: "; 
                nextRound              = "Next round: ";
                position               = "Position: ";  
                form                   = "Form: ";      
                nextMatch              = "Next match: ";
                previousMatch          = "Previous match: ";

                // WINDOW SQUAD
                toMakeSubstitution     = "To make a substitution, write no. of 1st player: ";
                writeNrOf2Player       = "Write no. of 2nd player: ";

                // WINDOW TACTICS
                formation              = "Formation";
                posture                = "Posture";
                style                  = "Style";
                agression              = "Agression";
                captain                = "Captain";
                setPieces              = "Set pieces";

                // TACTICS - POSTURES AND LEVELS
                veryDefensive          = "very defensive";
                defensive              = "defensive";
                neutral                = "neutral";
                offensive              = "offensive";
                veryOffensive          = "very offensive";

                veryWeak               = "very weak";
                weak                   = "weak";
                normal                 = "normal";
                strong                 = "strong";
                veryStrong             = "very strong";

                // WINDOW TRAINING
                intensity              = "Intensity";
                fitness                = "Fitness";
                playmakingDefensive    = "Playmaking/defensive";
                shootingGoalkeeping    = "Shooting/goalkeeping";

                // WINDOW FINANCE
                week                   = "Week ";
                money                  = "Money: ";
                ingoing                = "INGOING";
                tickets                = "Tickets";
                sponsors               = "Sponsors";
                outgoing               = "OUTGOING";
                salaries               = "Salaries";
                balance                = "Balance";

                // WINDOW TRANSFERS
                displayPlayerOnTransferList = "Display player on the transfer list";
                browseTransferList     = "Browse the transfer list";
                browsePlayersOfClubs   = "Browse players of the clubs";
                sale                   = "Sale";
                transferList           = "Transfer list";

                // WINDOW STATISTICS
                leagueTable            = "League table";
                topScorers             = "Top scorers";
                leagueFixtures         = "League fixtures";
                clubFixtures           = "Club fixtures";

                // WINDOW TABLE
                positionAbbr           = "Pos.";
                played                 = "P";
                won                    = "W";
                drawn                  = "D";
                lost                   = "L";
                points                 = "Pts";

                player                 = "Player";
                matches                = "Matches";
                goals                  = "Goals";

                // WINDOW FIXTURES
                round                  = "Round ";
                host                   = "Host";
                guest                  = "Guest";
                score                  = "Score";
                selectMatch            = "Select a match: ";
                selectRound            = "Select a round: ";

                // WINDOW MATCH
                boost                  = "Boost";
                slow                   = "Slow";
                minute                 = "Minute: ";
                ballIsPossessedBy      = "Ball is possessed by: ";
                ballPossession         = "Ball possession";
                attackForce            = "Attack force";
            }




            if (SelectedLanguage == "Polish")
            {
                selection              = ">> ";
                selectionYesNo         = "Wybór (t/n): ";

                loadingData            = "Wczytywanie danych";

                // GAMES
                polishCup              = "Puchar Polski";
                polishLeague1          = "1. liga polska";
                polishLeague2          = "2. liga polska";
                englishLeague          = "Liga angielska";

                // CUP
                groupStage             = "Faza grupowa";
                _1_8Final              = "1/8 finału";
                _1_4Final              = "Ćwierćfinał";
                _1_2Final              = "Półfinał";
                final                  = "Finał";
                finished               = "Zakończony";

                // MENU
                friendlyMatch          = "Mecz towarzyski";
                managerMode            = "Tryb menedżera";
                savingGame             = "Zapis gry";
                match                  = "Mecz";

                // WINDOW MAIN
                playFriendlyMatch      = "Rozegraj mecz towarzyski";
                startManagerMode       = "Rozpocznij tryb menedżera";
                loadManagerMode        = "Wczytaj tryb menedżera";
                generateData           = "Generuj nowe dane";
                help                   = "Pomoc";
                aboutGame              = "O grze";
                settings               = "Ustawienia";
                exit                   = "Wyjście";

                // WINDOW GENERATOR
                question               = "Napewno chcesz wygenerować nowe dane? Zapisany stan gry zostanie utracony!";
                confirmation           = "Dane zostały wygenerowane.";
                failure                = "Zaniechano generowania danych.";
                error                  = "Wystąpił błąd. Dane nie zostały wygenerowane.";

                // WINDOWS ABOUT GAME
                version                 = "Wersja";
                license                 = "Licencja";
                author                  = "Autor";

                // WINDOW SETTINGS
                language               = "Język";
                widthAndHeightOfWindow = "Szerokość i wysokość okna";

                // WINDOW CLUBS, STADIUMS
                league                 = "Liga";
                number                = "Nr";
                name                   = "Nazwa";
                total                  = "Sum";
                attack                 = "Atak";
                middle                 = "Pomoc";
                defense                = "Obrona";
                capacity               = "Pojemność";

                fullName               = "Imię i nazwisko";
                goalkeeper              = "B";
                defender                = "O";
                midfielder              = "P";
                forward                 = "N";
                age                    = "Lat";
                tot                    = "Sum";
                gk                     ="Br";
                plm                     = "Roz";
                sho                     = "Str";
                sta                     = "Kon";
                total                  = "Suma";
                goalkeeping            = "Bramkarz";
                playmaking             = "Rozgrywanie";
                shooting               = "Strzały";
                stamina                = "Kondycja";
                value                  = "Wartość";
                salary                 = "Pensja";

                // WINDOW MANAGER MODE
                startMatch             = "Rozpocznij mecz";
                squad                  = "Skład";
                tactics                = "Taktyka";
                training               = "Trening";
                transfers              = "Transfery";
                finance                = "Finanse";
                stadium                = "Stadion";
                statistics             = "Statystyki";
                saveGame               = "Zapisz grę";
                gameSavedSuccessfully  = "Zapis zakończony powodzeniem";

                club                   = "Klub";   
                manager                = "Menedżer: ";
                season                 = "Sezon: "; 
                nextRound              = "Następna kolejka: ";
                position               = "Miejsce: ";  
                form                   = "Forma: ";      
                nextMatch              = "Następny mecz: ";
                previousMatch          = "Poprzedni mecz: ";

                // WINDOW SQUAD
                toMakeSubstitution     = "Aby dokonać zmiany, podaj nr 1-go piłkarza: ";
                writeNrOf2Player       = "Podaj nr 2-go piłkarza: ";

                // WINDOW TACTICS
                formation              = "Formacja";
                posture                = "Ustawienie";
                style                  = "Styl";
                agression              = "Poziom agresji";
                captain                = "Kapitan";
                setPieces              = "Stałe fragmenty";

                // TACTICS - POSTURES AND LEVELS
                veryDefensive          = "bardzo defensywne";
                defensive              = "defensywne";
                neutral                = "neutralne";
                offensive              = "ofensywne";
                veryOffensive          = "bardzo ofensywne";

                veryWeak               = "bardzo słaby";
                weak                   = "słaby";
                normal                 = "zwykły";
                strong                 = "mocny";
                veryStrong             = "bardzo mocny";

                // WINDOW TRAINING
                intensity              = "Intensywność";
                fitness                = "Kondycja";
                playmakingDefensive    = "Rozgrywanie/defensywa";
                shootingGoalkeeping    = "Strzały/bramkarz";

                // WINDOW FINANCE
                week                   = "Tydzień ";
                money                  = "Pieniądze: ";
                ingoing                = "PRZYCHODY";
                tickets                = "Bilety";
                sponsors               = "Sponsorzy";
                outgoing               = "WYDATKI";
                salaries               = "Pensje";
                balance                = "Saldo";

                // WINDOW TRANSFERS
                displayPlayerOnTransferList = "Wystaw piłkarza na listę transferową";
                browseTransferList     = "Przeglądaj listę transferową";
                browsePlayersOfClubs   = "Przeglądaj piłkarzy danych klubów";
                sale                   = "Sprzedaż";
                transferList           = "Lista transferowa";

                // WINDOW STATISTICS
                leagueTable            = "Tabela ligowa";
                topScorers             = "Najlepsi strzelcy";
                leagueFixtures         = "Terminarz ligowy";
                clubFixtures           = "Terminarz klubowy";

                // WINDOW TABLE
                positionAbbr           = "Poz.";
                played                 = "M";
                won                    = "Z";
                drawn                  = "R";
                lost                   = "P";
                points                 = "Pkt";

                player                 = "Piłkarz";
                matches                = "Mecze";
                goals                  = "Gole";

                // WINDOW FIXTURES
                round                  = "Kolejka ";
                host                   = "Gospodarz";
                guest                  = "Gość";
                score                  = "Wynik";
                selectMatch            = "Wybierz mecz: ";
                selectRound            = "Wybierz kolejkę: ";

                // WINDOW MATCH
                boost                  = "Przyspiesz";
                slow                   = "Zwolnij";
                minute                 = "Minuta: ";
                ballIsPossessedBy      = "Piłkę posiada: ";
                ballPossession         = "Posiadanie piłki";
                attackForce            = "Skuteczność ataku";
            }
        }
    }
}
