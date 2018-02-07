using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFsumApp.ViewModel
{
    public class MainWindowViewModel
    {


        public OperationViewModel OperationViewModel
        {
            get;
            set;
        }
        public MainWindowViewModel()
        {
            OperationViewModel  = new OperationViewModel();
        }
    }
}
