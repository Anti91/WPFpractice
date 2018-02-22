using System.Windows.Controls;
using WPFsumApp.ViewModel;

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class OperationView : UserControl
    {
        private OperationViewModel _operationViewModel = new OperationViewModel();

        public OperationView()
        {
            InitializeComponent();
            DataContext = _operationViewModel;
        }
    }
}