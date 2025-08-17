using System;

namespace FootballManager
{
    class Pitch
    {
        public int[,] boisko { get; private set; }
        public int Length { get; private set; }
        public int Width { get; private set; }

        public Pitch(int length, int width)
        {
            this.Length = length;
            this.Width = width;
        }
        public Pitch(int length, int width, int radius)
        {
            this.Length = length;
            this.Width = width;
            this.radius = radius;
            boisko = new int[length, width];

            pitchTopLeftCorner = new Point(0, 0, '┌');
            pitchTopRightCorner = new Point(width-1, 0, '┐');
            pitchBottomLeftCorner = new Point(0, length-1, '└');
            pitchBottomRightCorner = new Point(width-1, length-1, '┘');
            topPenaltyAreaTopLeftCorner = new Point(width * 1 / 4, 0, '┬');
            topPenaltyAreaTopRightCorner = new Point(width * 3 / 4, 0, '┬');
            topPenaltyAreaBottomLeftCorner = new Point(width * 1 / 4, length / 5, '└');
            topPenaltyAreaBottomRightCorner = new Point(width * 3 / 4, length / 5, '┘');
            pitchCenter = new Point((width - 1) / 2, length - 1);
            topCircleCenter = new Point(width / 2, length / 5);

            pitchTopLine = new Line(pitchTopLeftCorner, pitchTopRightCorner, '─');
            pitchBottomLine = new Line(pitchBottomLeftCorner, pitchBottomRightCorner, '─');
            pitchLeftLine = new Line(pitchTopLeftCorner, pitchBottomLeftCorner, '│');
            pitchRightLine = new Line(pitchTopRightCorner, pitchBottomRightCorner, '│');
            topPenaltyAreaLeftLine = new Line(topPenaltyAreaTopLeftCorner, topPenaltyAreaBottomLeftCorner, '│');
            topPenaltyAreaRightLine = new Line(topPenaltyAreaTopRightCorner, topPenaltyAreaBottomRightCorner, '│');
            topPenaltyAreaBottomLine = new Line(topPenaltyAreaBottomLeftCorner, topPenaltyAreaBottomRightCorner, '─');
        }

        public void Draw(int x0, int y0)
        {
            for (int y = 0; y < Length; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.SetCursorPosition(x0 + x, y0 + y);
                    Console.SetBackgroundColor(ConsoleColor.Green);
                    Console.Write(' ');
                }
            }
            pitchTopLine.Draw(x0, y0);
            pitchBottomLine.Draw(x0, y0);
            pitchLeftLine.Draw(x0, y0);
            pitchRightLine.Draw(x0, y0);
            topPenaltyAreaLeftLine.Draw(x0, y0);
            topPenaltyAreaRightLine.Draw(x0, y0);
            topPenaltyAreaBottomLine.Draw(x0, y0);
            pitchTopLeftCorner.Draw(x0, y0);
            pitchTopRightCorner.Draw(x0, y0);
            pitchBottomLeftCorner.Draw(x0, y0);
            pitchBottomRightCorner.Draw(x0, y0);
            topPenaltyAreaTopLeftCorner.Draw(x0, y0);
            topPenaltyAreaTopRightCorner.Draw(x0, y0);
            topPenaltyAreaBottomLeftCorner.Draw(x0, y0);
            topPenaltyAreaBottomRightCorner.Draw(x0, y0);
        }

