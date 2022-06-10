using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wordle
{
    /// <summary>
    /// Interaction logic for DetailedSearch.xaml
    /// </summary>
    public partial class DetailedSearch : Window
    {
        MainWindow mw;
        public DetailedSearch(MainWindow previous)
        {
            mw = previous;
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ThereIsNoLogicalFallacy())
            {

            }

        }

        private bool ThereIsNoLogicalFallacy()
        {

            for (int i = 0; i < LettersNotInIt.Text.Length; i++)
            {
                if (LettersInPlace.Text.Contains(LettersNotInIt.Text[i]) || LettersNotInPlace.Text.Contains(LettersNotInIt.Text[i]))
                {
                    return false;
                }
            }

            for (int i = 0; i < LettersInPlace.Text.Length; i++)
            {
                if (LettersInPlace.Text[i] != ' ')
                {
                    for (int j = 0; j < LettersNotInPlace.Text.Length; j++)
                    {
                        if (LettersNotInPlace.Text[j] != ' ')
                        {

                        }
                    }
                }
            }


            return true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mw.Show();
        }

        private bool CorrectInput(string Input)
        {
            Regex onlyLetters = new Regex(@"^[a-z A-Z]+$");
            return onlyLetters.IsMatch(Input);
        }

        private void LettersInPlace_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CorrectInput(LettersInPlace.Text) && LettersInPlace.Text != string.Empty)
            {
                MessageBox.Show($"The input isn't a letter or a space", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                LettersInPlace.Text = new Regex(@"[^a-z ]").Replace(LettersInPlace.Text, "");
            }
        }

        private void LettersNotInPlace_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CorrectInput(LettersNotInPlace.Text) && LettersNotInPlace.Text != string.Empty)
            {
                MessageBox.Show($"The input isn't a letter or a space", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                LettersNotInPlace.Text = new Regex(@"[^a-z ]").Replace(LettersNotInPlace.Text, "");
            }
        }

        private void LettersNotInIt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex OnlyLettersWithoutSpace = new Regex(@"^[a-zA-Z]+$");
            if (!OnlyLettersWithoutSpace.IsMatch(LettersNotInIt.Text) && LettersNotInIt.Text != string.Empty)
            {
                MessageBox.Show($"The input isn't a letter.\nPlease don't use spaces, the place of these letters are not important.", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                LettersNotInIt.Text = new Regex(@"[^a-z]").Replace(LettersNotInIt.Text, "");
            }
        }
    }
}
