using System.Windows;
using System.Windows.Controls;

namespace LabyrinthNS
{
    class God : SpecialCell
    {
        public God(int x = 0, int y = 0) : base(x, y) { }

        public override void Action(Player player)
        {
            if (base.CheckForIntersectionWithPlayer(player))
            {
                MessageBox.Show("Вы выиграли!");
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
