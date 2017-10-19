using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co3Tuong
{
    class checkMove
    {
        private bool checkValidMove(Point first, Point last)
        {
            if ((first.X + first.Y) % 2 != 0 && (last.X + last.Y) % 2 != 0)
            {
                return false;
            }
            return true;
        }

        public List<Point> getListMove(int i, int j)
        {
            List<Point> moves = new List<Point>();
            List<Point> eats = new List<Point>();

            #region Find Blank Moves
            // Move to main top diagonal
            if ((i - 1 >= 0) && (j - 1) >= 0
                && checkValidMove(new Point(i, j), new Point(i - 1, j - 1))
                && Cons.map[i - 1, j - 1] == 0)
            {
                moves.Add(new Point(i - 1, j - 1));
            }

            // Move to main down diagonal
            if ((i + 1 < 7) && (j + 1) >= 0
                && checkValidMove(new Point(i, j), new Point(i + 1, j + 1))
                && Cons.map[i + 1, j + 1] == 0)
            {
                moves.Add(new Point(i + 1, j + 1));
            }

            // Move to top diagonal
            if ((i - 1 >= 0) && (j + 1) < 5
                && checkValidMove(new Point(i, j), new Point(i - 1, j + 1))
                && Cons.map[i - 1, j + 1] == 0)
            {
                moves.Add(new Point(i - 1, j + 1));
            }

            // Move to down diagonal
            if ((i + 1 < 7) && (j - 1) >= 0
                && checkValidMove(new Point(i, j), new Point(i + 1, j - 1))
                && Cons.map[i + 1, j - 1] == 0)
            {
                moves.Add(new Point(i + 1, j - 1));
            }

            // Move to left
            if ((j - 1 >= 0) && Cons.map[i, j - 1] == 0)
                moves.Add(new Point(i, j - 1));
            // Move to right
            if ((j + 1 < 5) && Cons.map[i, j + 1] == 0)
                moves.Add(new Point(i, j + 1));
            // Move to top
            if ((i - 1 >= 0) && Cons.map[i - 1, j] == 0)
                moves.Add(new Point(i - 1, j));
            // Move to bottom
            if ((i + 1 < 7) && Cons.map[i + 1, j] == 0)
                moves.Add(new Point(i - 1, j));
            #endregion

            #region Find Eat Moves
            foreach (var point in moves)
            {
                int a1 = point.X - i;
                int a2 = point.Y - j;

                if ((point.X + a1 < 7) && (point.X + a1 >= 0) &&(point.Y + a2 < 7) && (point.Y + a2 >= 0) && Cons.map[point.X + a1, point.Y + a2] == 1)
                    eats.Add(new Point(point.X + a1, point.Y + a2));
            }
            #endregion

            // Phat trien
            eats.AddRange(moves);
            return eats;
        }

    }
}
