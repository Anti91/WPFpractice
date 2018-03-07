using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using WPFsumApp.ViewModel;

namespace WPFsumApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : Window
    {
        [ImportingConstructor]
        public MainWindow(OperationViewModel container)
        {
            InitializeComponent();

            //var opView = container.GetExportedValue<OperationViewModel>();
        }

        [Import]
        public MainWindowViewModel ViewModel
        {
            get => DataContext as MainWindowViewModel;
            set => DataContext = value;
        }
    }
}
