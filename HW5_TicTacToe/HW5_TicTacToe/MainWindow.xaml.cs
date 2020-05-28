using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW5_TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Turn;
        char[,] TicTacToeMatrix;
        private readonly char P1 = 'X';
        private readonly char P2 = 'O';
        char CurrentPlayer;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content == null)
            {
                string tag = button.Tag.ToString();
                var rowCol = tag.Split(',');
                int row = int.Parse(rowCol[0]);
                int col = int.Parse(rowCol[1]);

                UpdateGameBoard(button, row, col);
                if (!IsAWinner(CurrentPlayer, row, col) && !IsDrawGame())
                {
                    NextPlayer();
                }
            }
        }

        private void NewGame()
        {
            Turn = 0;
            uxGrid.IsEnabled = true;
            ClearGrid();
            TicTacToeMatrix = new char[3, 3];

            CurrentPlayer = P1;
            UpdateTurnStatus(CurrentPlayer);
        }

        private void ClearGrid()
        {
            foreach (var child in uxGrid.Children)
            {
                var button = child as Button;
                button.Content = null;
            }
        }

        private void UpdateGameBoard(Button button, int row, int col)
        {
            button.Content = CurrentPlayer;
            TicTacToeMatrix[row, col] = CurrentPlayer;
        }

        private bool IsDrawGame()
        {
            if (Turn >= 8)
            {
                GameOver("Draw Game. Start a New Game.");
                return true;
            }

            return false;
        }

        private void NextPlayer()
        {
            Turn++;
            CurrentPlayer = (CurrentPlayer == P1) ? P2 : P1;
            UpdateTurnStatus(CurrentPlayer);
        }

        private void UpdateTurnStatus(char player)
        {
            uxTurn.Text = $"{player}'s turn.";
        }

        private bool IsAWinner(char player, int row, int col)
        {
            if (InARow(player, row) || InAColumn(player, col) || InADiagonal(player) || InOtherDiagonal(player))
            {
                GameOver($"{player} is a Winner!");
                return true;
            }

            return false;
        }

        private bool InARow(char player, int row)
        {
            for (int col = 0; col < TicTacToeMatrix.GetLength(1); col++)
            {
                if (TicTacToeMatrix[row, col] != player)
                {
                    return false;
                }
            }
            return true;
        }

        private bool InAColumn(char player, int col)
        {
            for (int row = 0; row < TicTacToeMatrix.GetLength(0); row++)
            {
                if (TicTacToeMatrix[row, col] != player)
                {
                    return false;
                }
            }
            return true;
        }

        private bool InADiagonal(char player)
        {
            int row = TicTacToeMatrix.GetLength(0);

            for (int i = 0; i < row; i++)
            {
                if (TicTacToeMatrix[i,i] != player)
                {
                    return false;
                }
            }

            return true;
        }

        private bool InOtherDiagonal(char player)
        {
            int row = TicTacToeMatrix.GetLength(0);
            int col = TicTacToeMatrix.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                if (TicTacToeMatrix[i, --col] != player)
                {
                    return false;
                }
            }
            return true;
        }

        private void GameOver(string message)
        {
            uxTurn.Text = message;
            uxGrid.IsEnabled = false;
        }
    }
}
