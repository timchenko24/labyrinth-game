using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace LabyrinthNS
{
    class Player
    {
        static Player instance;

        Point m_drawPosition;
        Point m_arrayPosition;
        System.Windows.Shapes.Rectangle m_rect;
        int m_livesCounter;

        public int livesCounter
        {
            get { return m_livesCounter; }
            set { m_livesCounter = value; }
        }

        public Point arrayPosition
        {
            get { return m_arrayPosition; }
            set { m_arrayPosition = value; }
        }

        public Player()
        {
            m_drawPosition = new Point(1, 1);
            m_arrayPosition = new Point(0, 0);
            m_livesCounter = 3;
            m_rect = new System.Windows.Shapes.Rectangle();
            m_rect.Width = 18;
            m_rect.Height = 18;
        }

        public static Player GetInstance()
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }

        public void MoveRight(Cell[,] labyrinth)
        {
            if (CheckForRightCollision(labyrinth))
            {
                Canvas.SetLeft(m_rect, m_drawPosition.X += 20);
                m_arrayPosition.X++;
            }
        }

        public void MoveLeft(Cell[,] labyrinth)
        {
            if (CheckForLeftCollision(labyrinth))
            {
                Canvas.SetLeft(m_rect, m_drawPosition.X -= 20);
                m_arrayPosition.X--;
            }
        }

        public void MoveUp(Cell[,] labyrinth)
        {
            if (CheckForTopCollision(labyrinth))
            {
                Canvas.SetTop(m_rect, m_drawPosition.Y -= 20);
                m_arrayPosition.Y--;
            }   
        }

        public void MoveDown(Cell[,] labyrinth)
        {
            if (CheckForBottomCollision(labyrinth))
            {
                Canvas.SetTop(m_rect, m_drawPosition.Y += 20);
                m_arrayPosition.Y++;
            }
        }

        public void DrawPosition(Canvas mCanvas)
        {
            m_rect.Stroke = new SolidColorBrush(Colors.Red);
            m_rect.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(m_rect, m_drawPosition.X);
            Canvas.SetTop(m_rect, m_drawPosition.Y);
            mCanvas.Children.Add(m_rect);
        }

        public void UpdatePosition(Canvas mCanvas)
        {
            m_drawPosition.X = m_arrayPosition.X * 20 + 1;
            m_drawPosition.Y = m_arrayPosition.Y * 20 + 1;
            Canvas.SetLeft(m_rect, m_drawPosition.X);
            Canvas.SetTop(m_rect, m_drawPosition.Y);
        }

        private bool CheckForTopCollision(Cell[,] labyrinth)
        {
            return labyrinth[m_arrayPosition.X, m_arrayPosition.Y].Top == CellState.Open;
        }

        private bool CheckForBottomCollision(Cell[,] labyrinth)
        {
            return labyrinth[m_arrayPosition.X, m_arrayPosition.Y].Bottom == CellState.Open;
        }

        private bool CheckForRightCollision(Cell[,] labyrinth)
        {
            return labyrinth[m_arrayPosition.X, m_arrayPosition.Y].Right == CellState.Open;
        }

        private bool CheckForLeftCollision(Cell[,] labyrinth)
        {
            return labyrinth[m_arrayPosition.X, m_arrayPosition.Y].Left == CellState.Open;
        }

        public void UpdateLivesCounter(Label lbl)
        {
            lbl.Content = string.Format("Lives:\n{0}", m_livesCounter);
        }
        
        public void CheckForLoose()
        {
            if (m_livesCounter < 1)
            {
                System.Windows.MessageBox.Show("Вы проиграли!");
                System.Windows.Application.Current.Shutdown();
                System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            }
        }
    }
}
