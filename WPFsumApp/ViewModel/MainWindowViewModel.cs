using System;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using Prism.Regions;
using WPFsumApp.Controllers;
using WPFsumApp.View;

namespace WPFsumApp.ViewModel
{
    [Export]
    public class MainWindowViewModel : BindableBase
    {
        [ImportingConstructor]
        public MainWindowViewModel(
            IRegionManager regionManager,
            UserController userController)
        {
            UserController = userController ?? throw new ArgumentNullException(nameof(userController));

            regionManager.RegisterViewWithRegion("ContentRegion", typeof(LoginView));
            regionManager.RegisterViewWithRegion("MenuRegion", typeof(MenuView));
        }

        public UserController UserController { get; }
    }
}
