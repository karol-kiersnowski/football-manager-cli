using System;

namespace FootballManager
{
    class WindowLoading : Window
    {
        public WindowLoading() {}

        protected override void draw()
        {
			Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(Text.loadingData);
        }

        protected override void selectOption()
        {
            new Database();
        }

        protected override void update()
        {
            isRunning = false;
        }
    }
}
