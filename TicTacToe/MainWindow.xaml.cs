using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private List<Button> _buttons = new List<Button>();
        private Char _symbolOnThisTurn;
        private int _xWin;
        private int _oWin;

        public MainWindow()
        {
            InitializeComponent();
            foreach (Button button in Buttons.Children)
            {
                button.Click += Click_ButtonClick;
                _buttons.Add(button);
            }
            _xWin = 0;
            _oWin = 0;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click_ButtonClick(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)e.OriginalSource).Content;
            ((Button)e.OriginalSource).IsEnabled = false;

            if (buttonContent == "✕" || buttonContent == "◯")
            {
                return;
            }
            if (_symbolOnThisTurn == '◯')
            {
                ((Button)e.OriginalSource).Content = "◯";
                _symbolOnThisTurn = '✕';
                GameOwer();
            }
            else
            {
                ((Button)e.OriginalSource).Content = "✕";
                _symbolOnThisTurn = '◯';
                GameOwer();
            }
        }

        private void GameOwer()
        {
            string emptyCage = "_";
            if (_buttons[0].Content == _buttons[1].Content && _buttons[1].Content == _buttons[2].Content && _buttons[0].Content != emptyCage ||
                _buttons[3].Content == _buttons[4].Content && _buttons[4].Content == _buttons[5].Content && _buttons[3].Content != emptyCage ||
                _buttons[6].Content == _buttons[7].Content && _buttons[7].Content == _buttons[8].Content && _buttons[6].Content != emptyCage ||
                _buttons[0].Content == _buttons[3].Content && _buttons[3].Content == _buttons[6].Content && _buttons[0].Content != emptyCage ||
                _buttons[1].Content == _buttons[4].Content && _buttons[4].Content == _buttons[7].Content && _buttons[1].Content != emptyCage ||
                _buttons[2].Content == _buttons[5].Content && _buttons[5].Content == _buttons[8].Content && _buttons[2].Content != emptyCage ||
                _buttons[0].Content == _buttons[4].Content && _buttons[4].Content == _buttons[8].Content && _buttons[0].Content != emptyCage ||
                _buttons[2].Content == _buttons[4].Content && _buttons[4].Content == _buttons[6].Content && _buttons[2].Content != emptyCage)
            {
                foreach (Button button in _buttons)
                {
                    button.IsEnabled = false;
                }

                if (_symbolOnThisTurn == '◯')
                {
                    _xWin += 1;
                }
                else
                {
                    _oWin += 1;
                }

                XLabel.Content = $"✕ win: {Convert.ToString(_xWin)}";
                OLabel.Content = $"◯ win: {Convert.ToString(_oWin)}";
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in _buttons)
            {
                button.IsEnabled = true;
                button.Content = "_";
                _symbolOnThisTurn = '✕';
            }
        }
    }
}
