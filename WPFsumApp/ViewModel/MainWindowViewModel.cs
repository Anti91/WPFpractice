using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Prism.Mvvm;
using Prism.Regions;
using WPFsumApp.View;

namespace WPFsumApp.ViewModel
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public MainWindowViewModel(CompositionContainer container)//(IRegionManager regionManager)
        {
            var regionManager = container.GetExportedValue<IRegionManager>();
            this._regionManager = regionManager;
            this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationView));

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
