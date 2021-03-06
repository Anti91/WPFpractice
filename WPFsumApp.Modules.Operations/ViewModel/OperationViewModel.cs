﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using WPFsumApp.Common.Controllers;
using WPFsumApp.Modules.Operations.Model;


namespace WPFsumApp.Modules.Operations.ViewModel
{
    [Export]
    public class OperationViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _boundNum1;
        private string _boundNum2;
        private string _boundNumSum;
        private bool _visible;
        private string[] _validatedProperties = { nameof(BoundNum1), nameof(BoundNum1) };

        [ImportingConstructor]
        public OperationViewModel(
            UserController userController
            )
        {
            UserController = userController ?? throw new ArgumentNullException(nameof(userController));

            OperationSymbolList = new ObservableCollection<string>(new List<string>()
            {
                "+",
                "-",
                "*",
                "/"
            });

            LoremIpsumText =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                 "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                                 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi " +
                                 "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
                                 " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur " +
                                 "sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt " +
                                 "mollit anim id est laborum.";

            DatabaseObject = new TestSQLiteDB();

            // Off magamnak: ObservableCollection alpaban tartalmazza a INotifyCollectionChanged, INotifyPropertyChanged -eket sima listel ellentétben
            OperationCollection = new ObservableCollection<Operation>(DatabaseObject.SelectOpList(DatabaseObject));

            SummClickCommand = new DelegateCommand(SumClickMethod);
            ClearButtonClickCommand = new DelegateCommand(ClearButtonClickMethod);
            ExitButtonClickCommand = new DelegateCommand(ExitButtonClickMethod);
            _visible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

       // public UserController UserController { get; }

        string IDataErrorInfo.Error => null;

        public bool IsValid
        {
            get
            {
                foreach (string property in _validatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public ICommand SummClickCommand
        {
            get; set;
        }

        public ICommand ClearButtonClickCommand
        {
            get; set;
        }

        public ICommand ExitButtonClickCommand
        {
            get; set;
        }

        public TestSQLiteDB DatabaseObject
        {
            get;
            set;
        }
        public object UserController { get; }
        public ObservableCollection<string> OperationSymbolList
        {
            get;
        }

        public ObservableCollection<Operation> OperationCollection
        {
            get;
        }

        public string LoremIpsumText
        {
            get;
        }

        public string TheSelectedItem
        {
            get;
            set;
        }

        public bool Visible
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        public string BoundNum1
        {
            get
            {
                if (string.IsNullOrEmpty(_boundNum1))
                    return "0";

                return _boundNum1;
            }

            set
            {
                _boundNum1 = value;
                OnPropertyChanged(nameof(BoundNum1));
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
                OnPropertyChanged(nameof(BoundNum2));
            }
        }

        public string BoundNumSum
        {
            get
            {
                if (string.IsNullOrEmpty(_boundNumSum))
                    return "0";

                return _boundNumSum;
            }

            set
            {
                _boundNumSum = value;
                OnPropertyChanged(nameof(BoundNumSum));
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        // Add Row to OperationList
        public void ValueToDataGrid(int num1, int num2, int result)
        {
            if (TheSelectedItem != null)
            {
                int id = OperationCollection.Count();
                string timestamp = DateTime.Now.ToString();
                Operation addedOperation = new Operation { Id = ++id, Firstnumber = num1, Op = TheSelectedItem, Secondnumber = num2, Result = result, Timestamp = timestamp };

                OperationCollection.Add(addedOperation);
                DatabaseObject.InsertNewOp(DatabaseObject, addedOperation);
            }
            else
            {
                Visible = true;
            }
        }

        // Return the result of the selected operation
        public int GetCalcResult(int num1, int num2, string opSymbol)
        {
            int result = 0;
            switch (opSymbol)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    Visible = true;
                    break;
            }

            return result;
        }

        // Delete all Operation from DB and Clear OperationList Items
        public void ClearButtonClickMethod()
        {
            DatabaseObject.DeleteAllOp(DatabaseObject);
            OperationCollection.Clear();
        }

        // Itt lett volna kérdés
        public bool IsRegisteredUserID(int id)
        {
            // foreach (var item in UsersListProperty)
            // {
            //     if (item.ID == id)
            //         return true;
            //     else
            //         return false;
            // }
            if (id == 1 || id == 3)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SumClickMethod()
        {
            Visible = false;
            int result = GetCalcResult(int.Parse(BoundNum1), int.Parse(BoundNum2), TheSelectedItem);

            BoundNumSum = result.ToString();

            if (TheSelectedItem != null)
            {
                ValueToDataGrid(int.Parse(BoundNum1), int.Parse(BoundNum2), result);
                BoundNum1 = "0";
                BoundNum2 = "0";
            }
        }

        #region Validator ViewModel Iplementation

        private void ExitButtonClickMethod()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case nameof(BoundNum1):
                    error = ValidateNumber(BoundNum1);
                    break;
                case nameof(BoundNum2):
                    error = ValidateNumber(BoundNum2);
                    break;
            }

            return error;
        }

        private string ValidateNumber(string numprop)
        {
            if (!string.IsNullOrEmpty(numprop))
            {
                try
                {
                    int val = int.Parse(numprop);

                    return null;
                }
                catch (Exception)
                {
                    if (numprop == BoundNum1)
                    {
                        numprop = numprop.Substring(0, numprop.Length - 1);
                        BoundNum1 = numprop;
                    }
                    else
                    {
                        numprop = numprop.Substring(0, numprop.Length - 1);
                        BoundNum2 = numprop;
                    }

                    return "Nem Számot írtál be";
                }
            }

            return null;
        }
        #endregion
    }
}