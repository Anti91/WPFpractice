using System.ComponentModel.Composition;
using System.Windows;

namespace WPFsumApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : Window
    {
        // [ImportingConstructor]
        public MainWindow()
        {
            InitializeComponent();
        }

        // [Import]
        // public MainWindowViewModel ViewModel
        // {
        //     get => DataContext as MainWindowViewModel;
        //     set => DataContext = value;
        // }
    }
}
