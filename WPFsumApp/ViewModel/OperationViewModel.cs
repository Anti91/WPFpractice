using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Specialized;

namespace WPFsumApp.ViewModel
{
    public class OperationViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private string _boundNum1;
        private string _boundNum2;
        private ObservableCollection<Operation> _operationList;
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

            _operationList =new ObservableCollection<Operation>(DatabaseObject.SelectOpList(DatabaseObject));

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

        public ObservableCollection<Operation> OperationList
        {
            get
            {

                return _operationList;
            }

        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;


        private void OnNotifyCollectionChanged( NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
           {
                this.CollectionChanged(this, args);
           }
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


       

        public void ValueToDataGrid(int num1, string op, int num2, int result)
        {
            int id = _operationList.Count();
            string timestamp = DateTime.Now.ToString();
            Operation addedOperation = new Operation { Id = ++id, Firstnumber = num1, Op = op, Secondnumber = num2, Result = result, Timestamp = timestamp };
          
            
            _operationList.Add(addedOperation);
            NotifyCollectionChangedEventArgs e  = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _operationList);
            OnNotifyCollectionChanged(e);

            // dGridHistory.Items.Add(new Operation { Id = id, Firstnumber = num1, Op = op, Secondnumber = num2, Result = result, Timestamp = timestamp });
            DatabaseObject.InsertNewOp(DatabaseObject, id, num1, op, num2, result, timestamp.ToString());
        }

       
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

        public void CleanOperationList()
        {
            DatabaseObject.DeleteAllOp(DatabaseObject);
            _operationList.Clear();

        }
    }
}



