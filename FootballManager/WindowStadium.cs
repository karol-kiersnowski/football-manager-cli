using System;

namespace FootballManager
{
    class WindowStadium : Window
    {
        public WindowStadium(string menu, Club club)
        {
            this.club = club;
            this.menu = menu + " >> " + Text.stadium;
        }

        protected override void draw()
        {
            displayHeader();
            Console.WriteLine(Text.name + ": " + club.stadium.name);
            Console.WriteLine(Text.capacity + ": " + club.stadium.capacity);
        }

        protected override void selectOption()
        {
            Console.ReadKey();
            isRunning = false;
        }

        protected override void update()
        {
            
        }

        Club club;
    }
}
