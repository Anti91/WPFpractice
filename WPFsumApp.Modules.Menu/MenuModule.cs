using Prism.Mef.Modularity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFsumApp.Modules.Menu
{
   
        [ModuleExport(typeof(MenuModule))]
        public class MenuModule : IModule
        {
             public void Initialize() { }
        }
    
}
