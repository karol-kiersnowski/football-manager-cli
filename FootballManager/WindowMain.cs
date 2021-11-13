using System;

namespace FootballManager
{
    class WindowMain : Window
    {
        public WindowMain()
        {
            menu = ">> Menu";
            options = new string[8];
        }

        protected override void update()
        {
            options[0] = "1. " + Text.playFriendlyMatch;
            options[1] = "2. " + Text.startManagerMode;
            options[2] = "3. " + Text.loadManagerMode;
            options[3] = "4. " + Text.generateData;
            options[4] = "5. " + Text.help;
            options[5] = "6. " + Text.aboutGame;
            options[6] = "7. " + Text.settings;
            options[7] = "0. " + Text.exit;
        }

        protected override void draw()
        {
            displayHeader();
            displayOptionsWithoutNumbers();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            checkBasicOptions();
            switch (selectedOption)
            {
                case "1": new WindowClubs(menu, Text.friendlyMatch).run(); break;
                case "2": new WindowClubs(menu, Text.managerMode).run(); break;
                //case "3": new WindowManagerMode(menu, null).run();      break;
                //case "4": new WindowGenerator(menu).run();              break;
                case "5": new WindowAboutGame(menu).run();              break;
                case "6": new WindowAboutGame(menu).run();              break;
                case "7": new WindowSettings(menu).run();               break;
            }
        }
    }
}
