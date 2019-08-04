using System;

namespace FootballManager
{
    class Pitch
    {
        public int[,] boisko { get; private set; }
        public int dlugosc { get; private set; }
        public int szerokosc { get; private set; }

        public Pitch(int dlugosc, int szerokosc, int promien)
        {
            this.dlugosc = dlugosc;
            this.szerokosc = szerokosc;
            this.promien = promien;
            boisko = new int[dlugosc, szerokosc];
            gornyLewyRogBoiska = new Punkt(0, 0);
            gornyPrawyRogBoiska = new Punkt(szerokosc-1, 0);
            dolnyLewyRogBoiska = new Punkt(0, dlugosc-1);
            dolnyPrawyRogBoiska = new Punkt(szerokosc-1, dlugosc-1);
            poleKarneGorneLewyPunkt = new Punkt(szerokosc / 4, dlugosc / 5);
            poleKarneGornePrawyPunkt = new Punkt(szerokosc * 3 / 4, dlugosc / 5);
            //srodekBoiska = new Punkt((szerokosc - 1) / 2, dlugosc - 1);
            srodekPolokregu = new Punkt(szerokosc / 2, dlugosc / 5);

            boiskoLiniaGorna = new Odcinek(gornyLewyRogBoiska, gornyPrawyRogBoiska, this);
            boiskoLiniaDolna = new Odcinek(dolnyLewyRogBoiska, dolnyPrawyRogBoiska, this);
            boiskoLiniaLewa = new Odcinek(gornyLewyRogBoiska, dolnyLewyRogBoiska, this);
            boiskoLiniaPrawa = new Odcinek(gornyPrawyRogBoiska, dolnyPrawyRogBoiska, this);
            poleKarneGorneLewaLinia = new Odcinek(new Punkt(szerokosc / 4, 0), poleKarneGorneLewyPunkt, this);
            poleKarneGornePrawaLinia = new Odcinek(new Punkt(szerokosc * 3 / 4, 0), poleKarneGornePrawyPunkt, this);
            poleKarneGorneDolnaLinia = new Odcinek(poleKarneGorneLewyPunkt, poleKarneGornePrawyPunkt, this);
            //okragSrodkowy = new Okrag(srodekBoiska, 5, this);
            //polokrag = new Okrag(srodekPolokregu, promien, this);

            boiskoLiniaGorna.wykonaj();
            boiskoLiniaDolna.wykonaj();
            boiskoLiniaLewa.wykonaj();
            boiskoLiniaPrawa.wykonaj();
            poleKarneGorneLewaLinia.wykonaj();
            poleKarneGornePrawaLinia.wykonaj();
            poleKarneGorneDolnaLinia.wykonaj();
            //okragSrodkowy.Wykonaj();
            //polokrag.Wykonaj();



            //lewyPunktLiniiSrodkowej = new Punkt(0, (dlugosc-1) / 2);
            //prawyPunktLiniiSrodkowej = new Punkt(szerokosc-1, (dlugosc-1) / 2);
            //srodekBoiska = new Punkt((szerokosc - 1) / 2, (dlugosc - 1) / 2);
            //poleKarneGorneLewyPunkt = new Punkt(szerokosc / 4, dlugosc / 7);
            //poleKarneGornePrawyPunkt = new Punkt(szerokosc * 3 / 4, dlugosc / 7);
            //poleKarneDolneLewyPunkt = new Punkt(szerokosc / 4, dlugosc * 6 / 7);
            //poleKarneDolneLewyPunkt = new Punkt(szerokosc * 3 / 4, dlugosc * 6 / 7);
            //boiskoLiniaSrodkowa = new Odcinek(lewyPunktLiniiSrodkowej, prawyPunktLiniiSrodkowej, this);
            //poleKarneGorneLewaLinia = new Odcinek(new Punkt(szerokosc / 4, 0), poleKarneGorneLewyPunkt, this);
            //poleKarneGornePrawaLinia = new Odcinek(new Punkt(szerokosc * 3 / 4, 0), poleKarneGornePrawyPunkt, this);
            //poleKarneGorneDolnaLinia = new Odcinek(poleKarneGorneLewyPunkt, poleKarneGornePrawyPunkt, this);
            //okragSrodkowy = new Okrag(srodekBoiska, 5, this);

        }

