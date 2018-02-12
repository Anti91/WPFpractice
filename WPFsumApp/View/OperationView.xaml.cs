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
        
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnSumm_Click(object sender, RoutedEventArgs e)
        {
            labelNoOp.Visibility = Visibility.Hidden;

            int result = _operationViewModel.GetCalcResult(int.Parse(numberOne.Text), int.Parse(numberTwo.Text), comboMathSymbol.SelectedIndex, labelNoOp);

            numberSum.Text = result.ToString();

            if (comboMathSymbol.SelectedIndex != -1)
            {
                _operationViewModel.ValueToDataGrid(int.Parse(numberOne.Text), comboMathSymbol.SelectionBoxItem.ToString(), int.Parse(numberTwo.Text), result);
            }

            _operationViewModel.BoundNum1 = "0";
            _operationViewModel.BoundNum2 = "0";
        }
     
        private void numberOne_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            _operationViewModel.checkTextInputIsNumber(e, labelError1);
        }

        private void numberTwo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            _operationViewModel.checkTextInputIsNumber(e, labelError2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {         
            _operationViewModel.CleanOperationList();           
        }
    }
}

