using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using WPFsumApp.View;

namespace WPFsumApp.MVVM
{
    //[ModuleExport(typeof(ModuleA))]
    public class ModuleA : IModule
    {
        private readonly IRegionManager regionManager;

        //[ImportingConstructor]
        public ModuleA(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationView));
        }
    }
}
