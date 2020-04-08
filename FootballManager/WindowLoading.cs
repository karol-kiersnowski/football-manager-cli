using System;

namespace FootballManager
{
    class WindowLoading : Window
    {
        public WindowLoading() {}

        protected override void draw()
        {
            displayHeader();
            Console.WriteLine(Text.loadingData);
        }

        protected override void selectOption()
        {
            new DataCSV();
        }

        protected override void update()
        {
            isRunning = false;
        }
    }
}
