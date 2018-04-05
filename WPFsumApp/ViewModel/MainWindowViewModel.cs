using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Prism.Mvvm;
using Prism.Regions;
using WPFsumApp.Controllers;
using WPFsumApp.View;

namespace WPFsumApp.ViewModel
{
    [Export]
    public class MainWindowViewModel : BindableBase
    {
        // private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public MainWindowViewModel(IRegionManager regionManager,
            UserController userController)//(IRegionManager regionManager)
        {
            UserController = userController ?? throw new ArgumentNullException(nameof(userController));

            //this._regionManager = regionManager;
            //this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(LoginView));
           // regionManager.RegisterViewWithRegion("ContentRegion", typeof(OperationView));
            regionManager.RegisterViewWithRegion("MenuRegion", typeof(MenuView));

            
            // ActiveViewModel = _container.GetExportedValue<OperationViewModel>();
        }

        public UserController UserController { get; }

        // public object ActiveViewModel
        // {
        //    get { return _activeViewModel; }
        //    set { SetProperty(ref _activeViewModel, value); }
        // }
        //[Import]
        //public OperationViewModel OperationViewModel { get; set; }
    }
}
