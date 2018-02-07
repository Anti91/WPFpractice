using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFsumApp.ViewModel
{
    public class MainWindowViewModel
    {


        public OperationViewModel OperationViewModelTest
        {
            get;
            set;
        }
        public MainWindowViewModel()
        {
            OperationViewModelTest  = new OperationViewModel();
        }
    }
}
