using System.Windows;
using System.Windows.Controls;

namespace LabyrinthNS
{
    class Grave : SpecialCell
    {
        public Grave(int x = 0, int y = 0) : base(x, y) { }

        public override void Action(Player player)
        {
            if (base.CheckForIntersectionWithPlayer(player))
            {
                MessageBox.Show("Игра окончена");
                Application.Current.Shutdown();
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            }
        }

        public override void Draw(Canvas mCanvas, string imageURI)
        {
            base.Draw(mCanvas, imageURI);
        }
    }
}
