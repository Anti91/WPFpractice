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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFsumApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            tesxtBlockIpsum.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                 "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                                 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi " +
                                 "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
                                 " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur " +
                                 "sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt " +
                                 "mollit anim id est laborum.";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnSumm_Click(object sender, RoutedEventArgs e)
        {
            int intnumbersum = int.Parse(numberOne.Text)+int.Parse(numberOne.Text);

            numberSum.Text = intnumbersum.ToString();

            numberOne.Text = "0";
            numberTwo.Text = "0";
        }

        private void numberOne_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            checkTextInputIsNumber(e);
        }

        private void numberTwo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            checkTextInputIsNumber(e);
        }

        public void checkTextInputIsNumber(TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

       
    }
}
