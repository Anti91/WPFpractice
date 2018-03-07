

using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using WPFsumApp.View;

namespace WPFsumApp.MVVM
{
    public class CenitoBootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(CenitoBootstrapper).Assembly));
            base.ConfigureAggregateCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (MainWindow)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
