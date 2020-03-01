using System.Windows.Controls;

namespace LabyrinthNS
{
    class Medkit : SpecialCell
    {
        public Medkit(int x = 0, int y = 0) : base(x, y) { }

        public override void Action(Player player)
        {
            if (base.CheckForIntersectionWithPlayer(player))
            {
                player.livesCounter++;
            }
        }

        public override void Draw(Canvas mCanvas, string imageURI)
        {
            base.Draw(mCanvas, imageURI);
        }
    }
}
