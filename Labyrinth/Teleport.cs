using System;
using System.Drawing;
using System.Windows.Controls;

namespace LabyrinthNS
{
    class Teleport : SpecialCell
    {
        public Teleport(int x = 0, int y = 0) : base(x, y) { }

        public override void Action(Cell[,] labyrinth, Player player, Canvas mCanvas)
        {
            if (base.CheckForIntersectionWithPlayer(player))
            {
                Random rand = new Random();
                int newXPlayerPosition = rand.Next(labyrinth.GetLength(0));
                int newYPlayerPosition = rand.Next(labyrinth.GetLength(1));
                player.arrayPosition = new Point(newXPlayerPosition, newYPlayerPosition);
                player.UpdatePosition(mCanvas);
            }
        }

        public override void Draw(Canvas mCanvas, string imageURI)
        {
            base.Draw(mCanvas, imageURI);
        }
    }
}
