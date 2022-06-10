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

namespace wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _5letterwordgen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DictionaryCheck.CreateCopyOf5LetterWords();
                MessageBox.Show("The dictionary's optimization for wordle is complete.\n You will find the original and the optimised in the program's folder.", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception Error)
            {
                MessageBox.Show($"Something failed during the optimization.\n Error message: {Error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Del5letterWordDict_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DictionaryCheck.DeleteCopyOf5LetterWords();
                MessageBox.Show("The optimized dictionary was deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception Error)
            {
                MessageBox.Show($"Something failed during the deletion of the file.\n Try Deleting the file from the program's directory.\n Error message: {Error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DetailedSearch NewWindow = new DetailedSearch(this);
            this.Hide();
            NewWindow.Show();
        }
    }
}
