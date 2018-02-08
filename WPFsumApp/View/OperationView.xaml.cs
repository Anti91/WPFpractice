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

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class OperationView : UserControl
    {
 
        TestSQLiteDB databaseObject;
        public OperationView()
        {
            InitializeComponent();
            databaseObject = new TestSQLiteDB();


            foreach (var item in databaseObject.SelectOpList(databaseObject))
            {
                dGridHistory.Items.Add(item);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnSumm_Click(object sender, RoutedEventArgs e)
        {
            labelNoOp.Visibility = Visibility.Hidden;

            int result = getCalcResult(int.Parse(numberOne.Text), int.Parse(numberTwo.Text), comboMathSymbol.SelectedIndex);

            numberSum.Text = result.ToString();

            if (comboMathSymbol.SelectedIndex != -1)
            {
                ValueToDataGrid(int.Parse(numberOne.Text), comboMathSymbol.SelectionBoxItem.ToString(), int.Parse(numberTwo.Text), result);
            }
            numberOne.Text = "0";
            numberTwo.Text = "0";
        }

        //Return the result of the selected operation
        public int getCalcResult(int num1, int num2, int opIndex)
        {
            int result = 0;
            switch (comboMathSymbol.SelectedIndex)
            {
                case 0:
                    result = num1 + num2;
                    break;
                case 1:
                    result = num1 - num2;
                    break;
                case 2:
                    result = num1 * num2;
                    break;
                case 3:
                    result = num1 / num2;
                    break;
                default:
                    labelNoOp.Content = "You need select the math operation!!!";
                    labelNoOp.Visibility = Visibility.Visible;
                    break;
            }
            return result;
        }

        private void numberOne_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            checkTextInputIsNumber(e, labelError1);
        }

        private void numberTwo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            checkTextInputIsNumber(e, labelError2);
        }

        public void checkTextInputIsNumber(TextCompositionEventArgs e, Label errorMessage)
        {
            if (Regex.IsMatch(e.Text, "[^0-9]+"))
            {
                e.Handled = true;
                errorMessage.Content = e.Text + ": is not number (0-9)";
                errorMessage.Visibility = Visibility.Visible;
            }
            else
            {
                e.Handled = false;
                errorMessage.Visibility = Visibility.Hidden;
            }
        }
        //Add Row to "dGridHistory" Datagrid
        public void ValueToDataGrid(int num1, string op, int num2, int result)
        {
            int id = dGridHistory.Items.Count + 1;
            string timestamp = DateTime.Now.ToString();

            dGridHistory.Items.Add(new Operation { Id = id, Firstnumber = num1, Op = op, Secondnumber = num2, Result = result, Timestamp = timestamp });
            databaseObject.InsertNewOp(databaseObject, id, num1, op, num2, result, timestamp.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            databaseObject.DeleteAllOp(databaseObject);

            dGridHistory.Items.Clear();
        }
    }
}

