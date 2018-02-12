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
using System.Data.SQLite;
using WPFsumApp.ViewModel;

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class OperationView : UserControl
    {
        OperationViewModel _operationViewModel = new OperationViewModel();
        TestSQLiteDB databaseObject;
        public OperationView()
        {
            InitializeComponent();
            
            DataContextChanged += OnDataContextChanged;

            
        }
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                databaseObject = ((OperationViewModel)(this.DataContext)).DatabaseObject;

                DataContext = _operationViewModel;
                
            }
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

           // numberOne.Text = "0";
           // numberTwo.Text = "0";
        }

        //Return the result of the selected operation
       

        private void numberOne_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            _operationViewModel.checkTextInputIsNumber(e, labelError1);
        }

        private void numberTwo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            _operationViewModel.checkTextInputIsNumber(e, labelError2);
        }

       
        //Add Row to "dGridHistory" Datagrid
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            databaseObject.DeleteAllOp(databaseObject);

            //dGridHistory.Items.Clear();
        }
    }
}

