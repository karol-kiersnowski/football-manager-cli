using System;

namespace FootballManager
{
    class WindowFinance : Window
    {
        public WindowFinance(string menu, Club club)
        {
            this.club = club;
            this.menu = menu + " >> " + Text.finance;
            finance = club.finance;
        }

        protected override void draw()
        {
            int initialY = displayHeader();

            Console.Write(Text.week + Games.instance.polishLeague1.nrRound + ".");
            Console.Write("\t\t" + Text.money + "{0:n0} ({1:n0})", finance.money, finance.moneyFromPreviousWeek);

            int x = 0;
            int y = initialY + 2;

            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.ingoing, finance.ingoing);
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.tickets, finance.tickets);
            y++;
            Console.SetCursorPosition(x, y);
           Console.Write("{0,-10} {1,7:n0}", Text.sponsors, finance.sponsors);
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.transfers, finance.saleOfPlayers);

            x += 25;
            y = initialY + 2;
            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.outgoing, finance.outgoing);
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.stadium, finance.stadium);
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.salaries, finance.salaries);
            y++;
           Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.transfers, finance.purchaseOfPlayers);

            x = 0;
            y = initialY + 7;
            Console.SetCursorPosition(x, y);
            Console.Write("{0,-10} {1,7:n0}", Text.balance, finance.balance);
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
        Finance finance;
    }
}
