using System;

namespace FootballManager
{
    class WindowTraining : Window
    {
        public WindowTraining(string menu, Club club)
        {
            this.club = club;
            this.menu = menu + " >> " + Text.training;
            options = new string[5];
            options[0] = Text.intensity;
           options[1] = Text.fitness;
           options[2] = Text.playmakingDefensive;
            options[3] = Text.shootingGoalkeeping;
            options[4] = Text.setPieces;
        }

        protected override void draw()
        {
            displayHeader();
            displayOptions();
        }
        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();
            if (selectedOption == "q") Program.isRunning = false;
            if (selectedOption == "0") isRunning = false;
        }

        protected override void update()
        {
            
        }

        Club club;
    }
}
