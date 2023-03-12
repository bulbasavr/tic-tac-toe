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

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private Char _symbolOnThisTurn;
        private int _xWin;
        private int _yWin;


        public MainWindow()
        {
            InitializeComponent();

            foreach (Button button in Buttons.Children)
            {
                button.Click += Click_ButtonClick;
            }
            _xWin = 0;
            _yWin = 0;

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

            if (buttonContent == "X" || buttonContent == "0")
            {
                return;
            }
            if (_symbolOnThisTurn == '0')
            {
                ((Button)e.OriginalSource).Content = "0";
                _symbolOnThisTurn = 'X';
            }
            else
            {
                ((Button)e.OriginalSource).Content = "X";
                _symbolOnThisTurn = '0';
            }
        }
    }
}
