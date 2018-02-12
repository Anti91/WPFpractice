using System.Windows;
using WPFsumApp.ViewModel;

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
            DataContext = new MainWindowViewModel();

        }

    }
}
