using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Prism.Mef;
using WPFsumApp.Modules.Operations;
using WPFsumApp.Common.Controllers;

namespace WPFsumApp
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(UserController).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(OperationsModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            base.ConfigureAggregateCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (MainWindow)Shell;
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Activate();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Container für andere Module verfügbar machen
            Container.ComposeExportedValue(Container);
        }
    }
}