using System.Windows;

namespace LabyrinthNS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player = Player.GetInstance();
        Labyrinth labyrinth = LabyrinthNS.Labyrinth.GetInstance();
        SpecialCellsManager manager = new SpecialCellsManager();

        public MainWindow()
        {
            InitializeComponent();
            labyrinth.RandomGeneration();
            labyrinth.Render(cnvsLabyrinth);
            player.DrawPosition(cnvsLabyrinth);
            lblLivesCounter.Content += string.Format("\n{0}", player.livesCounter);
            manager.RandomGeneration(labyrinth.cellsArray);
            manager.RandomPositionArrange(labyrinth.cellsArray);
            manager.Render(cnvsLabyrinth);
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            player.MoveUp(labyrinth.cellsArray);
            manager.CheckForIntersectionWithPlayer(player, labyrinth.cellsArray, cnvsLabyrinth);
            player.UpdateLivesCounter(lblLivesCounter);
            player.CheckForLoose();
            labyrinth.CheckForPlayerWin(player);
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            player.MoveRight(labyrinth.cellsArray);
            manager.CheckForIntersectionWithPlayer(player, labyrinth.cellsArray, cnvsLabyrinth);
            player.UpdateLivesCounter(lblLivesCounter);
            player.CheckForLoose();
            labyrinth.CheckForPlayerWin(player);
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            player.MoveDown(labyrinth.cellsArray);
            manager.CheckForIntersectionWithPlayer(player, labyrinth.cellsArray, cnvsLabyrinth);
            player.UpdateLivesCounter(lblLivesCounter);
            player.CheckForLoose();
            labyrinth.CheckForPlayerWin(player);
        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            player.MoveLeft(labyrinth.cellsArray);
            manager.CheckForIntersectionWithPlayer(player, labyrinth.cellsArray, cnvsLabyrinth);
            player.UpdateLivesCounter(lblLivesCounter);
            player.CheckForLoose();
            labyrinth.CheckForPlayerWin(player);
        }
    }
}
