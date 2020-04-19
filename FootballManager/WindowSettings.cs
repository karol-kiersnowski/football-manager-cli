namespace FootballManager
{
    class WindowSettings : Window
    {
        public WindowSettings(string menu)
        {
            options = new string[5];
            options[0] = "English";
            options[1] = "Polski";
            options[2] = "80x25";
            options[3] = "80x28";
            options[4] = "80x43";
        }

        protected override void update()
        {
            menu = ">> Menu >> " + Text.settings;
        }

        protected override void draw()
        {
            displayHeader();
            Console.WriteLine(Text.language);
            for (int i = 0; i < 2; i++)
                Console.WriteLine(i + 1 + ". " + options[i]);
            Console.WriteLine();
            Console.WriteLine(Text.widthAndHeightOfWindow);
            for (int i = 2; i < options.Length; i++)
                Console.WriteLine(i + 1 + ". " + options[i]);
            Console.WriteLine();
        }

        protected override void selectOption()
        {
            Console.Write(Text.selection);
            selectedOption = Console.ReadLine();

            checkBasicOptions();

            switch (selectedOption)
            {
                case "1": new Text("English"); break;
                case "2": new Text("Polish"); break;
                case "3": Console.SetDimensions(80, 25); break;
                case "4": Console.SetDimensions(80, 28); break;
                case "5": Console.SetDimensions(80, 43); break;
            }
        }
    }
}
