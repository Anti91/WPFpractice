﻿using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Regions;
using WPFsumApp.Modules.Operations.View;
using WPFsumApp.View;

namespace WPFsumApp.ViewModel
{
    [Export(typeof(MenuViewModel))]
    public class MenuViewModel
    {
        private IRegionManager _regionManager;

        [ImportingConstructor]
        public MenuViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            PropertiesCommand = new DelegateCommand(PropertiesCommandExecute);
            ClaculatorCommand = new DelegateCommand(ClaculatorCommandExecute);
        }

        public ICommand PropertiesCommand { get; set; }

        public ICommand ClaculatorCommand { get; set; }

        private void PropertiesCommandExecute()
        {
            IRegion region = _regionManager.Regions["ContentRegion"];
            object ordersView = region.Views.FirstOrDefault(v => v.GetType().IsEquivalentTo(typeof(LoginView)));

            region.Activate(ordersView);
        }

        private void ClaculatorCommandExecute()
        {
            IRegion region = _regionManager.Regions["ContentRegion"];

            object ordersView = region.GetView("OperationView");
            if (ordersView == null)
            {
                ordersView = ServiceLocator.Current.GetInstance<OperationView>();
                region.Add(ordersView, "OperationView");
            }

            region.Activate(ordersView);
        }
    }
}