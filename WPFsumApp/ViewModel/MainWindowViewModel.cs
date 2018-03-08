using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Prism.Mvvm;

namespace WPFsumApp.ViewModel
{
    [Export]
    public class MainWindowViewModel : BindableBase
    {
        private object _activeViewModel;
        private readonly CompositionContainer _container;

        [ImportingConstructor]
        public MainWindowViewModel(CompositionContainer container)
        {
            _container = container;
            //ActiveViewModel = _container.GetExportedValue<OperationViewModel>();
        }

        //public object ActiveViewModel
        //{
        //    get { return _activeViewModel; }
        //    set { SetProperty(ref _activeViewModel, value); }
        //}

        [Import]
        public OperationViewModel OperationViewModel { get; set; }
    }
}
