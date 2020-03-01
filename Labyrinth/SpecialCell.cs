using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace LabyrinthNS
{
    abstract class SpecialCell
    {
        Point m_position;

        public SpecialCell(int x, int y)
        {
            m_position.X = x;
            m_position.Y = y;
        }

        public virtual void Action(Cell[,] labyrinth, Player player, Canvas mCanvas) { }

        public virtual void Action(Player player) { }

        public virtual void Action(Cell[,] labyrinth, Player player) { }

        public virtual bool CheckForIntersectionWithPlayer(Player player)
        {
            return (m_position.X == player.arrayPosition.X && m_position.Y == player.arrayPosition.Y) ? true : false;
        }

        public virtual void Draw(Canvas mCanvas, string imageURI)
        {
            BitmapImage img = new BitmapImage(new Uri(imageURI, UriKind.Relative));
            System.Windows.Controls.Image Img = new System.Windows.Controls.Image();
            Img.Source = img;
            Img.Height = 18;
            Img.Width = 18;
            Canvas.SetTop(Img, m_position.Y * 20);
            Canvas.SetLeft(Img, m_position.X * 20);
            mCanvas.Children.Add(Img);
        }
    }
}
