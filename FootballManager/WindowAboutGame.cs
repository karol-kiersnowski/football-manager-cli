using System;

namespace FootballManager
{
    class WindowAboutGame : Window
    {
        public WindowAboutGame(string menu)
        {
            this.menu = menu + " >> " + Text.aboutGame;
        }

        protected override void update()
        {

        }

        protected override void draw()
        {
            displayHeader();

           if (Text.selectedLanguage == "English")
                Console.Write("Football Manager is a simple text game. We can become the manager of a football club and manage it in game seasons.\n\n");
           if (Text.selectedLanguage == "Polish")
                Console.Write("Football Manager jest prostą grą tekstową, w której możemy stać się menedżerem klubu piłkarskiego i prowadzić go w rozgrywkach.\n\n");
            
           Console.WriteLine(Text.version + ": 20.04");
            Console.WriteLine(Text.license + ": GNU General Public Licnse v3.0");
            Console.WriteLine(Text.author + ": Karol Kiersnowski");
        }

        protected override void selectOption()
        {
            Console.ReadKey();
            isRunning = false;
        }
    }
}
