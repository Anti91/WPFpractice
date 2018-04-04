using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Prism.Mvvm;
using Prism.Regions;
using WPFsumApp.View;

namespace WPFsumApp.ViewModel
{
    [Export]
    public class MainWindowViewModel : BindableBase
    {
        // private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public MainWindowViewModel(IRegionManager regionManager)//(IRegionManager regionManager)
        {
            //this._regionManager = regionManager;
            //this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationView));
            regionManager.RegisterViewWithRegion("MenuRegion", typeof(MenuView));
            // ActiveViewModel = _container.GetExportedValue<OperationViewModel>();
        }

        // public object ActiveViewModel
        // {
        //    get { return _activeViewModel; }
        //    set { SetProperty(ref _activeViewModel, value); }
        // }
        //[Import]
        //public OperationViewModel OperationViewModel { get; set; }
    }
}
