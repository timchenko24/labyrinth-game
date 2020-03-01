using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LabyrinthNS
{
    class SpecialCellsManager
    {
        List<SpecialCell> m_specialCellsList;

        public SpecialCellsManager()
        {
            m_specialCellsList = new List<SpecialCell>();
        }

        public void RandomGeneration(Cell[,] labyrinthArray)
        {
            Random rand = new Random();

            for (int i = 0; i < labyrinthArray.GetLength(0); i++)
            {
                switch (rand.Next(6))
                {
                    case 0:
                        m_specialCellsList.Add(new Teleport());
                        break;
                    case 1:
                        m_specialCellsList.Add(new Undead());;
                        break;
                    case 2:
                        m_specialCellsList.Add(new Bandit()); ;
                        break;
                    case 3:
                        m_specialCellsList.Add(new Medkit()); ;
                        break;
                    case 4:
                        m_specialCellsList.Add(new Grave()); ;
                        break;
                    case 5:
                        m_specialCellsList.Add(new God()); ;
                        break;
                }
            }
        }

        public void RandomPositionArrange(Cell[,] labyrinthArray)
        {
            int[,] emptyArray = new int[labyrinthArray.GetLength(0), labyrinthArray.GetLength(1)];
            Random rand = new Random();
            int coordX;
            int coordY;
            for (int i = 0; i < m_specialCellsList.Count; i++)
            {
                do
                {
                    coordX = rand.Next(1, emptyArray.GetLength(0) - 1);
                    coordY = rand.Next(1, emptyArray.GetLength(1) - 1);
                } while (emptyArray[coordX, coordY] == 1);

                switch (m_specialCellsList[i].GetType().Name.ToString())
                {
                    case "Teleport":
                        m_specialCellsList[i] = new Teleport(coordX, coordY);
                        break;
                    case "Undead":
                        m_specialCellsList[i] = new Undead(coordX, coordY);
                        break;
                    case "Bandit":
                        m_specialCellsList[i] = new Bandit(coordX, coordY);
                        break;
                    case "Medkit":
                        m_specialCellsList[i] = new Medkit(coordX, coordY);
                        break;
                    case "Grave":
                        m_specialCellsList[i] = new Grave(coordX, coordY);
                        break;
                    case "God":
                        m_specialCellsList[i] = new God(coordX, coordY);
                        break;
                }
                emptyArray[coordX, coordY] = 1;
            }
        }

        public void Render(Canvas mCanvas)
        {
            foreach (var item in m_specialCellsList)
            {
                switch (item.GetType().Name.ToString())
                {
                    case "Teleport":
                        item.Draw(mCanvas, "teleport.png");
                        break;
                    case "Undead":
                        item.Draw(mCanvas, "undead.png");
                        break;
                    case "Bandit":
                        item.Draw(mCanvas, "bandit.png");
                        break;
                    case "Medkit":
                        item.Draw(mCanvas, "medkit.png");
                        break;
                    case "Grave":
                        item.Draw(mCanvas, "grave.png");
                        break;
                    case "God":
                        item.Draw(mCanvas, "god.png");
                        break;
                }
            }
        }

        public void CheckForIntersectionWithPlayer(Player player, Cell[,] labyrinth, Canvas mCanvas)
        {
            foreach (var item in m_specialCellsList)
            {
                switch (item.GetType().Name.ToString())
                {
                    case "Teleport":
                        item.Action(labyrinth, player, mCanvas);
                        break;
                    case "Undead":
                        item.Action(labyrinth, player);
                        break;
                    case "Bandit":
                        item.Action(player);
                        break;
                    case "Medkit":
                        item.Action(player);
                        break;
                    case "Grave":
                        item.Action(player);
                        break;
                    case "God":
                        item.Action(player);
                        break;
                }
            }
        }
    }
}