        public void draw(int x0, int y0)
        {
            for (int y = 0; y < dlugosc; y++)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    Console.SetCursorPosition(x0 + x, y0 + y);
                    if (boisko[y, x] == 1) Console.Write('*');
                    else if (boisko[y, x] == 2) Console.Write('#');
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
            //Console.ReadKey();

            //for (int y = 0; y < 3; y++)
            //{
            //    for (int x = 0; x < 7; x++)
            //    {
            //        Console.SetCursorPosition(x0 + srodekPolokregu.X - 3 + x, y0 + srodekPolokregu.Y - 3 + y);
            //        Console.Write(" ");
            //    }
            //}
            //Console.ReadKey();
        }

        public void writeNumbers(int x0, int y0, Club druzyna)
        {
            int u = 0;
            //if (druzyna.tactics.posture == Tactics.postures[1]) u = -1;
            //if (druzyna.tactics.posture == Tactics.postures[3]) u = 1;
            Window.setColor(Position.goalkeeper);
            Console.SetCursorPosition(x0 + srodekPolokregu.X, y0 + srodekPolokregu.Y / 2); Console.Write("1");
            if (druzyna.tactics.formation == Tactics.formations[0])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 3 / 10, y0 + (int)(dlugosc * 0.3)); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 7 / 10, y0 + (int)(dlugosc * 0.3)); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 1 / 10, y0 + (int)(dlugosc * 0.4)); Console.Write("4");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + (int)(dlugosc * 0.4)); Console.Write("5");
                Console.SetCursorPosition(x0 + szerokosc * 9 / 10, y0 + (int)(dlugosc * 0.4)); Console.Write("6");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + (int)(dlugosc * 0.6)); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + (int)(dlugosc * 0.6)); Console.Write("8");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + (int)(dlugosc * 0.6)); Console.Write("9");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + (int)(dlugosc * 0.6)); Console.Write("10");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + (int)(dlugosc * 0.85)); Console.Write("11");
            }
            if (druzyna.tactics.formation == Tactics.formations[1])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 3 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 7 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 1 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("5");
                Console.SetCursorPosition(x0 + szerokosc * 9 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("6");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("9");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("11");
            }
            if (druzyna.tactics.formation == Tactics.formations[2])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("5");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 3 / 10, y0 + dlugosc * 5 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + szerokosc * 7 / 10, y0 + dlugosc * 5 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 1 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("9");
                Console.SetCursorPosition(x0 + szerokosc * 9 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("10");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("11");
            }
            if (druzyna.tactics.formation == Tactics.formations[3])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("5");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("9");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 3 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("11");
            }
            if (druzyna.tactics.formation == Tactics.formations[4])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 1 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + szerokosc * 9 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("5");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("8");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("9");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("11");
            }
            if (druzyna.tactics.formation == Tactics.formations[5])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 3 / 10 + u); Console.Write("4");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 3 / 10, y0 + dlugosc * 5 / 10 + u); Console.Write("5");
                Console.SetCursorPosition(x0 + szerokosc * 7 / 10, y0 + dlugosc * 5 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + szerokosc * 1 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + szerokosc * 9 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("9");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 3 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + szerokosc * 7 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("11");
            }
            if (druzyna.tactics.formation == Tactics.formations[6])
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 4 / 10 + u); Console.Write("4");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + szerokosc * 1 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("5");
                Console.SetCursorPosition(x0 + szerokosc * 4 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + szerokosc * 6 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + szerokosc * 9 / 10, y0 + dlugosc * 6 / 10 + u); Console.Write("8");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + szerokosc * 2 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("9");
                Console.SetCursorPosition(x0 + szerokosc * 5 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + szerokosc * 8 / 10, y0 + dlugosc * 8 / 10 + u); Console.Write("11");
            }
            Console.ResetColor();
        }




        int promien;

        Punkt gornyLewyRogBoiska;
        Punkt gornyPrawyRogBoiska;
        Punkt dolnyLewyRogBoiska;
        Punkt dolnyPrawyRogBoiska;
        Punkt poleKarneGorneLewyPunkt;
        Punkt poleKarneGornePrawyPunkt;
        //Punkt srodekBoiska;
        Punkt srodekPolokregu;

        Odcinek boiskoLiniaGorna;
        Odcinek boiskoLiniaDolna;
        Odcinek boiskoLiniaLewa;
        Odcinek boiskoLiniaPrawa;
        Odcinek poleKarneGorneDolnaLinia;
        Odcinek poleKarneGorneLewaLinia;
        Odcinek poleKarneGornePrawaLinia;
        //Okrag okragSrodkowy;
        //Okrag polokrag;

        //Punkt lewyPunktLiniiSrodkowej;
        //Punkt prawyPunktLiniiSrodkowej;
        //Punkt poleKarneDolneLewyPunkt;
        //Punkt poleKarneDolnePrawyPunkt;
        //Odcinek poleKarneDolneGornaLinia;
        //Odcinek poleKarneDolneLewaLinia;
        //Odcinek poleKarneDolnePrawaLinia;
        //Odcinek boiskoLiniaSrodkowa;
    }

    class Punkt
    {
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        int x;
        int y;
    }

    class Odcinek
    {
        public Odcinek(Punkt p1, Punkt p2, Pitch b)
        {
            n = b.dlugosc;
            m = b.szerokosc;
            tablica = b.boisko;
            x1 = p1.X;
            y1 = p1.Y;
            x2 = p2.X;
            y2 = p2.Y;
            e = 0;
            dx = Math.Abs(x2 - x1);
            dy = Math.Abs(y2 - y1);
            if (x1 <= x2) kx = 1; else kx = -1;
            if (y1 <= y2) ky = 1; else ky = -1;
            tablica[y1, x1] = 1;
            tablica[y2, x2] = 1;
        }
        public void wykonaj()
        {
            if (x1 <= x2) kx = 1; else kx = -1;
            if (y1 <= y2) ky = 1; else ky = -1;
            tablica[y1, x1] = 1;
            tablica[y2, x2] = 1;
            if (dx < dy)
            {
                e = dy / 2;
                for (int i = 0; i < dy; i++)
                {
                    y1 = y1 + ky;
                    e = e - dx;
                    if (e >= 0) tablica[y1, x1] = 1;
                    else
                    {
                        x1 = x1 + kx;
                        e = e + dy;
                        tablica[y1, x1] = 1;
                    }
                }
            }
            else
            {
                e = dx / 2;
                for (int i = 0; i < dx; i++)
                {
                    x1 = x1 + kx;
                    e = e - dy;
                    if (e >= 0) tablica[y1, x1] = 1;
                    else
                    {
                        y1 = y1 + ky;
                        e = e + dx;
                        tablica[y1, x1] = 1;
                    }
                }
            }
        }

        int n;
        int m;
        int[,] tablica;
        int x1;
        int y1;
        int x2;
        int y2;
        int kx;
        int ky;
        int e;
        int dx;
        int dy;
    }

    class Okrag
    {
        int n;
        int m;
        int[,] tablica;
        int xC;
        int yC;
        int R;
        int x;
        int y;
        int d;
        int d1;
        int d2;
        public Okrag(Punkt p, int R, Pitch b)
        {
            n = b.dlugosc;
            m = b.szerokosc;
            tablica = b.boisko;
            this.xC = p.X;
            this.yC = p.Y;
            this.R = R;
            x = 0;
            y = R;
            d = 1 - R;
            d1 = 3;
            d2 = -2 * R + 5;
        }
        public void wykonaj()
        {
            tablica[yC + y, xC + x] = 1;
            tablica[yC - y, xC + x] = 1;
            tablica[yC + x, xC - y] = 1;
            tablica[yC + x, xC + y] = 1;

            while (y > x)
            {
                if (d < 0)
                {
                    d = d + d1;
                    d1 = d1 + 2;
                    d2 = d2 + 2;
                    x = x + 1;
                }
                else
                {
                    d = d + d2;
                    d1 = d1 + 2;
                    d2 = d2 + 4;
                    x = x + 1;
                    y = y - 1;
                }
                tablica[yC + y, xC + x] = 1;
                tablica[yC + y, xC - x] = 1;
                tablica[yC - y, xC + x] = 1;
                tablica[yC - y, xC - x] = 1;

                tablica[yC + x, xC + y] = 1;
                tablica[yC + x, xC - y] = 1;
                tablica[yC - x, xC + y] = 1;
                tablica[yC - x, xC - y] = 1;
            }
        }
    }
}