        public void WriteNumbers(int x0, int y0, Club team)
        {
            int u = 0;
            //if (druzyna.tactics.posture == Tactics.postures[1]) u = -1;
            //if (druzyna.tactics.posture == Tactics.postures[3]) u = 1;
            Window.setColor(Position.goalkeeper);
            Console.SetCursorPosition(x0 + topCircleCenter.X, y0 + topCircleCenter.Y / 2); Console.Write("1");
            if (team.tactics.formation == Tactics.formations[0]) // 5-4-1
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 3 / 10, y0 + (int)(Length * 0.3)); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 7 / 10, y0 + (int)(Length * 0.3)); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 1 / 10, y0 + (int)(Length * 0.4)); Console.Write("4");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + (int)(Length * 0.4)); Console.Write("5");
                Console.SetCursorPosition(x0 + Width * 9 / 10, y0 + (int)(Length * 0.4)); Console.Write("6");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + (int)(Length * 0.6)); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + (int)(Length * 0.6)); Console.Write("8");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + (int)(Length * 0.6)); Console.Write("9");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + (int)(Length * 0.6)); Console.Write("10");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + (int)(Length * 0.85)); Console.Write("11");
            }
            if (team.tactics.formation == Tactics.formations[1]) //  5-3-2
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 3 / 10, y0 + Length * 3 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 7 / 10, y0 + Length * 3 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 1 / 10, y0 + Length * 4 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 4 / 10 + u); Console.Write("5");
                Console.SetCursorPosition(x0 + Width * 9 / 10, y0 + Length * 4 / 10 + u); Console.Write("6");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 6 / 10 + u); Console.Write("9");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + Length * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 8 / 10 + u); Console.Write("11");
            }
            if (team.tactics.formation == Tactics.formations[2]) // 4-5-1
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 3 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + Length * 3 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 3 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 3 / 10 + u); Console.Write("5");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 3 / 10, y0 + Length * 5 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + Width * 7 / 10, y0 + Length * 5 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 1 / 10, y0 + Length * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 6 / 10 + u); Console.Write("9");
                Console.SetCursorPosition(x0 + Width * 9 / 10, y0 + Length * 6 / 10 + u); Console.Write("10");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 8 / 10 + u); Console.Write("11");
            }
            if (team.tactics.formation == Tactics.formations[3]) // 4-4-2
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 4 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + Length * 4 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 4 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 4 / 10 + u); Console.Write("5");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 6 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + Length * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 6 / 10 + u); Console.Write("9");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 3 / 10, y0 + Length * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 8 / 10 + u); Console.Write("11");
            }
            if (team.tactics.formation == Tactics.formations[4]) // 4-3-3
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 1 / 10, y0 + Length * 4 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + Length * 4 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 4 / 10 + u); Console.Write("4");
                Console.SetCursorPosition(x0 + Width * 9 / 10, y0 + Length * 4 / 10 + u); Console.Write("5");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 6 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 6 / 10 + u); Console.Write("8");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 8 / 10 + u); Console.Write("9");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 8 / 10 + u); Console.Write("11");
            }
            if (team.tactics.formation == Tactics.formations[5]) // 3-5-2
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 3 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 3 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 3 / 10 + u); Console.Write("4");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 3 / 10, y0 + Length * 5 / 10 + u); Console.Write("5");
                Console.SetCursorPosition(x0 + Width * 7 / 10, y0 + Length * 5 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + Width * 1 / 10, y0 + Length * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 6 / 10 + u); Console.Write("8");
                Console.SetCursorPosition(x0 + Width * 9 / 10, y0 + Length * 6 / 10 + u); Console.Write("9");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 3 / 10, y0 + Length * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + Width * 7 / 10, y0 + Length * 8 / 10 + u); Console.Write("11");
            }
            if (team.tactics.formation == Tactics.formations[6]) // 3-4-3
            {
                Window.setColor(Position.defender);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 4 / 10 + u); Console.Write("2");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 4 / 10 + u); Console.Write("3");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 4 / 10 + u); Console.Write("4");
                Window.setColor(Position.midfielder);
                Console.SetCursorPosition(x0 + Width * 1 / 10, y0 + Length * 6 / 10 + u); Console.Write("5");
                Console.SetCursorPosition(x0 + Width * 4 / 10, y0 + Length * 6 / 10 + u); Console.Write("6");
                Console.SetCursorPosition(x0 + Width * 6 / 10, y0 + Length * 6 / 10 + u); Console.Write("7");
                Console.SetCursorPosition(x0 + Width * 9 / 10, y0 + Length * 6 / 10 + u); Console.Write("8");
                Window.setColor(Position.forward);
                Console.SetCursorPosition(x0 + Width * 2 / 10, y0 + Length * 8 / 10 + u); Console.Write("9");
                Console.SetCursorPosition(x0 + Width * 5 / 10, y0 + Length * 8 / 10 + u); Console.Write("10");
                Console.SetCursorPosition(x0 + Width * 8 / 10, y0 + Length * 8 / 10 + u); Console.Write("11");
            }
            Console.ResetColor();
        }




        int radius;

        private readonly Point pitchTopLeftCorner;
        private readonly Point pitchTopRightCorner;
        private readonly Point pitchBottomLeftCorner;
        private readonly Point pitchBottomRightCorner;
        private readonly Point topPenaltyAreaTopLeftCorner;
        private readonly Point topPenaltyAreaTopRightCorner;
        private readonly Point topPenaltyAreaBottomLeftCorner;
        private readonly Point topPenaltyAreaBottomRightCorner;
        private readonly Point pitchCenter;
        private readonly Point topCircleCenter;

        private readonly Line pitchTopLine;
        private readonly Line pitchBottomLine;
        private readonly Line pitchLeftLine;
        private readonly Line pitchRightLine;
        private readonly Line topPenaltyAreaBottomLine;
        private readonly Line topPenaltyAreaLeftLine;
        private readonly Line topPenaltyAreaRightLine;
    }

    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point(int x, int y, char sign)
        {
            this.X = x;
            this.Y = y;
            this.sign = sign;
        }

        public void Draw(int x0, int y0)
        {
            //Console.SetForegroundColor(ConsoleColor.White);
            //Console.SetBackgroundColor(ConsoleColor.Green);
            Console.SetCursorPosition(x0 + X, y0 + Y);
            Console.Write(sign);
        }

        private readonly char sign;
    }

    class Line
    {
        public Line(Point p1, Point p2, char sign)
        {
            this.sign = sign;
            x1 = p1.X;
            y1 = p1.Y;
            x2 = p2.X;
            y2 = p2.Y;
            e = 0;
            dx = Math.Abs(x2 - x1);
            dy = Math.Abs(y2 - y1);
            if (x1 <= x2) kx = 1; else kx = -1;
            if (y1 <= y2) ky = 1; else ky = -1;
        }
        public void Draw(int x0, int y0)
        {
            x1 = x1 + x0;
            y1 = y1 + y0;
            x2 = x2 + x0;
            y2 = y2 + y0;
            if (x1 <= x2) kx = 1; else kx = -1;
            if (y1 <= y2) ky = 1; else ky = -1;
            Console.SetCursorPosition(x1, y1);
            Console.Write(sign);
            Console.SetCursorPosition(x2, y2);
            Console.Write(sign);
            if (dx < dy)
            {
                e = dy / 2;
                for (int i = 0; i < dy; i++)
                {
                    y1 = y1 + ky;
                    e = e - dx;
                    if (e < 0)
                    {
                        x1 = x1 + kx;
                        e = e + dy;
                    }
                    Console.SetCursorPosition(x1, y1);
                    Console.Write(sign);
                }
            }
            else
            {
                e = dx / 2;
                for (int i = 0; i < dx; i++)
                {
                    x1 += kx;
                    e -= dy;
                    if (e < 0)
                    {
                        y1 += ky;
                        e =+ dx;
                    }
                    Console.SetCursorPosition(x1, y1);
                    Console.Write(sign);
                }
            }
        }

        private char sign;
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        private int kx;
        private int ky;
        private int e;
        private int dx;
        private int dy;
    }

    class Circle
    {
        int[,] tablica;
        int xC;
        int yC;
        int R;
        int x;
        int y;
        int d;
        int d1;
        int d2;
        public Circle(Point p, int R, Pitch b)
        {
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
