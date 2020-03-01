using System;
using System.Windows.Controls;


namespace LabyrinthNS
{
    class Undead : SpecialCell
    {
        public Undead(int x = 0, int y = 0) : base(x, y) { }

        public override void Action(Cell[,] labyrinth, Player player)
        {
            if (base.CheckForIntersectionWithPlayer(player))
            {
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    switch (rand.Next(5))
                    {
                        case 0: player.MoveUp(labyrinth);
                            break;
                        case 1: player.MoveDown(labyrinth);
                            break;
                        case 2: player.MoveRight(labyrinth);
                            break;
                        case 3: player.MoveLeft(labyrinth);
                            break;
                    }
                }
            }
        }

        public override void Draw(Canvas mCanvas, string imageURI)
        {
            base.Draw(mCanvas, imageURI);
        }
    }
}
