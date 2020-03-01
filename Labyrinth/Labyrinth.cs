using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace LabyrinthNS
{
    class Labyrinth
    {
        static Labyrinth instance;

        private int m_width, m_height;
        private Cell[,] m_cellsArray;

        public Cell[,] cellsArray
        {
            get { return m_cellsArray; }
            set { m_cellsArray = value; }
        }

        public static Labyrinth GetInstance()
        {
            if (instance == null)
                instance = new Labyrinth();
            return instance;
        }

        public void RandomGeneration()
        {
            m_width = 20;
            m_height = 20;
            m_cellsArray = new Cell[m_width, m_height];
            Random rand = new Random();
            int startX = rand.Next(m_width);
            int startY = rand.Next(m_height);

            Stack<Cell> path = new Stack<Cell>();

            for (int y = 0; y < m_height; y++)
            {
                for (int x = 0; x < m_width; x++)
                {
                    m_cellsArray[x, y] = new Cell(new System.Drawing.Point(x, y));
                }
            }

            m_cellsArray[startX, startY].Visited = true;
            path.Push(m_cellsArray[startX, startY]);

            while (path.Count > 0)
            {
                Cell _cell = path.Peek();

                List<Cell> nextStep = new List<Cell>();
                if (_cell.Position.X > 0 && !m_cellsArray[(_cell.Position.X - 1), (_cell.Position.Y)].Visited)
                {
                    nextStep.Add(m_cellsArray[(_cell.Position.X) - 1, (_cell.Position.Y)]);
                }

                if (_cell.Position.X < m_width - 1 && !m_cellsArray[(_cell.Position.X) + 1, (_cell.Position.Y)].Visited)
                {
                    nextStep.Add(m_cellsArray[(_cell.Position.X) + 1, (_cell.Position.Y)]);
                }

                if (_cell.Position.Y > 0 && !m_cellsArray[(_cell.Position.X), (_cell.Position.Y) - 1].Visited)
                {
                    nextStep.Add(m_cellsArray[(_cell.Position.X), (_cell.Position.Y) - 1]);
                }
                    
                if (_cell.Position.Y < m_height - 1 && !m_cellsArray[(_cell.Position.X), (_cell.Position.Y) + 1].Visited)
                {
                    nextStep.Add(m_cellsArray[(_cell.Position.X), (_cell.Position.Y) + 1]);
                }

                if (nextStep.Count() > 0)
                {
                    Cell next = nextStep[rand.Next(nextStep.Count())];

                    if (next.Position.X != _cell.Position.X)
                    {
                        if (_cell.Position.X - next.Position.X > 0)
                        {
                            _cell.Left = CellState.Open;
                            next.Right = CellState.Open;
                        }
                        else
                        {
                            _cell.Right = CellState.Open;
                            next.Left = CellState.Open;
                        }
                    }
                    if (next.Position.Y != _cell.Position.Y)
                    {
                        if (_cell.Position.Y - next.Position.Y > 0)
                        {
                            _cell.Top = CellState.Open;
                            next.Bottom = CellState.Open;
                        }
                        else
                        {
                            _cell.Bottom = CellState.Open;
                            next.Top = CellState.Open;
                        }
                    }

                    next.Visited = true;
                    path.Push(next);
                }
                else
                {
                    path.Pop();
                }
            }
        }

        public void Render(Canvas mCanvas)
        {
            mCanvas.Height = m_height * 20;
            mCanvas.Width = m_width * 20;

            for (int y = 0; y < m_height; y++)
            {
                for (int x = 0; x < m_width; x++)
                {
                    if (m_cellsArray[x, y].Top == CellState.Close)
                        mCanvas.Children.Add(new Line()
                        {
                            Stroke = System.Windows.Media.Brushes.Black,
                            StrokeThickness = 1,
                            X1 = 20 * x,
                            Y1 = 20 * y,
                            X2 = 20 * x + 20,
                            Y2 = 20 * y,
                        });

                    if (m_cellsArray[x, y].Left == CellState.Close)
                        mCanvas.Children.Add(new Line()
                        {
                            Stroke = System.Windows.Media.Brushes.Black,
                            StrokeThickness = 1,
                            X1 = 20 * x,
                            Y1 = 20 * y,
                            X2 = 20 * x,
                            Y2 = 20 * y + 20
                        });

                    if (m_cellsArray[x, y].Right == CellState.Close)
                        mCanvas.Children.Add(new Line()
                        {
                            Stroke = System.Windows.Media.Brushes.Black,
                            StrokeThickness = 1,
                            X1 = 20 * x + 20,
                            Y1 = 20 * y,
                            X2 = 20 * x + 20,
                            Y2 = 20 * y + 20
                        });

                    if (m_cellsArray[x, y].Bottom == CellState.Close)
                        mCanvas.Children.Add(new Line()
                        {
                            Stroke = System.Windows.Media.Brushes.Black,
                            StrokeThickness = 1,
                            X1 = 20 * x,
                            Y1 = 20 * y + 20,
                            X2 = 20 * x + 20,
                            Y2 = 20 * y + 20
                        });
                }
            }
            DrawEnd(mCanvas);
        }

        private void DrawEnd(Canvas mCanvas)
        {
            System.Windows.Shapes.Rectangle labyrinthEnd = new System.Windows.Shapes.Rectangle();
            labyrinthEnd.Width = 18;
            labyrinthEnd.Height = 18;
            labyrinthEnd.Stroke = new SolidColorBrush(Colors.LightGreen);
            labyrinthEnd.Fill = new SolidColorBrush(Colors.LightGreen);
            Canvas.SetRight(labyrinthEnd, 1);
            Canvas.SetBottom(labyrinthEnd, 1);
            mCanvas.Children.Add(labyrinthEnd);
        }

        public void CheckForPlayerWin(Player player)
        {
            if (player.arrayPosition.X == m_cellsArray.GetLength(0) - 1 
                && player.arrayPosition.Y == m_cellsArray.GetLength(1) - 1)
            {
                MessageBox.Show("Вы выиграли!");
                Application.Current.Shutdown();
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            }
        }
    }
}