using Prism.Mef.Modularity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFsumApp.Modules.Operations
{
   
        [ModuleExport(typeof(OperationsModule))]
        public class OperationsModule : IModule
        {
             public void Initialize() { }
        }
    
}
