using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFsumApp.ViewModel;

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class OperationView : UserControl
    {
        OperationViewModel _operationViewModel = new OperationViewModel();
       
        public OperationView()
        {
            InitializeComponent();
            DataContext = _operationViewModel;      
        }
        
    
    }
}

