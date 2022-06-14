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

            List<string> AlphabetLmao = new List<string>() {" ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

            FirstLetter.ItemsSource = AlphabetLmao;
            SecondLetter.ItemsSource = AlphabetLmao;
            ThirdLetter.ItemsSource = AlphabetLmao;
            FourthLetter.ItemsSource = AlphabetLmao;
            FithLetter.ItemsSource = AlphabetLmao;
            WhatLetter.ItemsSource = new List<string>() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            for (int i = 0; i < 5; i++)
            {
                WhereIsItNot.Items.Add(i+1);
            }
        }


        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ThereIsNoLogicalFallacy())
            {
                if ((FirstPlace.Items.Count+SecondPlace.Items.Count+ThirdPlace.Items.Count+FourthPlace.Items.Count+FithPlace.Items.Count) <= 5)
                {
                    string WordThatWeKnowIsInPlaceSoFar = FirstLetter.SelectedItem.ToString().ToLower() + SecondLetter.SelectedItem.ToString().ToLower() + ThirdLetter.SelectedItem.ToString().ToLower() + FourthLetter.SelectedItem.ToString().ToLower() + FithLetter.SelectedItem.ToString().ToLower();
                    
                    List<string> WhatIsNotInFirstPlace = new List<string>();
                    List<string> WhatIsNotInSecondPlace = new List<string>();
                    List<string> WhatIsNotInThirdPlace = new List<string>();
                    List<string> WhatIsNotInFourthPlace = new List<string>();
                    List<string> WhatIsNotInFithPlace = new List<string>();

                    for (int i = 0; i < FirstPlace.Items.Count; i++)
                    {
                        WhatIsNotInFirstPlace.Add(FirstPlace.Items[i].ToString().ToLower());
                    }

                    for (int i = 0; i < SecondPlace.Items.Count; i++)
                    {
                        WhatIsNotInSecondPlace.Add(SecondPlace.Items[i].ToString().ToLower());
                    }

                    for (int i = 0; i < ThirdPlace.Items.Count; i++)
                    {
                        WhatIsNotInThirdPlace.Add(ThirdPlace.Items[i].ToString().ToLower());
                    }

                    for (int i = 0; i < FourthPlace.Items.Count; i++)
                    {
                        WhatIsNotInFourthPlace.Add(FourthPlace.Items[i].ToString().ToLower());
                    }

                    for (int i = 0; i < FithPlace.Items.Count; i++)
                    {
                        WhatIsNotInFithPlace.Add(FithPlace.Items[i].ToString().ToLower());
                    }

                    List<List<string>> ListOfLettersNotInPlace = new List<List<string>>() {WhatIsNotInFirstPlace, WhatIsNotInSecondPlace, WhatIsNotInThirdPlace, WhatIsNotInFourthPlace, WhatIsNotInFithPlace};

                    string StringOfLettersNotInIt = LettersNotInIt.Text.ToLower();

                    SearchResults.ItemsSource = DictionaryCheck.WordleSearch(WordThatWeKnowIsInPlaceSoFar, ListOfLettersNotInPlace, StringOfLettersNotInIt);
                }
                else
                {
                    MessageBox.Show("There must be only 5 possible letters in a word.", "Incorrect inputs", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

                }
            }
            else
            {
                MessageBox.Show("Please check if there are no contradictions in the places of the letters and that you didn't write a letter in the last box, that it is in the word in the.", "Incorrect inputs", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private bool ThereIsNoLogicalFallacy()
        {
            bool Contradicts = false;

            int i = 0;
            while (!Contradicts && i < LettersNotInIt.Text.Length)
            {
                string Letter = LettersNotInIt.Text[i].ToString().ToUpper();
                Contradicts = HasLetterSomewhereThatIsBadLetter(Letter) || WordHasLetterInPlaceThatIsBadLetter(Letter);
                i++;
            }


            return !Contradicts && !LettersInWordAsSameAsWhereItIsnt();
        }

        private bool LettersInWordAsSameAsWhereItIsnt()
        {
            return FirstPlace.Items.Contains(FirstLetter.SelectedItem.ToString().ToUpper()) || SecondPlace.Items.Contains(SecondLetter.SelectedItem.ToString().ToUpper()) || ThirdPlace.Items.Contains(ThirdLetter.SelectedItem.ToString().ToUpper()) || FourthPlace.Items.Contains(FourthLetter.SelectedItem.ToString().ToUpper()) || FithPlace.Items.Contains(FithLetter.SelectedItem.ToString().ToUpper());
        }

        private bool WordHasLetterInPlaceThatIsBadLetter(string letter)
        {
            return FirstLetter.SelectedItem.ToString() == letter || SecondLetter.SelectedItem.ToString() == letter || ThirdLetter.SelectedItem.ToString() == letter || FourthLetter.SelectedItem.ToString() == letter || FithLetter.SelectedItem.ToString() == letter;
        }

        private bool HasLetterSomewhereThatIsBadLetter(string Letter)
        {
            return FirstPlace.Items.Contains(Letter) || SecondPlace.Items.Contains(Letter) || ThirdPlace.Items.Contains(Letter) || FourthPlace.Items.Contains(Letter) || FithPlace.Items.Contains(Letter);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mw.Show();
        }

        private void LettersNotInIt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lowercase = LettersNotInIt.Text.ToLower();
            LettersNotInIt.Text = lowercase;
            Regex OnlyLettersWithoutSpace = new Regex(@"^[a-z]+$");
            if (!OnlyLettersWithoutSpace.IsMatch(LettersNotInIt.Text) && LettersNotInIt.Text != string.Empty)
            {
                MessageBox.Show($"The input isn't a letter used in a word.", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                LettersNotInIt.Text = new Regex(@"[^a-z]").Replace(LettersNotInIt.Text, "");

            }
            else
            {
                if (ItIsAlreadyInTheString(LettersNotInIt.Text))
                {
                    MessageBox.Show($"The letter is already present.", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    string Corrected = WithoutDuplicateLetters(LettersNotInIt.Text);
                    LettersNotInIt.Text = Corrected;
                }
            }
        }

        private string WithoutDuplicateLetters(string text)
        {
            string OnlyUniqueLetters = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (!OnlyUniqueLetters.Contains(text[i]))
                {
                    OnlyUniqueLetters += text[i];
                }
            }

            return OnlyUniqueLetters;
        }

        private bool ItIsAlreadyInTheString(string lettersNotInIt)
        {
            int i = 0;
            bool ItIsInAlready = false;
            while (i < lettersNotInIt.Length && !ItIsInAlready)
            {
                int j = lettersNotInIt.Length-1;
                while (j > i && !ItIsInAlready)
                {
                    ItIsInAlready = lettersNotInIt[i] == lettersNotInIt[j];
                    j--;
                }

                i++;
            }

            return ItIsInAlready;
        }

        private void AddItInTheList_Click(object sender, RoutedEventArgs e)
        {
            if (WhereIsItNot.SelectedItem != null && WhatLetter.SelectedItem != null)
            {
                switch (Convert.ToInt32(WhereIsItNot.SelectedItem))
                {
                    case 1:
                        if (!FirstPlace.Items.Contains(WhatLetter.SelectedValue.ToString()))
                        {
                            FirstPlace.Items.Add(WhatLetter.SelectedValue.ToString());
                        }
                        break;

                    case 2:
                        if (!SecondPlace.Items.Contains(WhatLetter.SelectedValue.ToString()))
                        {
                            SecondPlace.Items.Add(WhatLetter.SelectedValue.ToString());
                        }
                        break;

                    case 3:
                        if (!ThirdPlace.Items.Contains(WhatLetter.SelectedValue.ToString()))
                        {
                            ThirdPlace.Items.Add(WhatLetter.SelectedValue.ToString());
                        }
                        break;

                    case 4:
                        if (!FourthPlace.Items.Contains(WhatLetter.SelectedValue.ToString()))
                        {
                            FourthPlace.Items.Add(WhatLetter.SelectedValue.ToString());
                        }
                        break;

                    default:
                        if (!FithPlace.Items.Contains(WhatLetter.SelectedValue.ToString()))
                        {
                            FithPlace.Items.Add(WhatLetter.SelectedValue.ToString());
                        }
                        break;
                }

                WhatLetter.SelectedIndex = -1;
                WhereIsItNot.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show($"Please select what letter does the word contain and where it was not located", "Select both boxes", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void DeleteFirstSelected_Click(object sender, RoutedEventArgs e)
        {
            if (FirstPlace.SelectedItem != null)
            {
                FirstPlace.Items.Remove(FirstPlace.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a letter, that you want to delete from the list.", "Select a letter", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void DeleteSecondSelected_Click(object sender, RoutedEventArgs e)
        {
            if (SecondPlace.SelectedItem != null)
            {
                SecondPlace.Items.Remove(SecondPlace.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a letter, that you want to delete from the list.", "Select a letter", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void DeleteThirdSelected_Click(object sender, RoutedEventArgs e)
        {
            if (ThirdPlace.SelectedItem != null)
            {
                ThirdPlace.Items.Remove(ThirdPlace.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a letter, that you want to delete from the list.", "Select a letter", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void DeleteFourthSelected_Click(object sender, RoutedEventArgs e)
        {
            if (FourthPlace.SelectedItem != null)
            {
                FourthPlace.Items.Remove(FourthPlace.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a letter, that you want to delete from the list.", "Select a letter", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void DeleteFithSelected_Click(object sender, RoutedEventArgs e)
        {
            if (FithPlace.SelectedItem != null)
            {
                FithPlace.Items.Remove(FithPlace.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a letter, that you want to delete from the list.", "Select a letter", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
