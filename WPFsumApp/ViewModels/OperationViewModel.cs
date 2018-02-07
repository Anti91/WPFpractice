using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFsumApp.ViewModels
{
    public class OperationViewModel
    {

        public List<string> OperationCollection
        {
            get;
            set;
        }

        public OperationViewModel()
        {
            OperationCollection = new List<string>()
            {
                "+",
                "-",
                "*",
                "/"
            };
        }
    }
}
