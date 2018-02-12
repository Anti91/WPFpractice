using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFsumApp.ViewModel
{
    public class OperationViewModel : INotifyPropertyChanged  
    {
        private string _boundNum1;
        private string _boundNum2;


        public OperationViewModel()
        {
            OperationCollection = new List<string>()
            {
                "+",
                "-",
                "*",
                "/"
            };

            LoremIpsumText =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                 "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                                 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi " +
                                 "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
                                 " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur " +
                                 "sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt " +
                                 "mollit anim id est laborum.";

            DatabaseObject = new TestSQLiteDB();

            //Off magamnak: ObservableCollection alpaban tartalmazza a INotifyCollectionChanged, INotifyPropertyChanged -eket sima listel ellentétben
            OperationList = new ObservableCollection<Operation>(DatabaseObject.SelectOpList(DatabaseObject));
            
        }

        public TestSQLiteDB DatabaseObject
        {
            get;
            set;
        }
        public List<string> OperationCollection
        {
            get;
            set;
        }
        public ObservableCollection<Operation> OperationList
        {
            get;
            set;
        }
        public string LoremIpsumText
        {
            get;
            set;
        }

        public string BoundNum1
        {
            get {

                if (string.IsNullOrEmpty(_boundNum1))
                    return "0";

                return _boundNum1;
            }
            set
            {
                _boundNum1 = value;
                OnPropertyChanged("BoundNum1");
            }
        }
        public string BoundNum2
        {
            get
            {
                if (string.IsNullOrEmpty(_boundNum2))
                    return "0";

                return _boundNum2;
            }
            set
            {
                _boundNum2 = value;
                OnPropertyChanged("BoundNum2");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        //Check Imput Char is Number and show errorlabel
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

        //Add Row to OperationList
        public void ValueToDataGrid(int num1, string op, int num2, int result)
        {
            int id = OperationList.Count();
            string timestamp = DateTime.Now.ToString();
            Operation addedOperation = new Operation { Id = ++id, Firstnumber = num1, Op = op, Secondnumber = num2, Result = result, Timestamp = timestamp };
                      
            OperationList.Add(addedOperation);


            DatabaseObject.InsertNewOp(DatabaseObject, id, num1, op, num2, result, timestamp.ToString());
        }

        //Return the result of the selected operation
        public int GetCalcResult(int num1, int num2, int opIndex, Label labelNoOp)
        {
            foreach (var item in DatabaseObject.SelectOpList(DatabaseObject))
            {

            }
            int result = 0;
            switch (opIndex)
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

        //Delete all Operation from DB and Clear OperationList Items
        public void CleanOperationList()
        {
            DatabaseObject.DeleteAllOp(DatabaseObject);
            OperationList.Clear();

        }
    }
}



