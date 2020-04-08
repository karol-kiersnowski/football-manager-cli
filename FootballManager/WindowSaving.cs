using System;

namespace FootballManager
{
    class WindowSaving : Window
    {
        public WindowSaving(string menu)
        {
            this.menu = menu + " >> " + Text.savingGame;
        }

        protected override void draw()
        {
            displayHeader();
            Console.WriteLine(Text.gameSavedSuccessfully);
        }

        protected override void selectOption()
        {
            Console.ReadKey();
            isRunning = false;
        }

        protected override void update()
        {
            
        }
    }
}
