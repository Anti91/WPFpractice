using System.ComponentModel.Composition;
using System.Windows.Controls;
using WPFsumApp.ViewModel;

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    [Export]
    public partial class OperationView : UserControl
    {
        public OperationView()
        {
            InitializeComponent();
        }

        [Import]
        public OperationViewModel ViewModel
        {
            get => DataContext as OperationViewModel;
            set => DataContext = value;
        }
    }
}