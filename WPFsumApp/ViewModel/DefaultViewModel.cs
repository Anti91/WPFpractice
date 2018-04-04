using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Prism.Mvvm;
using Prism.Regions;
using WPFsumApp.View;

namespace WPFsumApp.ViewModel
{
    [Export]
    public class DefaultViewModel 
    {
        
        public DefaultViewModel(RegionManager regionManager)
        {
            //PropertiesClickCommand = new DelegateCommand(PropertiesClickMethode);
            //CalculatorClickCommand = new DelegateCommand(CalculatorClickMethode);
            //UserClickCommand = new DelegateCommand(UserClickMethode);

           regionManager.RegisterViewWithRegion("DefaultViewRegion", typeof(OperationView));

            //DefaultViewRegion
           // regionManager.RegisterViewWithRegion("DefaultViewRegion", typeof(LoginUserControl));

            //var region = regionManager.Regions["DefaultViewRegion"];

            // this._region = region;

        }

        //public ICommand PropertiesClickCommand
        //{
        //    get; set;
        //}

        //public ICommand CalculatorClickCommand
        //{
        //    get; set;
        //}

        //public ICommand UserClickCommand
        //{
        //    get; set;
        //}

        //public void PropertiesClickMethode()
        //{
        //    //_region.Activate(typeof(LoginUserControl));
        //}

        //public void CalculatorClickMethode()
        //{
        //    //_region.Activate(typeof(OperationView));
        //}

        //public void UserClickMethode()
        //{

        //}

    }
}
